using System;
using MSSQLConverter;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Dapper;
using Npgsql;

namespace MSSQLConverter.Classes
{
    /// <summary>
    /// Description of Converter.
    /// </summary>
    public class Converter
    {
        private baseSQLServer m_FromServer = null;
        private baseSQLServer m_ToServer = null;
        private Settings m_ConversionSettings;

        public Converter(baseSQLServer FromServer, baseSQLServer ToServer, Settings ConversionSettings)
        {
            m_FromServer = FromServer;
            m_ToServer = ToServer;
            m_ConversionSettings = ConversionSettings;
        }

        public bool Convert()
        {
            bool result = false;

            try
            {
                if (m_ConversionSettings.ConvertTables)
                {
                    ConvertTables();
                }

                result = true;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        private void ConvertTables()
        {
            //
            StringBuilder sql = new StringBuilder();

            #region SqlServer连接字符串

            var server = m_FromServer.ServerName;
            var db = m_FromServer.Database;

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = db,
                IntegratedSecurity = true
            };

            //sqlserver连接字符串
            string connectionString = connectionStringBuilder.ConnectionString;

            #endregion

            #region Postgresql连接字符串

            var npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = m_ToServer.ServerName,
                Port = 5432,
                Database = m_ToServer.Database,
                Username = m_ToServer.Username,
                Password = m_ToServer.Password,
                Encoding= "UTF8",
                Timeout = 30,
                CommandTimeout = 30
            };

            //postgresql连接字符串
            string npgsqlConnectionString = npgsqlConnectionStringBuilder.ConnectionString;

            #endregion

            #region 判断postgresql里数据库是否存在

            using (NpgsqlConnection psqlConnection = new NpgsqlConnection(npgsqlConnectionString))
            {
                try
                {
                    var existdb = psqlConnection.QueryFirstOrDefault(
                        $@"SELECT u.datname  FROM pg_catalog.pg_database u where u.datname='{m_ToServer.Database}';");


                    if (existdb == null)
                    {
                        sql.AppendLine($@"CREATE DATABASE {m_ToServer.Database}
                                                      WITH OWNER = postgres
                                                       ENCODING = 'UTF8'
                                                       TABLESPACE = pg_default
                                                       LC_COLLATE = 'Chinese (Simplified)_China.936'
                                                       LC_CTYPE = 'Chinese (Simplified)_China.936'
                                                       CONNECTION LIMIT = -1;");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
            }

            #endregion


            #region 从SQL server获取表, 生成pgsql脚本

            using (var cn = new SqlConnection(connectionString))
            {
                //表信息
                var tables = cn.Query(@"select * from INFORMATION_SCHEMA.TABLES");
                //列信息
                var columns = cn.Query("select * from INFORMATION_SCHEMA.COLUMNS");
                //表约束信息
                var tableContraints = cn.Query(@"select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS");
                //表外键约束的信息
                var referentialConstraints = cn.Query(@"select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS");
                //当前数据库中被某个约束使用的所有列
                var constraintsColumnUsage = cn.Query(@"select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE");

                //结合sys.indexes和sys.index_columns,sys.objects,sys.columns查询索引所属的表
                //在sys.indexes表中只能查找到索引的名称和信息，但是对于索引中包含的字段不能够直接读出。因此可以与sys.index_columns联查寻找索引包含的字段。
                var indexColumns = cn.Query(@"
                                                                SELECT 
                                                                     TableName = t.name,
                                                                     IndexName = ind.name,
                                                                     IndexId = ind.index_id,
                                                                     ColumnId = ic.index_column_id,
                                                                     ColumnName = col.name,
	                                                                 IsDesc = ic.is_descending_key,
                                                                    ind.is_primary_key
                                                                FROM 
                                                                     sys.indexes ind 
                                                                INNER JOIN 
                                                                     sys.index_columns ic ON  ind.object_id = ic.object_id and ind.index_id = ic.index_id 
                                                                INNER JOIN 
                                                                     sys.columns col ON ic.object_id = col.object_id and ic.column_id = col.column_id 
                                                                INNER JOIN 
                                                                     sys.tables t ON ind.object_id = t.object_id
                                                                ");

                foreach (var table in tables)
                {
                    sql.AppendLine("CREATE TABLE " + table.TABLE_NAME.ToLower());
                    sql.AppendLine("(");
                    int columnOrdinal = 0;
                    foreach (var column in columns.Where(c => c.TABLE_NAME == table.TABLE_NAME))
                    {
                        if (column.DATA_TYPE == "geography")
                            continue; // This isn't a supported type in Postgresql.

                        sql.Append(columnOrdinal > 0 ? "\t," : "\t");

                        sql.Append("\"" + column.COLUMN_NAME.ToLower() + "\" ");

                        //转换数据类型
                        ConvertDatatype(column, sql);

                        if (column.IS_NULLABLE == "NO")
                        {
                            sql.Append(" NOT NULL");
                        }

                        if (column.COLUMN_DEFAULT != null)
                        {
                            //这被硬编码到我的数据实现中
                            if (column.DATA_TYPE == "bit" && column.COLUMN_DEFAULT == "((0))")
                            {
                                sql.Append(" DEFAULT FALSE");
                            }
                            else if (column.DATA_TYPE == "bit" && column.COLUMN_DEFAULT == "((1))")
                            {
                                sql.Append(" DEFAULT TRUE");
                            }
                            else if (column.DATA_TYPE == "int")
                            {
                                sql.Append(" DEFAULT " + column.COLUMN_DEFAULT.Replace("(", "").Replace(")", ""));
                            }
                            else if (column.COLUMN_DEFAULT == "(getutcdate())" ||
                                     column.DATA_TYPE == "datetimeoffset" || column.DATA_TYPE == "datetime" ||
                                     column.DATA_TYPE == "datetime2")
                            {
                                sql.Append(" DEFAULT timezone('utc'::text, now())");
                            }
                        }

                        sql.AppendLine();
                        columnOrdinal++;
                    }

                    //表示不分配 OID
                    //oid是object identifier的简写
                    sql.AppendLine(") WITH (OIDS=FALSE);");

                    sql.AppendLine();
                }


                foreach (var tableConstraint in tableContraints.Where(tc => !String.IsNullOrWhiteSpace(tc.TABLE_NAME)))
                {
                    //主键约束
                    if (tableConstraint.CONSTRAINT_TYPE == "PRIMARY KEY")
                    {
                        var pkColumnObjs = indexColumns.Where(c => c.IndexName == tableConstraint.CONSTRAINT_NAME)
                            .Select(s => new { COLUMN_NAME = s.ColumnName, ORDER = s.ColumnId });
                        var pkColumns = string.Join(",", pkColumnObjs.OrderBy(s => s.ORDER).Select(s => s.COLUMN_NAME));
                        string primaryKey = string.Format(@"ALTER TABLE {2}  ADD CONSTRAINT {0} PRIMARY KEY({1});",
                            tableConstraint.CONSTRAINT_NAME.ToString().ToLower().Replace("[", "").Replace("]", ""),
                            pkColumns.ToLower(), tableConstraint.TABLE_NAME.ToLower());
                        sql.AppendLine(primaryKey);
                    }
                }

                //标出当前数据库中所有被某些唯一约束、主键约束或者外键约束限制的字段
                var keyColumnUsage = cn.Query(@"select * from INFORMATION_SCHEMA.KEY_COLUMN_USAGE");

                var foreignKeys = cn.Query(
                    @"select ctu.TABLE_NAME, rc.CONSTRAINT_NAME, uniqueTableConstraint.CONSTRAINT_NAME as PrimaryKeyConstraintName,  uniqueTableConstraint.TABLE_NAME as ReferencedTableName from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc
                            inner join INFORMATION_SCHEMA.CONSTRAINT_TABLE_USAGE ctu on ctu.CONSTRAINT_NAME = rc.CONSTRAINT_NAME
                            inner join INFORMATION_SCHEMA.TABLE_CONSTRAINTS uniqueTableConstraint on uniqueTableConstraint.CONSTRAINT_NAME = rc.UNIQUE_CONSTRAINT_NAME");

                foreach (var fk in foreignKeys)
                {
                    var keyColumnsCSV = string.Join(",",
                        keyColumnUsage.Where(c => c.CONSTRAINT_NAME == fk.CONSTRAINT_NAME)
                            .OrderBy(c => c.ORDINAL_POSITION).Select(c => c.COLUMN_NAME));
                    var primaryKeyColumns = indexColumns.Where(ic => ic.IndexName == fk.PrimaryKeyConstraintName);

                    var constraintColumnsCSV = string.Join(",", primaryKeyColumns.Select(c => c.ColumnName));

                    var joinedToTable = primaryKeyColumns.First().TableName;

                    string fkSQL = string.Format(@"ALTER TABLE {0}
                                                   ADD CONSTRAINT {1} FOREIGN KEY ({2})
                                                      REFERENCES {3} ({4}) MATCH SIMPLE
                                                      ON UPDATE NO ACTION ON DELETE NO ACTION;",
                        fk.TABLE_NAME.ToLower(), fk.CONSTRAINT_NAME.ToString().ToLower(),
                        keyColumnsCSV, joinedToTable.ToLower(), constraintColumnsCSV);
                    sql.AppendLine(fkSQL);
                }

                foreach (var index in indexColumns.Where(ic => !ic.is_primary_key).GroupBy(g => g.IndexName))
                {
                    var indexColumnsInIndex = index.Select(s => new { COLUMN_NAME = s.ColumnName, ORDER = s.ColumnId });
                    var indexColumnCsv = string.Join(",",
                        indexColumnsInIndex.OrderBy(s => s.ORDER).Select(s => s.COLUMN_NAME));
                    var first = index.First();

                    string indexSQL = string.Format(@"
                                                    CREATE INDEX {0}
                                                      ON {1}
                                                      USING btree
                                                      ({2});", first.IndexName.ToLower(), first.TableName.ToLower(),
                        indexColumnCsv.ToLower());
                    sql.AppendLine(indexSQL);
                }
            }

            #endregion

            // OUTPUT SQL FILE AND OPEN
            File.WriteAllText("output.txt", sql.ToString());

            //Process.Start("output.txt");

            #region 执行pgsql脚本

            using (NpgsqlConnection psqlConnection = new NpgsqlConnection(npgsqlConnectionString))
            {
                try
                {
                    var executeFlag = psqlConnection.Execute(sql.ToString());
                    MessageBox.Show(executeFlag == -1 ? "执行成功" : "执行失败");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    MessageBox.Show(e.Message);
                }
            }

            #endregion
        }

        public static void ConvertDatatype(dynamic column, StringBuilder sql)
        {
            if (column.DATA_TYPE == "uniqueidentifier")
            {
                sql.Append("uuid");
            }
            else if (column.DATA_TYPE == "datetime" || column.DATA_TYPE == "datetime2")
            {
                sql.Append("timestamp");
            }
            else if (column.DATA_TYPE == "nvarchar" || column.DATA_TYPE == "varchar")
            {
                sql.Append("text");
            }
            else if (column.DATA_TYPE == "datetimeoffset" || column.DATA_TYPE == "smalldatetime")
            {
                sql.Append("timestamp");
            }
            else if (column.DATA_TYPE == "bit")
            {
                sql.Append("boolean");
            }
            else if (column.DATA_TYPE == "bigint")
            {
                sql.Append("bigint");
            }
            else if (column.DATA_TYPE == "date")
            {
                sql.Append("date");
            }
            else if (column.DATA_TYPE == "float")
            {
                sql.Append("double precision");
            }
            else if (column.DATA_TYPE == "real")
            {
                sql.Append("real");
            }
            else if (column.DATA_TYPE == "xml")
            {
                sql.Append("xml");
            }
            else
            {
                sql.Append(column.DATA_TYPE);
            }
        }
    }
}