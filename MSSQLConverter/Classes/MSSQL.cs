﻿using System.Data;
using System.Data.SqlClient;

namespace MSSQLConverter.Classes
{
    /// <summary>
    /// Description of MSSQL.
    /// </summary>
    public class MSSQL : baseSQLServer

    {
        public MSSQL()
        {
        }

        private bool m_sqlAuth = false;

        public bool SQLAuth
        {
            get { return m_sqlAuth; }
            set { m_sqlAuth = value; }
        }

        public override string GetConnectionString()
        {
            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
            con.DataSource = this.ServerName;
            con.InitialCatalog = this.Database;

            if (this.SQLAuth == true)
            {
                con.IntegratedSecurity = false;
                con.UserID = this.Username;
                con.Password = this.Password;
            }
            else
            {
                con.IntegratedSecurity = true;
            }

            return con.ConnectionString;
        }

        public override bool ExecuteNonQuery(string SQLQuery)
        {
            bool result = false;

            if (string.IsNullOrEmpty(SQLQuery))
            {
                return result;
            }

            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand(SQLQuery, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }


        public override DataTable ExecuteQuery(string SQLQuery)
        {
            DataTable result = new DataTable();
            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlDataAdapter cmd = new SqlDataAdapter(SQLQuery, con);

            try
            {
                con.Open();
                cmd.Fill(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return result;
        }
    }
}