using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SqlServer2PostgreSQL
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ToolForm : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtDateFormat = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtDelimeter = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtSftpPassword = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtSftpUserName = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtSftpHost = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtPGPassword = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtPGUserName = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtPGDatabase = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.txtPGServer = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPostgreSQL = new System.Windows.Forms.CheckBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSFTP = new System.Windows.Forms.CheckBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsspgTables = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvTables = new System.Windows.Forms.ListView();
            this.colTableName = new System.Windows.Forms.ColumnHeader();
            this.colRecordCount = new System.Windows.Forms.ColumnHeader();
            this.colExport = new System.Windows.Forms.ColumnHeader();
            this.colSftp = new System.Windows.Forms.ColumnHeader();
            this.colPGCopy = new System.Windows.Forms.ColumnHeader();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvScript = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.tpOuput = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmdCreateTable = new System.Windows.Forms.Button();
            this.HelpProvider1 = new System.Windows.Forms.HelpProvider();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.tpOuput.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(8, 8);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(968, 540);
            this.txtOutput.TabIndex = 15;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(301, 415);
            this.cmdConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(363, 31);
            this.cmdConnect.TabIndex = 22;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(103, 151);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(127, 27);
            this.txtPassword.TabIndex = 21;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(22, 155);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(78, 20);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(103, 112);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(127, 27);
            this.txtUserName.TabIndex = 19;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 116);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(89, 20);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "User Name";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(103, 73);
            this.txtDataBase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(127, 27);
            this.txtDataBase.TabIndex = 17;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(24, 77);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 20);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "DataBase";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(103, 35);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(127, 27);
            this.txtServer.TabIndex = 15;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(45, 39);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 20);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Server";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(315, 109);
            this.btnFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(35, 31);
            this.btnFolder.TabIndex = 30;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFolder.Enabled = false;
            this.txtFolder.Location = new System.Drawing.Point(121, 109);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(185, 27);
            this.txtFolder.TabIndex = 29;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(21, 115);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(112, 20);
            this.Label9.TabIndex = 28;
            this.Label9.Text = "Output Folder";
            // 
            // txtDateFormat
            // 
            this.txtDateFormat.Location = new System.Drawing.Point(121, 72);
            this.txtDateFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDateFormat.Name = "txtDateFormat";
            this.txtDateFormat.Size = new System.Drawing.Size(185, 27);
            this.txtDateFormat.TabIndex = 27;
            this.txtDateFormat.Text = "yyyy-MM-dd HH:mm:ss";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(21, 76);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(99, 20);
            this.Label7.TabIndex = 26;
            this.Label7.Text = "Date Format";
            // 
            // txtDelimeter
            // 
            this.txtDelimeter.Location = new System.Drawing.Point(121, 33);
            this.txtDelimeter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDelimeter.MaxLength = 1;
            this.txtDelimeter.Name = "txtDelimeter";
            this.txtDelimeter.Size = new System.Drawing.Size(27, 27);
            this.txtDelimeter.TabIndex = 25;
            this.txtDelimeter.Text = "~";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(39, 37);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(81, 20);
            this.Label6.TabIndex = 24;
            this.Label6.Text = "Delimeter";
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.Location = new System.Drawing.Point(111, 149);
            this.txtTargetFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(238, 27);
            this.txtTargetFolder.TabIndex = 30;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(6, 153);
            this.Label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(108, 20);
            this.Label13.TabIndex = 29;
            this.Label13.Text = "Target Folder";
            // 
            // txtSftpPassword
            // 
            this.txtSftpPassword.Location = new System.Drawing.Point(111, 111);
            this.txtSftpPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSftpPassword.Name = "txtSftpPassword";
            this.txtSftpPassword.PasswordChar = '*';
            this.txtSftpPassword.Size = new System.Drawing.Size(127, 27);
            this.txtSftpPassword.TabIndex = 27;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(30, 115);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(78, 20);
            this.Label10.TabIndex = 26;
            this.Label10.Text = "Password";
            // 
            // txtSftpUserName
            // 
            this.txtSftpUserName.Location = new System.Drawing.Point(111, 72);
            this.txtSftpUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSftpUserName.Name = "txtSftpUserName";
            this.txtSftpUserName.Size = new System.Drawing.Size(127, 27);
            this.txtSftpUserName.TabIndex = 25;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(19, 76);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(89, 20);
            this.Label11.TabIndex = 24;
            this.Label11.Text = "User Name";
            // 
            // txtSftpHost
            // 
            this.txtSftpHost.Location = new System.Drawing.Point(111, 35);
            this.txtSftpHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSftpHost.Name = "txtSftpHost";
            this.txtSftpHost.Size = new System.Drawing.Size(127, 27);
            this.txtSftpHost.TabIndex = 23;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(53, 39);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(56, 20);
            this.Label12.TabIndex = 22;
            this.Label12.Text = "Server";
            // 
            // txtPGPassword
            // 
            this.txtPGPassword.Location = new System.Drawing.Point(103, 151);
            this.txtPGPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPGPassword.Name = "txtPGPassword";
            this.txtPGPassword.PasswordChar = '*';
            this.txtPGPassword.Size = new System.Drawing.Size(127, 27);
            this.txtPGPassword.TabIndex = 30;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(22, 155);
            this.Label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(78, 20);
            this.Label14.TabIndex = 29;
            this.Label14.Text = "Password";
            // 
            // txtPGUserName
            // 
            this.txtPGUserName.Location = new System.Drawing.Point(103, 112);
            this.txtPGUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPGUserName.Name = "txtPGUserName";
            this.txtPGUserName.Size = new System.Drawing.Size(127, 27);
            this.txtPGUserName.TabIndex = 28;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(12, 116);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(89, 20);
            this.Label15.TabIndex = 27;
            this.Label15.Text = "User Name";
            // 
            // txtPGDatabase
            // 
            this.txtPGDatabase.Location = new System.Drawing.Point(103, 73);
            this.txtPGDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPGDatabase.Name = "txtPGDatabase";
            this.txtPGDatabase.Size = new System.Drawing.Size(127, 27);
            this.txtPGDatabase.TabIndex = 26;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(24, 77);
            this.Label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(75, 20);
            this.Label16.TabIndex = 25;
            this.Label16.Text = "DataBase";
            // 
            // txtPGServer
            // 
            this.txtPGServer.Location = new System.Drawing.Point(103, 35);
            this.txtPGServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPGServer.Name = "txtPGServer";
            this.txtPGServer.Size = new System.Drawing.Size(127, 27);
            this.txtPGServer.TabIndex = 24;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(45, 39);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(56, 20);
            this.Label17.TabIndex = 23;
            this.Label17.Text = "Server";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtDataBase);
            this.GroupBox1.Controls.Add(this.txtPassword);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtServer);
            this.GroupBox1.Controls.Add(this.txtUserName);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Location = new System.Drawing.Point(19, 19);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Size = new System.Drawing.Size(251, 203);
            this.GroupBox1.TabIndex = 26;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "SQL Server Settings";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.chkPostgreSQL);
            this.GroupBox2.Controls.Add(this.txtPGServer);
            this.GroupBox2.Controls.Add(this.txtPGPassword);
            this.GroupBox2.Controls.Add(this.Label17);
            this.GroupBox2.Controls.Add(this.Label14);
            this.GroupBox2.Controls.Add(this.Label16);
            this.GroupBox2.Controls.Add(this.txtPGUserName);
            this.GroupBox2.Controls.Add(this.txtPGDatabase);
            this.GroupBox2.Controls.Add(this.Label15);
            this.GroupBox2.Location = new System.Drawing.Point(19, 243);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox2.Size = new System.Drawing.Size(249, 203);
            this.GroupBox2.TabIndex = 27;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "PostgreSQL Settings";
            // 
            // chkPostgreSQL
            // 
            this.chkPostgreSQL.AutoSize = true;
            this.chkPostgreSQL.Checked = true;
            this.chkPostgreSQL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPostgreSQL.Location = new System.Drawing.Point(213, 4);
            this.chkPostgreSQL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPostgreSQL.Name = "chkPostgreSQL";
            this.chkPostgreSQL.Size = new System.Drawing.Size(18, 17);
            this.chkPostgreSQL.TabIndex = 31;
            this.chkPostgreSQL.UseVisualStyleBackColor = true;
            this.chkPostgreSQL.CheckedChanged += new System.EventHandler(this.chkPostgreSQL_CheckedChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.chkSFTP);
            this.GroupBox3.Controls.Add(this.txtTargetFolder);
            this.GroupBox3.Controls.Add(this.txtSftpUserName);
            this.GroupBox3.Controls.Add(this.Label13);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Controls.Add(this.txtSftpHost);
            this.GroupBox3.Controls.Add(this.txtSftpPassword);
            this.GroupBox3.Controls.Add(this.Label11);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Location = new System.Drawing.Point(301, 19);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox3.Size = new System.Drawing.Size(363, 203);
            this.GroupBox3.TabIndex = 28;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "SFTP Settings";
            // 
            // chkSFTP
            // 
            this.chkSFTP.AutoSize = true;
            this.chkSFTP.Checked = true;
            this.chkSFTP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSFTP.Location = new System.Drawing.Point(330, 4);
            this.chkSFTP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSFTP.Name = "chkSFTP";
            this.chkSFTP.Size = new System.Drawing.Size(18, 17);
            this.chkSFTP.TabIndex = 31;
            this.chkSFTP.UseVisualStyleBackColor = true;
            this.chkSFTP.CheckedChanged += new System.EventHandler(this.chkSFTP_CheckedChanged);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnFolder);
            this.GroupBox4.Controls.Add(this.txtDateFormat);
            this.GroupBox4.Controls.Add(this.txtFolder);
            this.GroupBox4.Controls.Add(this.Label6);
            this.GroupBox4.Controls.Add(this.Label9);
            this.GroupBox4.Controls.Add(this.txtDelimeter);
            this.GroupBox4.Controls.Add(this.Label7);
            this.GroupBox4.Location = new System.Drawing.Point(301, 243);
            this.GroupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox4.Size = new System.Drawing.Size(363, 159);
            this.GroupBox4.TabIndex = 29;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Export Settings";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsspgTables,
            this.tsslblStatus});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 760);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(1655, 27);
            this.StatusStrip1.TabIndex = 34;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // tsspgTables
            // 
            this.tsspgTables.Name = "tsspgTables";
            this.tsspgTables.Size = new System.Drawing.Size(257, 19);
            // 
            // tsslblStatus
            // 
            this.tsslblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslblStatus.Name = "tsslblStatus";
            this.tsslblStatus.Size = new System.Drawing.Size(54, 21);
            this.tsslblStatus.Text = "Status";
            // 
            // lvTables
            // 
            this.lvTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTableName,
            this.colRecordCount,
            this.colExport,
            this.colSftp,
            this.colPGCopy});
            this.lvTables.FullRowSelect = true;
            this.lvTables.GridLines = true;
            this.lvTables.Location = new System.Drawing.Point(15, 16);
            this.lvTables.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(630, 555);
            this.lvTables.TabIndex = 35;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            this.lvTables.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvTables_ColumnClick);
            // 
            // colTableName
            // 
            this.colTableName.Text = "Table Name";
            this.colTableName.Width = 230;
            // 
            // colRecordCount
            // 
            this.colRecordCount.Text = "Record Count";
            this.colRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRecordCount.Width = 90;
            // 
            // colExport
            // 
            this.colExport.Tag = "Export";
            this.colExport.Text = "Export";
            this.colExport.Width = 50;
            // 
            // colSftp
            // 
            this.colSftp.Tag = "SFTP";
            this.colSftp.Text = "SFTP";
            this.colSftp.Width = 40;
            // 
            // colPGCopy
            // 
            this.colPGCopy.Tag = "PostgreSQL Copy";
            this.colPGCopy.Text = "Copy";
            this.colPGCopy.Width = 40;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpSettings);
            this.tabControl.Controls.Add(this.tpOuput);
            this.tabControl.Location = new System.Drawing.Point(654, 16);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(995, 723);
            this.tabControl.TabIndex = 36;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.GroupBox5);
            this.tpSettings.Controls.Add(this.GroupBox3);
            this.tpSettings.Controls.Add(this.cmdConnect);
            this.tpSettings.Controls.Add(this.GroupBox4);
            this.tpSettings.Controls.Add(this.GroupBox2);
            this.tpSettings.Controls.Add(this.GroupBox1);
            this.tpSettings.Location = new System.Drawing.Point(4, 29);
            this.tpSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpSettings.Size = new System.Drawing.Size(987, 690);
            this.tpSettings.TabIndex = 0;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.btnAdd);
            this.GroupBox5.Controls.Add(this.lvScript);
            this.GroupBox5.Controls.Add(this.txtScript);
            this.GroupBox5.Controls.Add(this.Label5);
            this.GroupBox5.Location = new System.Drawing.Point(21, 461);
            this.GroupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox5.Size = new System.Drawing.Size(643, 216);
            this.GroupBox5.TabIndex = 32;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Post Execute";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(598, 28);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 31);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvScript
            // 
            this.lvScript.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lvScript.FullRowSelect = true;
            this.lvScript.GridLines = true;
            this.lvScript.Location = new System.Drawing.Point(9, 73);
            this.lvScript.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvScript.Name = "lvScript";
            this.lvScript.Size = new System.Drawing.Size(621, 133);
            this.lvScript.TabIndex = 39;
            this.lvScript.UseCompatibleStateImageBehavior = false;
            this.lvScript.View = System.Windows.Forms.View.Details;
            this.lvScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvScript_KeyDown);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Script";
            this.ColumnHeader1.Width = 350;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Status";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader2.Width = 90;
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(66, 20);
            this.txtScript.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(523, 44);
            this.txtScript.TabIndex = 24;
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            this.txtScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScript_KeyDown);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(10, 32);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(52, 20);
            this.Label5.TabIndex = 23;
            this.Label5.Text = "Script";
            // 
            // tpOuput
            // 
            this.tpOuput.Controls.Add(this.txtOutput);
            this.tpOuput.Location = new System.Drawing.Point(4, 29);
            this.tpOuput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpOuput.Name = "tpOuput";
            this.tpOuput.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpOuput.Size = new System.Drawing.Size(987, 690);
            this.tpOuput.TabIndex = 1;
            this.tpOuput.Text = "Output";
            this.tpOuput.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(332, 580);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(315, 31);
            this.btnExport.TabIndex = 37;
            this.btnExport.Text = "Start Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmdCreateTable
            // 
            this.cmdCreateTable.Location = new System.Drawing.Point(15, 580);
            this.cmdCreateTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdCreateTable.Name = "cmdCreateTable";
            this.cmdCreateTable.Size = new System.Drawing.Size(315, 31);
            this.cmdCreateTable.TabIndex = 38;
            this.cmdCreateTable.Text = "Create Table";
            this.cmdCreateTable.UseVisualStyleBackColor = true;
            this.cmdCreateTable.Click += new System.EventHandler(this.cmdCreateTable_Click);
            // 
            // HelpProvider1
            // 
            this.HelpProvider1.HelpNamespace = "D:\\Projeler\\KASKI\\Aktarim\\format_dosyasi_hazirla\\Help\\SQL Server to PostgreSQL Da" +
    "ta Transfer Documentation.htm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1655, 787);
            this.Controls.Add(this.cmdCreateTable);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lvTables);
            this.Controls.Add(this.StatusStrip1);
            this.HelpButton = true;
            this.HelpProvider1.SetHelpKeyword(this, "SQL Server to PostgreSQL Data Transfer Documentation.htm");
            this.HelpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.HelpProvider1.SetShowHelp(this, true);
            this.Text = "SQL Server to PostgreSQL";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.tpOuput.ResumeLayout(false);
            this.tpOuput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal TextBox txtOutput;
        internal FolderBrowserDialog FolderBrowserDialog1;
        internal Button cmdConnect;
        internal TextBox txtPassword;
        internal Label Label4;
        internal TextBox txtUserName;
        internal Label Label3;
        internal TextBox txtDataBase;
        internal Label Label2;
        internal TextBox txtServer;
        internal Label Label1;
        internal Button btnFolder;
        internal TextBox txtFolder;
        internal Label Label9;
        internal TextBox txtDateFormat;
        internal Label Label7;
        internal TextBox txtDelimeter;
        internal Label Label6;
        internal TextBox txtSftpPassword;
        internal Label Label10;
        internal TextBox txtSftpUserName;
        internal Label Label11;
        internal TextBox txtSftpHost;
        internal Label Label12;
        internal TextBox txtTargetFolder;
        internal Label Label13;
        internal TextBox txtPGPassword;
        internal Label Label14;
        internal TextBox txtPGUserName;
        internal Label Label15;
        internal TextBox txtPGDatabase;
        internal Label Label16;
        internal TextBox txtPGServer;
        internal Label Label17;
        internal GroupBox GroupBox1;
        internal GroupBox GroupBox2;
        internal GroupBox GroupBox3;
        internal GroupBox GroupBox4;
        internal StatusStrip StatusStrip1;
        internal ToolStripProgressBar tsspgTables;
        internal ToolStripStatusLabel tsslblStatus;
        internal ListView lvTables;
        internal ColumnHeader colTableName;
        internal ColumnHeader colExport;
        internal ColumnHeader colSftp;
        internal ColumnHeader colPGCopy;
        internal TabControl tabControl;
        internal TabPage tpSettings;
        internal TabPage tpOuput;
        internal Button btnExport;
        internal ColumnHeader colRecordCount;
        internal Button cmdCreateTable;
        internal CheckBox chkPostgreSQL;
        internal CheckBox chkSFTP;
        internal GroupBox GroupBox5;
        internal Button btnAdd;
        internal ListView lvScript;
        internal ColumnHeader ColumnHeader1;
        internal ColumnHeader ColumnHeader2;
        internal TextBox txtScript;
        internal Label Label5;
        private HelpProvider HelpProvider1;
    }
}