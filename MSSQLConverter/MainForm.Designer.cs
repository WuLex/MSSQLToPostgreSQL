namespace MSSQLConverter
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Objects Found");
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SettingspropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PgPorttextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PgPasstextBox = new System.Windows.Forms.TextBox();
            this.PgUsertextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PgDatabasetextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PgServertextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Connectbutton = new System.Windows.Forms.Button();
            this.SQLAuthgroupBox = new System.Windows.Forms.GroupBox();
            this.SQLPasstextBox = new System.Windows.Forms.TextBox();
            this.SQLUsertextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SQLAuthcheckBox = new System.Windows.Forms.CheckBox();
            this.SQLDatabasetextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SQLServertextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MappingsdataGridView = new System.Windows.Forms.DataGridView();
            this.SQLObjtabPage = new System.Windows.Forms.TabPage();
            this.SQLObjectstreeView = new System.Windows.Forms.TreeView();
            this.MainimageList = new System.Windows.Forms.ImageList(this.components);
            this.MainstatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatetoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MaintoolStrip = new System.Windows.Forms.ToolStrip();
            this.ConverttoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveMaptoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ClosetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SQLAuthgroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingsdataGridView)).BeginInit();
            this.SQLObjtabPage.SuspendLayout();
            this.MainstatusStrip.SuspendLayout();
            this.MaintoolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 132);
            this.panel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(393, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(392, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "将Microsoft SQL Server数据库对象和数据转换为 PostgreSQL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 218);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1394, 611);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.SQLObjtabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1394, 611);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SettingspropertyGrid);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1386, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SettingspropertyGrid
            // 
            this.SettingspropertyGrid.Location = new System.Drawing.Point(883, 45);
            this.SettingspropertyGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SettingspropertyGrid.Name = "SettingspropertyGrid";
            this.SettingspropertyGrid.Size = new System.Drawing.Size(486, 375);
            this.SettingspropertyGrid.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.PgPorttextBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.PgDatabasetextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.PgServertextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(458, 35);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(417, 385);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PostgreSQL Server";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 239);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 27);
            this.label10.TabIndex = 8;
            this.label10.Text = "登录信息";
            // 
            // PgPorttextBox
            // 
            this.PgPorttextBox.Location = new System.Drawing.Point(18, 199);
            this.PgPorttextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PgPorttextBox.Name = "PgPorttextBox";
            this.PgPorttextBox.Size = new System.Drawing.Size(104, 34);
            this.PgPorttextBox.TabIndex = 7;
            this.PgPorttextBox.Text = "5432";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 171);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 27);
            this.label9.TabIndex = 6;
            this.label9.Text = "端口";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PgPasstextBox);
            this.groupBox3.Controls.Add(this.PgUsertextBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(18, 260);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(351, 107);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // PgPasstextBox
            // 
            this.PgPasstextBox.Location = new System.Drawing.Point(102, 55);
            this.PgPasstextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PgPasstextBox.Name = "PgPasstextBox";
            this.PgPasstextBox.PasswordChar = '*';
            this.PgPasstextBox.Size = new System.Drawing.Size(238, 34);
            this.PgPasstextBox.TabIndex = 4;
            // 
            // PgUsertextBox
            // 
            this.PgUsertextBox.Location = new System.Drawing.Point(102, 20);
            this.PgUsertextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PgUsertextBox.Name = "PgUsertextBox";
            this.PgUsertextBox.Size = new System.Drawing.Size(238, 34);
            this.PgUsertextBox.TabIndex = 3;
            this.PgUsertextBox.Text = "postgres";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 35);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 35);
            this.label6.TabIndex = 1;
            this.label6.Text = "Username";
            // 
            // PgDatabasetextBox
            // 
            this.PgDatabasetextBox.Location = new System.Drawing.Point(18, 135);
            this.PgDatabasetextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PgDatabasetextBox.Name = "PgDatabasetextBox";
            this.PgDatabasetextBox.Size = new System.Drawing.Size(364, 34);
            this.PgDatabasetextBox.TabIndex = 3;
            this.PgDatabasetextBox.Text = "BlogDB";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 108);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 27);
            this.label7.TabIndex = 2;
            this.label7.Text = "数据库";
            // 
            // PgServertextBox
            // 
            this.PgServertextBox.Location = new System.Drawing.Point(18, 69);
            this.PgServertextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PgServertextBox.Name = "PgServertextBox";
            this.PgServertextBox.Size = new System.Drawing.Size(364, 34);
            this.PgServertextBox.TabIndex = 1;
            this.PgServertextBox.Text = "localhost";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(256, 27);
            this.label8.TabIndex = 0;
            this.label8.Text = "PostgreSQL服务器 名称/IP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Connectbutton);
            this.groupBox1.Controls.Add(this.SQLAuthgroupBox);
            this.groupBox1.Controls.Add(this.SQLAuthcheckBox);
            this.groupBox1.Controls.Add(this.SQLDatabasetextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SQLServertextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(417, 385);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MS SQL Server";
            // 
            // Connectbutton
            // 
            this.Connectbutton.Location = new System.Drawing.Point(18, 331);
            this.Connectbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Connectbutton.Name = "Connectbutton";
            this.Connectbutton.Size = new System.Drawing.Size(366, 35);
            this.Connectbutton.TabIndex = 6;
            this.Connectbutton.Text = "连接和检索SQL对象";
            this.Connectbutton.UseVisualStyleBackColor = true;
            this.Connectbutton.Click += new System.EventHandler(this.ConnectbuttonClick);
            // 
            // SQLAuthgroupBox
            // 
            this.SQLAuthgroupBox.Controls.Add(this.SQLPasstextBox);
            this.SQLAuthgroupBox.Controls.Add(this.SQLUsertextBox);
            this.SQLAuthgroupBox.Controls.Add(this.label4);
            this.SQLAuthgroupBox.Controls.Add(this.label3);
            this.SQLAuthgroupBox.Enabled = false;
            this.SQLAuthgroupBox.Location = new System.Drawing.Point(33, 205);
            this.SQLAuthgroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLAuthgroupBox.Name = "SQLAuthgroupBox";
            this.SQLAuthgroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLAuthgroupBox.Size = new System.Drawing.Size(351, 107);
            this.SQLAuthgroupBox.TabIndex = 5;
            this.SQLAuthgroupBox.TabStop = false;
            // 
            // SQLPasstextBox
            // 
            this.SQLPasstextBox.Location = new System.Drawing.Point(102, 55);
            this.SQLPasstextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLPasstextBox.Name = "SQLPasstextBox";
            this.SQLPasstextBox.PasswordChar = '*';
            this.SQLPasstextBox.Size = new System.Drawing.Size(238, 34);
            this.SQLPasstextBox.TabIndex = 4;
            // 
            // SQLUsertextBox
            // 
            this.SQLUsertextBox.Location = new System.Drawing.Point(102, 20);
            this.SQLUsertextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLUsertextBox.Name = "SQLUsertextBox";
            this.SQLUsertextBox.Size = new System.Drawing.Size(238, 34);
            this.SQLUsertextBox.TabIndex = 3;
            this.SQLUsertextBox.Text = "sa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "Username";
            // 
            // SQLAuthcheckBox
            // 
            this.SQLAuthcheckBox.Location = new System.Drawing.Point(18, 172);
            this.SQLAuthcheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLAuthcheckBox.Name = "SQLAuthcheckBox";
            this.SQLAuthcheckBox.Size = new System.Drawing.Size(366, 37);
            this.SQLAuthcheckBox.TabIndex = 4;
            this.SQLAuthcheckBox.Text = "使用 SQL 身份验证";
            this.SQLAuthcheckBox.UseVisualStyleBackColor = true;
            this.SQLAuthcheckBox.CheckedChanged += new System.EventHandler(this.SQLAuthcheckBoxCheckedChanged);
            // 
            // SQLDatabasetextBox
            // 
            this.SQLDatabasetextBox.Location = new System.Drawing.Point(18, 131);
            this.SQLDatabasetextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLDatabasetextBox.Name = "SQLDatabasetextBox";
            this.SQLDatabasetextBox.Size = new System.Drawing.Size(364, 34);
            this.SQLDatabasetextBox.TabIndex = 3;
            this.SQLDatabasetextBox.Text = "BlogDB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库";
            // 
            // SQLServertextBox
            // 
            this.SQLServertextBox.Location = new System.Drawing.Point(18, 65);
            this.SQLServertextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLServertextBox.Name = "SQLServertextBox";
            this.SQLServertextBox.Size = new System.Drawing.Size(364, 34);
            this.SQLServertextBox.TabIndex = 1;
            this.SQLServertextBox.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Server Instance";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.MappingsdataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1386, 571);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "映射";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MappingsdataGridView
            // 
            this.MappingsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MappingsdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MappingsdataGridView.Location = new System.Drawing.Point(4, 5);
            this.MappingsdataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MappingsdataGridView.Name = "MappingsdataGridView";
            this.MappingsdataGridView.RowHeadersWidth = 51;
            this.MappingsdataGridView.Size = new System.Drawing.Size(1378, 561);
            this.MappingsdataGridView.TabIndex = 0;
            // 
            // SQLObjtabPage
            // 
            this.SQLObjtabPage.Controls.Add(this.SQLObjectstreeView);
            this.SQLObjtabPage.Location = new System.Drawing.Point(4, 36);
            this.SQLObjtabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLObjtabPage.Name = "SQLObjtabPage";
            this.SQLObjtabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLObjtabPage.Size = new System.Drawing.Size(1386, 571);
            this.SQLObjtabPage.TabIndex = 2;
            this.SQLObjtabPage.Text = "选择 SQL 对象";
            this.SQLObjtabPage.UseVisualStyleBackColor = true;
            // 
            // SQLObjectstreeView
            // 
            this.SQLObjectstreeView.CheckBoxes = true;
            this.SQLObjectstreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SQLObjectstreeView.ImageIndex = 0;
            this.SQLObjectstreeView.ImageList = this.MainimageList;
            this.SQLObjectstreeView.Location = new System.Drawing.Point(4, 5);
            this.SQLObjectstreeView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SQLObjectstreeView.Name = "SQLObjectstreeView";
            treeNode2.Name = "RootNode";
            treeNode2.Text = "Objects Found";
            this.SQLObjectstreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.SQLObjectstreeView.SelectedImageIndex = 0;
            this.SQLObjectstreeView.Size = new System.Drawing.Size(1378, 561);
            this.SQLObjectstreeView.TabIndex = 0;
            this.SQLObjectstreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SQLObjectstreeViewAfterSelect);
            // 
            // MainimageList
            // 
            this.MainimageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.MainimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainimageList.ImageStream")));
            this.MainimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MainimageList.Images.SetKeyName(0, "1408922491_database_table.png");
            this.MainimageList.Images.SetKeyName(1, "1408922620_table.png");
            this.MainimageList.Images.SetKeyName(2, "1408930179_show_table_row.png");
            // 
            // MainstatusStrip
            // 
            this.MainstatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainstatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatetoolStripStatusLabel});
            this.MainstatusStrip.Location = new System.Drawing.Point(0, 829);
            this.MainstatusStrip.Name = "MainstatusStrip";
            this.MainstatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.MainstatusStrip.Size = new System.Drawing.Size(1394, 26);
            this.MainstatusStrip.TabIndex = 12;
            this.MainstatusStrip.Text = "statusStrip1";
            // 
            // StatetoolStripStatusLabel
            // 
            this.StatetoolStripStatusLabel.Name = "StatetoolStripStatusLabel";
            this.StatetoolStripStatusLabel.Size = new System.Drawing.Size(39, 20);
            this.StatetoolStripStatusLabel.Text = "准备";
            // 
            // MaintoolStrip
            // 
            this.MaintoolStrip.AutoSize = false;
            this.MaintoolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MaintoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConverttoolStripButton,
            this.toolStripSeparator1,
            this.SaveMaptoolStripButton,
            this.toolStripSeparator2,
            this.ClosetoolStripButton});
            this.MaintoolStrip.Location = new System.Drawing.Point(0, 167);
            this.MaintoolStrip.Name = "MaintoolStrip";
            this.MaintoolStrip.Size = new System.Drawing.Size(1394, 51);
            this.MaintoolStrip.TabIndex = 13;
            this.MaintoolStrip.Text = "toolStrip1";
            // 
            // ConverttoolStripButton
            // 
            this.ConverttoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ConverttoolStripButton.Image")));
            this.ConverttoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ConverttoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConverttoolStripButton.Name = "ConverttoolStripButton";
            this.ConverttoolStripButton.Size = new System.Drawing.Size(104, 48);
            this.ConverttoolStripButton.Text = "&转换数据库";
            this.ConverttoolStripButton.ToolTipText = "&转换";
            this.ConverttoolStripButton.Click += new System.EventHandler(this.ConverttoolStripButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 51);
            // 
            // SaveMaptoolStripButton
            // 
            this.SaveMaptoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveMaptoolStripButton.Image")));
            this.SaveMaptoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveMaptoolStripButton.Name = "SaveMaptoolStripButton";
            this.SaveMaptoolStripButton.Size = new System.Drawing.Size(93, 48);
            this.SaveMaptoolStripButton.Text = "&保存映射";
            this.SaveMaptoolStripButton.Click += new System.EventHandler(this.SaveMaptoolStripButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 51);
            // 
            // ClosetoolStripButton
            // 
            this.ClosetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ClosetoolStripButton.Image")));
            this.ClosetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClosetoolStripButton.Name = "ClosetoolStripButton";
            this.ClosetoolStripButton.Size = new System.Drawing.Size(63, 48);
            this.ClosetoolStripButton.Text = "&关闭";
            this.ClosetoolStripButton.Click += new System.EventHandler(this.ClosetoolStripButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1394, 855);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MaintoolStrip);
            this.Controls.Add(this.MainstatusStrip);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "MSSQL转换工具";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 1394, 855);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SQLAuthgroupBox.ResumeLayout(false);
            this.SQLAuthgroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MappingsdataGridView)).EndInit();
            this.SQLObjtabPage.ResumeLayout(false);
            this.MainstatusStrip.ResumeLayout(false);
            this.MainstatusStrip.PerformLayout();
            this.MaintoolStrip.ResumeLayout(false);
            this.MaintoolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView SQLObjectstreeView;
        private System.Windows.Forms.ImageList MainimageList;
        private System.Windows.Forms.Button Connectbutton;
        private System.Windows.Forms.TabPage SQLObjtabPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton SaveMaptoolStripButton;
        private System.Windows.Forms.DataGridView MappingsdataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton ClosetoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ConverttoolStripButton;
        private System.Windows.Forms.ToolStrip MaintoolStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatetoolStripStatusLabel;
        private System.Windows.Forms.StatusStrip MainstatusStrip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PropertyGrid SettingspropertyGrid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PgServertextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PgDatabasetextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PgUsertextBox;
        private System.Windows.Forms.TextBox PgPasstextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PgPorttextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox SQLAuthcheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SQLUsertextBox;
        private System.Windows.Forms.TextBox SQLPasstextBox;
        private System.Windows.Forms.GroupBox SQLAuthgroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SQLServertextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SQLDatabasetextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
