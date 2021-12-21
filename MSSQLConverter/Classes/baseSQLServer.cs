using System;
using System.Data;
using System.Data.SqlClient;

namespace MSSQLConverter.Classes
{
	/// <summary>
	/// Description of baseSQLServer.
	/// </summary>
	public abstract class baseSQLServer
	{
		public enum SQLObjectTypes {
			Table,View,Trigger,StoredProcedure,Function
		};
		
		public baseSQLServer()
		{
		}
		
		public string ServerName { get; set; }
		public string Database { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public Utility.SQLServerType ServerType{ get; set; }
		
		public abstract string GetConnectionString();
		public abstract bool ExecuteNonQuery(string QueryString);
		public abstract DataTable ExecuteQuery(string QueryString);
	}
}
