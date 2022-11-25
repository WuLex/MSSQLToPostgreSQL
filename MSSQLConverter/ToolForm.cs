using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Npgsql;
using Renci.SshNet;

namespace SqlServer2PostgreSQL
{
    public partial class ToolForm
    {
        private SqlConnection myConn;
        private SqlCommand cmdTab;
        private SqlDataReader wrTab;
        private SftpClient wSftp;

        public ToolForm()
        {
            InitializeComponent();
        }

        private void MsSQLFormatDosyasiOlustur()
        {
            SqlConnection myConn;
            SqlCommand myCmd;
            SqlDataReader wr;
            string results = "";
            string wpre_str1 = "";
            string wpre_str2 = "";
            string str3 = "";
            string str4 = "";
            int wc = 0;
            string wtable = "";
            string wpre_datatype = "";
            string wpre_delim;


            myConn = new SqlConnection("Server=10.10.111.140;Database=ABYSKASKI;User Id=insoftpro;Password=12345Qwe1");
            // Create a Command object.
            myCmd = myConn.CreateCommand();
            myCmd.CommandText =
                @"select TABLE_NAME, count(*) over (partition by TABLE_NAME) FIELD_COUNT, ORDINAL_POSITION, COLUMN_NAME, COLLATION_NAME, DATA_TYPE, 
                                    COALESCE (CHARACTER_OCTET_LENGTH, coalesce((NUMERIC_PRECISION+2) * case DATA_TYPE when 'decimal' then 2 else 1 end,case DATA_TYPE when 'datetime2' then 30 when 'bit' then 1 end )) SIZE
                            from INFORMATION_SCHEMA.COLUMNS c 
                            where exists (select 1 from INFORMATION_SCHEMA.TABLES t where t.TABLE_SCHEMA ='dbo' and t.TABLE_NAME =c.TABLE_NAME and t.TABLE_TYPE ='Base Table')
                            order by TABLE_NAME, ORDINAL_POSITION ";

            // Open the connection.
            myConn.Open();
            wr = myCmd.ExecuteReader();

            // Concatenate the query result into a string.
            while (wr.Read())
            {
                if ((wr["TABLE_NAME"].ToString() ?? "") != (wtable ?? "") & !string.IsNullOrEmpty(wtable))
                {
                    wpre_delim =
                        Conversions.ToString(Operators.ConcatenateObject(
                            Interaction.IIf(wpre_datatype == "nvarchar", @"""\""\r\n", @"""\r\n"), "\""));
                    results = results + wpre_str1 + wpre_delim + "      " + wpre_str2;
                    File.WriteAllText(@"C:\tmp\" + wtable + ".fmt", results);

                    results = "";
                    wtable = wr["TABLE_NAME"].ToString();
                    wc = 0;
                    wpre_str1 = "";
                    wpre_str2 = "";
                    wpre_datatype = "";
                    wpre_delim = "";
                }
                else
                {
                    wtable = wr["TABLE_NAME"].ToString();
                }

                wc = wc + 1;
                if (wc == 1)
                {
                    results = Conversions.ToString(Operators.ConcatenateObject(
                        Operators.ConcatenateObject("14.0" + Constants.vbCrLf,
                            Operators.AddObject(wr.GetInt32(1),
                                Interaction.IIf(wr["DATA_TYPE"].ToString() == "nvarchar", 1, 0))), Constants.vbCrLf));
                    wc = Conversions.ToInteger(Interaction.IIf(wr["DATA_TYPE"].ToString() == "nvarchar", 2, 1));
                }

                if (string.IsNullOrEmpty(wpre_str1) & wr["DATA_TYPE"].ToString() == "nvarchar")
                {
                    results = results +
                              @"1       SQLCHAR             0       0       ""\""""         0     FIRST_QUOTE                                                 Turkish_100_CI_AS" +
                              Constants.vbCrLf;
                }
                else if (!string.IsNullOrEmpty(wpre_str1))
                {
                    wpre_delim = Conversions.ToString(Operators.ConcatenateObject(
                        Interaction.IIf(wpre_datatype == "nvarchar", @"""\""~", "\"~"),
                        Interaction.IIf(wr["DATA_TYPE"].ToString() == "nvarchar", @"\""""", "\"")));
                    results = results + wpre_str1 + wpre_delim + "      " + wpre_str2;
                }

                wpre_str1 = wc.ToString().PadRight(8) + "SQLCHAR             0       " +
                            Interaction.IIf(wr["SIZE"] is DBNull, 1, wr["SIZE"]).ToString().PadRight(8);

                wpre_str2 = Conversions.ToString(Operators.ConcatenateObject(
                    Operators.ConcatenateObject(
                        Operators.ConcatenateObject(wr["ORDINAL_POSITION"].ToString().PadRight(6),
                            wr["COLUMN_NAME"].ToString().PadRight(60)),
                        Interaction.IIf(wr["COLLATION_NAME"] is DBNull, "\"\"", wr["COLLATION_NAME"])),
                    Constants.vbCrLf));

                wpre_datatype = wr["DATA_TYPE"].ToString();
            }

            wpre_delim =
                Conversions.ToString(
                    Operators.ConcatenateObject(Interaction.IIf(wpre_datatype == "nvarchar", @"""\""\r\n", @"""\r\n"),
                        "\""));
            results = results + wpre_str1 + wpre_delim + "      " + wpre_str2;
            File.WriteAllText(@"C:\tmp\" + wtable.ToLower() + ".fmt", results);

            Interaction.MsgBox("Bitti");

            // Close the reader and the database connection.
            wr.Close();
            myConn.Close();
        }

        private string write_data(string pdt, string pdata)
        {
            string wcomma;
            wcomma = Conversions.ToString(
                Interaction.IIf(LikeOperator.LikeString(pdt, "*varchar", CompareMethod.Binary), "\"", ""));
            switch (pdt ?? "")
            {
                case "decimal":
                case "float":
                case "numeric":
                case "real":
                {
                    pdata = pdata.Replace(",", ".");
                    break;
                }
                case "bit":
                {
                    pdata = Conversions.ToString(Interaction.IIf(pdata == "True", "1",
                        Interaction.IIf(pdata == "False", "0", "")));
                    break;
                }
            }

            return Conversions.ToString(Operators.ConcatenateObject(
                Interaction.IIf(string.IsNullOrEmpty(pdata), "", wcomma + Strings.Replace(pdata, "\"", "") + wcomma),
                txtDelimeter.Text));
        }

        private void ExportTable(ListViewItem pItem)
        {
            SqlCommand wSqlCmd;
            SqlDataReader wSqlDR;
            string wfileName;
            var wdef = new ArrayList();
            string wstr;
            string wdata;
            int i, l, wmaxRows = default;
            Task wTask;

            wSqlCmd = myConn.CreateCommand();
            wSqlCmd.CommandText =
                "select ORDINAL_POSITION, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + pItem.Text +
                "' order by ORDINAL_POSITION";
            wSqlDR = wSqlCmd.ExecuteReader();

            i = 0;
            wdef.Clear();
            while (wSqlDR.Read())
            {
                wdef.Add(wSqlDR[1].ToString());
                i = i + 1;
            }

            wSqlDR.Close();

            wSqlCmd = myConn.CreateCommand();
            wSqlCmd.CommandText = "select count(*) from " + pItem.Text;
            wSqlDR = wSqlCmd.ExecuteReader();
            if (wSqlDR.Read())
            {
                wmaxRows = wSqlDR.GetInt32(0);
            }

            wSqlDR.Close();

            wSqlCmd = myConn.CreateCommand();
            wSqlCmd.CommandText = "select * from " + pItem.Text;
            wSqlDR = wSqlCmd.ExecuteReader();

            l = 0;

            wfileName = txtFolder.Text + @"\" + txtDataBase.Text + @"\" +
                        pItem.Text.ToLower(new System.Globalization.CultureInfo("en-US", false)) + ".dat";
            tsslblStatus.Text = pItem.Text + " >> " + wfileName;

            try
            {
                FileSystem.Kill(wfileName);
            }
            catch (Exception ex)
            {
            }

            try
            {
                using (var writer = new StreamWriter(wfileName, true))
                {
                    while (wSqlDR.Read())
                    {
                        wstr = "";
                        for (int j = 0, loopTo = wSqlDR.FieldCount - 1; j <= loopTo; j++)
                        {
                            if (wSqlDR[j] is DBNull)
                            {
                                wdata = "";
                            }
                            else if (LikeOperator.LikeString(wdef[j].ToString(), "date*", CompareMethod.Binary))
                            {
                                wdata = wSqlDR.GetDateTime(j).ToString(txtDateFormat.Text);
                            }
                            else
                            {
                                wdata = wSqlDR[j].ToString();
                            }

                            wstr = wstr + write_data(Conversions.ToString(wdef[j]), wdata);
                        }

                        l = l + 1;
                        writer.WriteLine(wstr.Substring(0, wstr.Length - 1));
                    }
                }

                wSqlDR.Close();

                tsslblStatus.Text = pItem.Text + " >> " + wfileName + " ... " + Strings.Format(wmaxRows, "#,####") +
                                    " / " + Strings.Format(l, "#,###") + " Rows";
                pItem.SubItems[2].Text = "OK";
            }

            catch (Exception ex)
            {
                txtOutput.Text = ex.Message + Constants.vbCrLf + txtOutput.Text;
            }

            try
            {
                wTask = Task.Run(() => SendFile(txtFolder.Text + @"\" + txtDataBase.Text,
                    pItem.Text.ToLower(new System.Globalization.CultureInfo("en-US", false)) + ".dat"));
                wTask.GetAwaiter().OnCompleted(() =>
                    LoadPostgreSQL(pItem.Text.ToLower(new System.Globalization.CultureInfo("en-US", false)),
                        txtTargetFolder.Text + "/" + txtDataBase.Text + "/" +
                        pItem.Text.ToLower(new System.Globalization.CultureInfo("en-US", false)) + ".dat", pItem));
                Application.DoEvents();

                PrintLog(
                    "EXPORT " + pItem.Text.ToLower(new System.Globalization.CultureInfo("en-US", false)) + ".dat >> " +
                    l + " Rows", 1, pItem.Text);
            }
            catch (Exception ex)
            {
                txtOutput.Text = ex.Message + Constants.vbCrLf + txtOutput.Text;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int wCounter;
            NpgsqlConnection wPgCnn;
            NpgsqlCommand wPgCmd;

            if (lvTables.SelectedItems.Count == 0)
            {
                Interaction.MsgBox("Select any table/s for export");
                return;
            }

            wCounter = 0;

            tsspgTables.Minimum = 0;
            tsspgTables.Maximum = lvTables.SelectedItems.Count;
            tsspgTables.Value = 0;

            foreach (ListViewItem items in lvTables.SelectedItems)
            {
                items.SubItems[2].Text = "";
                items.SubItems[3].Text = "";
                items.SubItems[4].Text = "";
            }

            foreach (ListViewItem witem in lvTables.SelectedItems)
            {
                witem.SubItems[2].Text = "...";
                // wTask = Task.Run(Sub() ExportTable(witem))
                ExportTable(witem);
                witem.EnsureVisible();

                wCounter = wCounter + 1;
                tsspgTables.Value = wCounter;
                Application.DoEvents();
            }

            wPgCnn = new NpgsqlConnection();
            wPgCnn.ConnectionString = "SERVER=" + txtPGServer.Text + ";DATABASE=" + txtPGDatabase.Text + ";USER ID=" +
                                      txtPGUserName.Text + ";PASSWORD=" + txtPGPassword.Text + ";PORT=5432";
            wPgCnn.Open();

            foreach (ListViewItem items in lvScript.Items)
            {
                try
                {
                    wPgCmd = new NpgsqlCommand(items.Text, wPgCnn);
                    wPgCmd.ExecuteNonQuery();
                    PrintLog("Script Execute ... ", 1, items.Text);

                    items.SubItems[1].Text = "OK";
                }
                catch (Exception ex)
                {
                    PrintLog("Error", 0, ex.Message);
                }
            }

            wPgCnn.Close();

            tsslblStatus.Text = "Task complated successful.";
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            if (!(myConn == null))
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            NpgsqlConnection wCnnPg;
            ListViewItem wItem;

            // ******** SQL Server Connection  ******************

            lvTables.Items.Clear();

            if (!(myConn == null))
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

            try
            {
                myConn = new SqlConnection("Server=" + txtServer.Text + ";Database=" + txtDataBase.Text + ";User Id=" +
                                           txtUserName.Text + ";Password=" + txtPassword.Text +
                                           ";MultipleActiveResultSets=True");
                myConn.Open();

                cmdTab = myConn.CreateCommand();
                cmdTab.CommandText = @"Select  t.TABLE_NAME, x.RecordCount
                                        from INFORMATION_SCHEMA.TABLES t
                                        left join (SELECT A.Name AS TableName, SUM(B.rows) AS RecordCount
                                                  FROM sys.objects A
                                                  INNER JOIN sys.partitions B ON A.object_id = B.object_id
                                                  WHERE A.type = 'U'
                                                  GROUP BY A.schema_id, A.Name) x on (t.TABLE_NAME=x.TableName)
                                        where t.TABLE_SCHEMA ='dbo' 
                                        and t.TABLE_TYPE ='Base Table' 
                                        Order by x.RecordCount, t.TABLE_NAME";
                wrTab = cmdTab.ExecuteReader();

                while (wrTab.Read())
                {
                    wItem = new ListViewItem(wrTab.GetString(0), 0);
                    wItem.SubItems.Add(wrTab.GetInt64(1).ToString());
                    wItem.SubItems.Add(".");
                    wItem.SubItems.Add(".");
                    wItem.SubItems.Add(".");

                    lvTables.Items.Add(wItem);
                }

                PrintLog("SQL Server connection", 1, "SQL_SERVER");
            }
            catch (SqlException sqlEx)
            {
                PrintLog("SQL Server connection error - " + sqlEx.Message, 0, "SQL_SERVER");
            }
            catch (Exception ex)
            {
                PrintLog("SQL Server - " + ex.Message, 0, "SQL_SERVER");
            }

            // ********** FTP Connection *********
            if (Conversions.ToBoolean(chkSFTP.CheckState))
            {
                try
                {
                    wSftp = new SftpClient(txtSftpHost.Text, txtSftpUserName.Text, txtSftpPassword.Text);
                    wSftp.Connect();
                    PrintLog("Secure connection", 1, "SFTP");
                }
                catch (Exception ex)
                {
                    PrintLog("Secure connection", 0, "SFTP");
                }

                try
                {
                    wSftp.ChangeDirectory(txtTargetFolder.Text);
                    PrintLog("Target folder OK.", 1, "TARGET_FOLDER");
                }
                catch (Exception ex)
                {
                    PrintLog("Target folder does not exist.", 0, "TARGET_FOLDER");
                }
            }

            // ***********  PostgreSQL Connection  *********************
            if (Conversions.ToBoolean(chkPostgreSQL.CheckState))
            {
                try
                {
                    wCnnPg = new NpgsqlConnection();
                    wCnnPg.ConnectionString = "SERVER=" + txtPGServer.Text + ";DATABASE=" + txtPGDatabase.Text +
                                              ";USER ID=" + txtPGUserName.Text + ";PASSWORD=" + txtPGPassword.Text +
                                              ";PORT=5432";
                    wCnnPg.Open();
                    wCnnPg.Close();
                    PrintLog("PostgreSQL Connection", 1, "POSTGRESQL");
                }
                catch (Exception ex)
                {
                    PrintLog("PostgreSQL Connection", 0, "POSTGRESQL");
                }
            }

            if (!Directory.Exists(txtFolder.Text + @"\" + txtDataBase.Text))
            {
                FileSystem.MkDir(txtFolder.Text + @"\" + txtDataBase.Text);
                PrintLog("Output folder created.", 1, "OUTPUT");
            }
            else
            {
                PrintLog("Output folder OK.", 1, "OUTPUT");
            }

            tsslblStatus.Text = "Connection Test Ok ... ";
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(FolderBrowserDialog1.ShowDialog()))
            {
                txtFolder.Text = FolderBrowserDialog1.SelectedPath;
            }
        }

        private void SendFile(string pPath, string pFile)
        {
            if (Conversions.ToBoolean(chkSFTP.CheckState))
            {
                if (wSftp == null)
                {
                    wSftp = new SftpClient(txtSftpHost.Text, txtSftpUserName.Text, txtSftpPassword.Text);
                    wSftp.Connect();
                }

                if (!wSftp.IsConnected)
                {
                    wSftp = new SftpClient(txtSftpHost.Text, txtSftpUserName.Text, txtSftpPassword.Text);
                    wSftp.Connect();
                }

                try
                {
                    wSftp.ChangeDirectory(txtTargetFolder.Text + "/" + txtDataBase.Text);
                }
                catch (Exception ex)
                {
                    try
                    {
                        wSftp.CreateDirectory(txtTargetFolder.Text + "/" + txtDataBase.Text);
                    }
                    catch (Exception ex2)
                    {
                        Interaction.MsgBox(ex2.Message);
                    }

                    Interaction.MsgBox(ex.Message);
                }

                try
                {
                    wSftp.DeleteFile(txtTargetFolder.Text + "/" + txtDataBase.Text + "/" + pFile);
                }
                catch (Exception ex)
                {
                }

                try
                {
                    using (Stream stream = File.OpenRead(pPath + @"\" + pFile))
                    {
                        wSftp.UploadFile(stream, txtTargetFolder.Text + "/" + txtDataBase.Text + "/" + pFile);
                    }
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.Message);
                }

                Application.DoEvents();
            }
        }

        private void LoadPostgreSQL(string pTableName, string pfileName, ListViewItem pItem)
        {
            string wSqlCopy = "";
            string wSqlTruncate;

            if (Conversions.ToBoolean(chkSFTP.CheckState))
            {
                pItem.SubItems[3].Text = "OK";
                PrintLog("UPLOAD " + pfileName, 1, pTableName);
                Application.DoEvents();
            }

            if (Conversions.ToBoolean(chkPostgreSQL.CheckState))
            {
                try
                {
                    using (var connection = new NpgsqlConnection("SERVER=" + txtPGServer.Text + ";DATABASE=" +
                                                                 txtPGDatabase.Text + ";USER ID=" + txtPGUserName.Text +
                                                                 ";PASSWORD=" + txtPGPassword.Text +
                                                                 ";PORT=5432; Timeout=1000; CommandTimeout=10000"))
                    {
                        NpgsqlDataReader dr;
                        var cmd = new NpgsqlCommand(
                            "select 'truncate table '||table_schema||'.'||table_name truncate_sql, " +
                            "'copy '||table_schema||'.'||table_name||' ('||STRING_AGG('\"'||column_name||'\"', ',' ORDER BY ordinal_position)||') FROM ''" +
                            pfileName + "'' WITH DELIMITER ''~'' CSV ENCODING ''UTF-8'' ' wsql " +
                            "from information_schema.columns c " + "where table_schema = '" +
                            txtDataBase.Text.ToLower(new System.Globalization.CultureInfo("en-US", false)) + "' " +
                            "and table_name = '" + pTableName + "' " + "group by table_schema, table_name " +
                            "order by 1", connection);

                        cmd.Connection.Open();
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            wSqlTruncate = dr.GetString(0);
                            wSqlCopy = dr.GetString(1);
                            dr.Close();

                            cmd = new NpgsqlCommand(wSqlTruncate, connection);
                            cmd.ExecuteNonQuery();

                            cmd = new NpgsqlCommand(wSqlCopy, connection);
                            cmd.ExecuteNonQuery();

                            PrintLog("PostgreSQL - " + wSqlCopy, 1, pTableName);
                            pItem.SubItems[4].Text = "OK";
                        }
                        else
                        {
                            PrintLog("PostgreSQL " + pTableName + " not found.", 0, pTableName);
                            pItem.SubItems[4].Text = "FAIL";
                        }
                    }
                }
                catch (Exception ex)
                {
                    PrintLog("PostgreSQL - " + wSqlCopy + Constants.vbCrLf + ex.Message, 0, pTableName);
                    pItem.SubItems[4].Text = "FAIL";
                }

                Application.DoEvents();
            }
        }

        private void lvTables_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvTables.Columns[e.Column].ListView.Sorting = (System.Windows.Forms.SortOrder)Conversions.ToInteger(
                Interaction.IIf(lvTables.Columns[e.Column].ListView.Sorting == System.Windows.Forms.SortOrder.Ascending,
                    System.Windows.Forms.SortOrder.Descending, System.Windows.Forms.SortOrder.Ascending));
        }

        private void PrintLog(string pTopic, int pStatus, string pTableName)
        {
            tabControl.SelectedTab = tpOuput;
            if (LikeOperator.LikeString(pTopic, "Create*", CompareMethod.Binary))
            {
                txtOutput.Text = pTableName + Constants.vbCrLf + txtOutput.Text;
            }
            else
            {
                txtOutput.Text = Conversions.ToString(Operators.ConcatenateObject(
                    Operators.ConcatenateObject(
                        Operators.ConcatenateObject(
                            Operators.ConcatenateObject(
                                Operators.ConcatenateObject(
                                    Operators.ConcatenateObject(
                                        Operators.ConcatenateObject(
                                            DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " - ",
                                            Interaction.IIf(pStatus == 1, "SUCCESS", "FAIL")), " - "), pTableName),
                                " - "), pTopic), Constants.vbCrLf), txtOutput.Text));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void CreateTable(string pTableName, string pScript, NpgsqlConnection PPgCnn)
        {
            NpgsqlCommand wPgCmd;

            wPgCmd = new NpgsqlCommand("CREATE SCHEMA IF NOT EXISTS " + txtDataBase.Text, PPgCnn);
            wPgCmd.ExecuteNonQuery();

            wPgCmd = new NpgsqlCommand("DROP TABLE IF EXISTS " + txtDataBase.Text + "." + pTableName, PPgCnn);
            wPgCmd.ExecuteNonQuery();

            wPgCmd = new NpgsqlCommand(pScript, PPgCnn);
            wPgCmd.ExecuteNonQuery();
            PrintLog("Create Table", 1, pScript);
        }

        private void CreateConstraint(string pTableName, string pScript, NpgsqlConnection PPgCnn, bool pIsExecute)
        {
            NpgsqlCommand wPgCmd;
            if (pIsExecute)
            {
                wPgCmd = new NpgsqlCommand(pScript, PPgCnn);
                wPgCmd.ExecuteNonQuery();
            }

            PrintLog("Create Table Constraint", 1, pScript);
        }

        private void cmdCreateTable_Click(object sender, EventArgs e)
        {
            SqlCommand wSqlCmd;
            SqlDataReader wSqlDR;
            NpgsqlConnection wPgCnn;
            string wSqlCreateConstraint = "";
            string wTableName = "";
            string wCreateScript = "";
            string wTables = "";
            int wCounter = 0;
            bool wCreateConstraint = false;

            if (lvTables.SelectedItems.Count == 0)
            {
                Interaction.MsgBox("Select any table/s for create");
                return;
            }

            wPgCnn = new NpgsqlConnection();
            wPgCnn.ConnectionString = "SERVER=" + txtPGServer.Text + ";DATABASE=" + txtPGDatabase.Text + ";USER ID=" +
                                      txtPGUserName.Text + ";PASSWORD=" + txtPGPassword.Text + ";PORT=5432";
            wPgCnn.Open();

            foreach (ListViewItem witem in lvTables.SelectedItems)
                wTables = wTables + "','" + witem.Text;
            wTables = wTables.Substring(2) + "'";

            try
            {
                wSqlCmd = myConn.CreateCommand();
                wSqlCmd.CommandText =
                    @"select  TABLE_NAME, case when Lower(COLUMN_NAME)='not' then '""not""' else COLUMN_NAME end + ' ' + DATA_TYPE +' ' + case when DATA_TYPE in ('varchar','char', 'decimal','numeric') then data_size else '' end + ' ' + case when IS_NULLABLE='NO' then 'not null' else '' end COLUMN_DEF
      from (select TABLE_NAME, ORDINAL_POSITION, replace(COLUMN_NAME,' ','_') COLUMN_NAME, IS_NULLABLE, 
              case when DATA_TYPE in ('nvarchar','uniqueidentifier','varchar') then case when CHARACTER_MAXIMUM_LENGTH>2000 or CHARACTER_MAXIMUM_LENGTH=-1 then 'text' else 'varchar' end
                   when DATA_TYPE in ('bit','tinyint') then 'smallint'
                   when DATA_TYPE in ('datetime2', 'datetime', 'date','smalldatetime') then 'timestamp'
                   when DATA_TYPE in ('binary','varbinary','image','rowversion') then 'bytea'
                   when DATA_TYPE in ('ntext', 'sql_variant') then 'text'
                   when DATA_TYPE in ('nchar') then 'char'
                   when DATA_TYPE in ('smallmoney') then 'money'
                   else DATA_TYPE 
              end DATA_TYPE,
              '(' + convert(varchar, coalesce(COALESCE (case when CHARACTER_MAXIMUM_LENGTH=-1 then 4000 else CHARACTER_MAXIMUM_LENGTH end, NUMERIC_PRECISION),100)) + case when NUMERIC_SCALE is not null then ',' + convert(varchar, NUMERIC_SCALE) + ')' else ')' end data_size
            from INFORMATION_SCHEMA.COLUMNS 
            where TABLE_NAME in (" + wTables + @")
      ) x 
order by TABLE_NAME, ORDINAL_POSITION";
                wSqlDR = wSqlCmd.ExecuteReader();

                tsspgTables.Minimum = 0;
                tsspgTables.Maximum = lvTables.SelectedItems.Count;
                tsspgTables.Value = 0;

                while (wSqlDR.Read())
                {
                    if (string.IsNullOrEmpty(wTableName))
                    {
                        wCreateScript = "create table " + txtDataBase.Text + "." + wSqlDR.GetString(0) + " (" +
                                        Constants.vbCrLf;
                    }
                    else if ((wTableName ?? "") != (wSqlDR.GetString(0) ?? ""))
                    {
                        CreateTable(wTableName, wCreateScript.Substring(0, wCreateScript.Length - 3) + ");", wPgCnn);

                        wCounter = wCounter + 1;
                        tsspgTables.Value = wCounter;
                        tsslblStatus.Text = wTableName + " Table created ...";
                        Application.DoEvents();

                        wCreateScript = "create table " + txtDataBase.Text + "." + wSqlDR.GetString(0) + " (" +
                                        Constants.vbCrLf;
                    }

                    wCreateScript = wCreateScript + Constants.vbTab + wSqlDR.GetString(1) + "," + Constants.vbCrLf;
                    wTableName = wSqlDR.GetString(0);
                }

                CreateTable(wTableName, wCreateScript.Substring(0, wCreateScript.Length - 3) + ");", wPgCnn);

                wCounter = wCounter + 1;
                tsspgTables.Value = wCounter;

                PrintLog("-- Create Table" + Constants.vbCrLf, 1, wCounter + " tables was created");

                wSqlDR.Close();

                // **************************************
                // Create table constraints
                // **************************************

                if (Interaction.MsgBox("Is create Primary Key constraints?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    wCreateConstraint = true;
                }


                wSqlCmd = myConn.CreateCommand();
                wSqlCmd.CommandText =
                    @"select tc.TABLE_NAME, tc.CONSTRAINT_NAME, CONSTRAINT_TYPE, replace(ccu.COLUMN_NAME,' ','_') COLUMN_NAME
from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc 
join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu on (tc.CONSTRAINT_NAME=ccu.CONSTRAINT_NAME and tc.TABLE_NAME=ccu.TABLE_NAME and tc.TABLE_SCHEMA=ccu.TABLE_SCHEMA)
where CONSTRAINT_TYPE in ('PRIMARY KEY', 'UNIQUE')
and tc.TABLE_NAME in (" + wTables + @")
order by tc.TABLE_NAME, tc.CONSTRAINT_NAME";

                wSqlDR = wSqlCmd.ExecuteReader();

                tsspgTables.Value = 0;
                wCreateScript = "";
                wTableName = "";
                wCounter = 0;

                while (wSqlDR.Read())
                {
                    if (string.IsNullOrEmpty(wTableName))
                    {
                        wCreateScript = "alter table " + txtDataBase.Text + "." + wSqlDR.GetString(0) +
                                        " add constraint " + wSqlDR.GetString(1) + " " + wSqlDR.GetString(2) + " (";
                    }
                    else if ((wTableName ?? "") != (wSqlDR.GetString(0) ?? ""))
                    {
                        CreateConstraint(wTableName, wCreateScript.Substring(0, wCreateScript.Length - 1) + ");",
                            wPgCnn, wCreateConstraint);

                        wCounter = wCounter + 1;
                        tsspgTables.Value = wCounter;
                        tsslblStatus.Text = wTableName + " Table constraint created ...";
                        Application.DoEvents();

                        wCreateScript = "alter table " + txtDataBase.Text + "." + wSqlDR.GetString(0) +
                                        " add constraint " + wSqlDR.GetString(1) + " " + wSqlDR.GetString(2) + " (";
                    }

                    wCreateScript = wCreateScript + wSqlDR.GetString(3) + ",";
                    wTableName = wSqlDR.GetString(0);
                }

                CreateConstraint(wTableName, wCreateScript.Substring(0, wCreateScript.Length - 1) + ");", wPgCnn,
                    wCreateConstraint);

                wCounter = wCounter + 1;
                tsspgTables.Value = tsspgTables.Maximum;

                PrintLog("-- Create Table Constraint" + Constants.vbCrLf, 1,
                    Conversions.ToString(Operators.ConcatenateObject(wCounter + " tables constraint was ",
                        Interaction.IIf(wCreateConstraint, "created", "prepared"))));
                wSqlDR.Close();

                tsslblStatus.Text = tsspgTables.Value + " Table/s created ...";
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }

        private void chkPostgreSQL_CheckedChanged(object sender, EventArgs e)
        {
            txtPGDatabase.Enabled = Conversions.ToBoolean(chkPostgreSQL.CheckState);
            txtPGPassword.Enabled = Conversions.ToBoolean(chkPostgreSQL.CheckState);
            txtPGServer.Enabled = Conversions.ToBoolean(chkPostgreSQL.CheckState);
            txtPGUserName.Enabled = Conversions.ToBoolean(chkPostgreSQL.CheckState);
        }

        private void chkSFTP_CheckedChanged(object sender, EventArgs e)
        {
            txtSftpHost.Enabled = Conversions.ToBoolean(chkSFTP.CheckState);
            txtSftpPassword.Enabled = Conversions.ToBoolean(chkSFTP.CheckState);
            txtSftpUserName.Enabled = Conversions.ToBoolean(chkSFTP.CheckState);
            txtTargetFolder.Enabled = Conversions.ToBoolean(chkSFTP.CheckState);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Width < 1300)
            {
                Width = 1300;
            }

            if (Height < 530)
            {
                Height = 530;
            }

            tabControl.Width = Width - tabControl.Left - 25;
            tabControl.Height = Height - tabControl.Top - 70;
            txtOutput.Width = tabControl.Width - 20;
            txtOutput.Height = tabControl.Height - 40;
            btnExport.Top = Height - 95;
            cmdCreateTable.Top = btnExport.Top;
            lvTables.Height = Height - 110;
        }

        private void AddScript()
        {
            ListViewItem wItem;
            if (!string.IsNullOrEmpty(txtScript.Text))
            {
                foreach (var wScript in txtScript.Text.Split(";"))
                {
                    if (!string.IsNullOrEmpty(Strings.Trim(wScript)))
                    {
                        wItem = new ListViewItem
                        {
                            Text = wScript
                        };
                        wItem.SubItems.Add("");
                        lvScript.Items.Add(wItem);
                    }
                }

                txtScript.Select();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddScript();
        }

        private void lvScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (var item in lvScript.SelectedItems)
                    lvScript.Items.Remove((ListViewItem)item);
            }
        }

        private void txtScript_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddScript();
            }
        }
    }
}