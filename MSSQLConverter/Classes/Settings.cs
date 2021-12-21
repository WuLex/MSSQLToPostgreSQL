using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MSSQLConverter.Classes
{
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public class Settings
    {
        public Settings()
        {
        }

        private bool m_ConverTables;
        private bool m_ConvertViews;
        private bool m_ConvertTriggers;
        private bool m_ConvertStoredProcedures;
        private bool m_ConvertFunctions;

        private bool m_ConvertUnknown;

        [Category("SQL 对象")]
        [Description("将 SQL Server 表转换为 PostgreSQL")]
        [DisplayName("转换表")]
        public bool ConvertTables
        {
            get { return m_ConverTables; }
            set { m_ConverTables = value; }
        }

        [Category("SQL 对象")]
        [Description("将 SQL Server 视图转换为 PostgreSQL")]
        [DisplayName("转换视图")]
        public bool ConvertViews
        {
            get { return m_ConvertViews; }
            set { m_ConvertViews = value; }
        }

        [Category("SQL 对象")]
        [Description("将 SQL Server 触发器转换为 PostgreSQL")]
        [DisplayName("转换触发器")]
        public bool ConvertTriggers
        {
            get { return m_ConvertTriggers; }
            set { m_ConvertTriggers = value; }
        }

        [Category("SQL 对象")]
        [Description("将 SQL Server 存储过程转换为 PostgreSQL")]
        [DisplayName("转换存储过程")]
        public bool ConvertStoredProcedures
        {
            get { return m_ConvertStoredProcedures; }
            set { m_ConvertStoredProcedures = value; }
        }

        [Category("SQL 对象")]
        [Description("将 SQL Server 函数转换为 PostgreSQL")]
        [DisplayName("转换函数")]
        public bool ConvertFunctions
        {
            get { return m_ConvertFunctions; }
            set { m_ConvertFunctions = value; }
        }

        [Category("SQL 最后待定组")]
        [Description("******************************")]
        [DisplayName("转换*****")]
        public bool ConvertDaiding
        {
            get { return m_ConvertUnknown; }
            set { m_ConvertUnknown = value; }
        }
    }
}