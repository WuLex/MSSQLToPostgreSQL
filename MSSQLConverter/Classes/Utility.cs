using System;

namespace MSSQLConverter.Classes
{
	/// <summary>
	/// Description of Utility.
	/// </summary>
	public static class Utility
	{
		public static Settings ConversionSettings =	new Settings();
		public const string _MAPPINGDT_NAME="typesmap";
		public const string _MAPPINGDS_NAME="mapDS";
		public const string _MAPPING_FILENAME="typesmap.xml";
		
		
		public enum SQLServerType  {
			MSSQL,MySQL,PostgreSQL,Firebird
		};
	}
}
