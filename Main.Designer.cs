namespace xinxingxiang
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmProjectList = new System.Windows.Forms.ToolStripMenuItem();
            this.tmProjectAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tmVipMan = new System.Windows.Forms.ToolStripMenuItem();
            this.tmVipList = new System.Windows.Forms.ToolStripMenuItem();
            this.tmVipAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tlDbBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.plProjectList = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnProjectAdd = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchPro = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgProjectList = new System.Windows.Forms.DataGridView();
            this.dgVipUserList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVipName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSearchVip = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbVipStatus = new System.Windows.Forms.ComboBox();
            this.plVipUserList = new System.Windows.Forms.Panel();
            this.btnVipAdd = new System.Windows.Forms.Button();
            this.btnVipReset = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.plProjectList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVipUserList)).BeginInit();
            this.plVipUserList.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1288, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(424, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(424, 21);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Top;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.RightToLeftAutoMirrorImage = true;
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(424, 21);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "本程序版权归新形象发型设计工作室所有";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.tmVipMan,
            this.tlDbBack,
            this.tmClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1288, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmProjectList,
            this.tmProjectAdd});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItem.Text = "系统管理";
            // 
            // tmProjectList
            // 
            this.tmProjectList.Name = "tmProjectList";
            this.tmProjectList.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.tmProjectList.Size = new System.Drawing.Size(203, 22);
            this.tmProjectList.Text = "项目列表";
            this.tmProjectList.Click += new System.EventHandler(this.tmProjectList_Click);
            // 
            // tmProjectAdd
            // 
            this.tmProjectAdd.Name = "tmProjectAdd";
            this.tmProjectAdd.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.tmProjectAdd.Size = new System.Drawing.Size(203, 22);
            this.tmProjectAdd.Text = "项目添加";
            this.tmProjectAdd.Click += new System.EventHandler(this.tmProjectAdd_Click);
            // 
            // tmVipMan
            // 
            this.tmVipMan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmVipList,
            this.tmVipAdd});
            this.tmVipMan.Name = "tmVipMan";
            this.tmVipMan.Size = new System.Drawing.Size(68, 21);
            this.tmVipMan.Text = "会员管理";
            // 
            // tmVipList
            // 
            this.tmVipList.Name = "tmVipList";
            this.tmVipList.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.tmVipList.Size = new System.Drawing.Size(207, 22);
            this.tmVipList.Text = "会员列表";
            this.tmVipList.Click += new System.EventHandler(this.tmVipList_Click);
            // 
            // tmVipAdd
            // 
            this.tmVipAdd.Name = "tmVipAdd";
            this.tmVipAdd.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.tmVipAdd.Size = new System.Drawing.Size(207, 22);
            this.tmVipAdd.Text = "会员添加";
            this.tmVipAdd.Click += new System.EventHandler(this.tmVipAdd_Click);
            // 
            // tlDbBack
            // 
            this.tlDbBack.Name = "tlDbBack";
            this.tlDbBack.Size = new System.Drawing.Size(80, 21);
            this.tlDbBack.Text = "数据库备份";
            this.tlDbBack.Click += new System.EventHandler(this.tlDbBack_Click);
            // 
            // tmClose
            // 
            this.tmClose.Name = "tmClose";
            this.tmClose.Size = new System.Drawing.Size(44, 21);
            this.tmClose.Text = "退出";
            this.tmClose.Click += new System.EventHandler(this.tmClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem1.Text = "系统管理";
            // 
            // plProjectList
            // 
            this.plProjectList.BackColor = System.Drawing.Color.White;
            this.plProjectList.Controls.Add(this.btnReset);
            this.plProjectList.Controls.Add(this.btnProjectAdd);
            this.plProjectList.Controls.Add(this.cmbStatus);
            this.plProjectList.Controls.Add(this.label2);
            this.plProjectList.Controls.Add(this.btnSearchPro);
            this.plProjectList.Controls.Add(this.txtProjectName);
            this.plProjectList.Controls.Add(this.label1);
            this.plProjectList.Controls.Add(this.dgProjectList);
            this.plProjectList.Location = new System.Drawing.Point(0, 32);
            this.plProjectList.Name = "plProjectList";
            this.plProjectList.Size = new System.Drawing.Size(1288, 538);
            this.plProjectList.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.Location = new System.Drawing.Point(543, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(99, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "重 置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnProjectAdd
            // 
            this.btnProjectAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProjectAdd.BackgroundImage")));
            this.btnProjectAdd.Location = new System.Drawing.Point(648, 4);
            this.btnProjectAdd.Name = "btnProjectAdd";
            this.btnProjectAdd.Size = new System.Drawing.Size(100, 23);
            this.btnProjectAdd.TabIndex = 7;
            this.btnProjectAdd.Text = "项目添加";
            this.btnProjectAdd.UseVisualStyleBackColor = true;
            this.btnProjectAdd.Click += new System.EventHandler(this.btnProjectAdd_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "全部",
            "未删除",
            "已删除"});
            this.cmbStatus.Location = new System.Drawing.Point(286, 5);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbStatus.TabIndex = 6;
            this.cmbStatus.Text = "全部";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "删除状态：";
            // 
            // btnSearchPro
            // 
            this.btnSearchPro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchPro.BackgroundImage")));
            this.btnSearchPro.Location = new System.Drawing.Point(425, 4);
            this.btnSearchPro.Name = "btnSearchPro";
            this.btnSearchPro.Size = new System.Drawing.Size(110, 23);
            this.btnSearchPro.TabIndex = 4;
            this.btnSearchPro.Text = "查  询";
            this.btnSearchPro.UseVisualStyleBackColor = true;
            this.btnSearchPro.Click += new System.EventHandler(this.btnSearchPro_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(69, 5);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(132, 21);
            this.txtProjectName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "项目名称：";
            // 
            // dgProjectList
            // 
            this.dgProjectList.AllowUserToAddRows = false;
            this.dgProjectList.AllowUserToDeleteRows = false;
            this.dgProjectList.BackgroundColor = System.Drawing.Color.White;
            this.dgProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProjectList.Location = new System.Drawing.Point(3, 30);
            this.dgProjectList.Name = "dgProjectList";
            this.dgProjectList.ReadOnly = true;
            this.dgProjectList.RowTemplate.Height = 23;
            this.dgProjectList.Size = new System.Drawing.Size(1285, 508);
            this.dgProjectList.TabIndex = 0;
            this.dgProjectList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProjectList_CellContentClick);
            // 
            // dgVipUserList
            // 
            this.dgVipUserList.AllowUserToAddRows = false;
            this.dgVipUserList.AllowUserToDeleteRows = false;
            this.dgVipUserList.BackgroundColor = System.Drawing.Color.White;
            this.dgVipUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVipUserList.Location = new System.Drawing.Point(0, 34);
            this.dgVipUserList.Name = "dgVipUserList";
            this.dgVipUserList.ReadOnly = true;
            this.dgVipUserList.RowTemplate.Height = 23;
            this.dgVipUserList.Size = new System.Drawing.Size(1285, 504);
            this.dgVipUserList.TabIndex = 0;
            this.dgVipUserList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVipUserList_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "卡号：";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(41, 8);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(122, 21);
            this.txtNo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "会员姓名：";
            // 
            // txtVipName
            // 
            this.txtVipName.Location = new System.Drawing.Point(224, 8);
            this.txtVipName.Name = "txtVipName";
            this.txtVipName.Size = new System.Drawing.Size(122, 21);
            this.txtVipName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "会员电话：";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(410, 9);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(122, 21);
            this.txtPhone.TabIndex = 6;
            // 
            // btnSearchVip
            // 
            this.btnSearchVip.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchVip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchVip.BackgroundImage")));
            this.btnSearchVip.Location = new System.Drawing.Point(703, 7);
            this.btnSearchVip.Name = "btnSearchVip";
            this.btnSearchVip.Size = new System.Drawing.Size(91, 23);
            this.btnSearchVip.TabIndex = 7;
            this.btnSearchVip.Text = "查  询";
            this.btnSearchVip.UseVisualStyleBackColor = false;
            this.btnSearchVip.Click += new System.EventHandler(this.btnSearchVip_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "删除状态：";
            // 
            // cmbVipStatus
            // 
            this.cmbVipStatus.FormattingEnabled = true;
            this.cmbVipStatus.Items.AddRange(new object[] {
            "全部",
            "未删除",
            "已删除"});
            this.cmbVipStatus.Location = new System.Drawing.Point(599, 9);
            this.cmbVipStatus.Name = "cmbVipStatus";
            this.cmbVipStatus.Size = new System.Drawing.Size(85, 20);
            this.cmbVipStatus.TabIndex = 9;
            this.cmbVipStatus.Text = "全部";
            // 
            // plVipUserList
            // 
            this.plVipUserList.BackColor = System.Drawing.Color.White;
            this.plVipUserList.Controls.Add(this.btnShowAll);
            this.plVipUserList.Controls.Add(this.btnVipAdd);
            this.plVipUserList.Controls.Add(this.btnVipReset);
            this.plVipUserList.Controls.Add(this.cmbVipStatus);
            this.plVipUserList.Controls.Add(this.label6);
            this.plVipUserList.Controls.Add(this.btnSearchVip);
            this.plVipUserList.Controls.Add(this.txtPhone);
            this.plVipUserList.Controls.Add(this.label5);
            this.plVipUserList.Controls.Add(this.txtVipName);
            this.plVipUserList.Controls.Add(this.label4);
            this.plVipUserList.Controls.Add(this.txtNo);
            this.plVipUserList.Controls.Add(this.label3);
            this.plVipUserList.Controls.Add(this.dgVipUserList);
            this.plVipUserList.Location = new System.Drawing.Point(3, 32);
            this.plVipUserList.Name = "plVipUserList";
            this.plVipUserList.Size = new System.Drawing.Size(1285, 538);
            this.plVipUserList.TabIndex = 9;
            // 
            // btnVipAdd
            // 
            this.btnVipAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVipAdd.BackgroundImage")));
            this.btnVipAdd.Location = new System.Drawing.Point(962, 7);
            this.btnVipAdd.Name = "btnVipAdd";
            this.btnVipAdd.Size = new System.Drawing.Size(75, 23);
            this.btnVipAdd.TabIndex = 11;
            this.btnVipAdd.Text = "会员添加";
            this.btnVipAdd.UseVisualStyleBackColor = true;
            this.btnVipAdd.Click += new System.EventHandler(this.btnVipAdd_Click);
            // 
            // btnVipReset
            // 
            this.btnVipReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVipReset.BackgroundImage")));
            this.btnVipReset.Location = new System.Drawing.Point(800, 7);
            this.btnVipReset.Name = "btnVipReset";
            this.btnVipReset.Size = new System.Drawing.Size(75, 23);
            this.btnVipReset.TabIndex = 10;
            this.btnVipReset.Text = "重 置";
            this.btnVipReset.UseVisualStyleBackColor = true;
            this.btnVipReset.Click += new System.EventHandler(this.btnVipReset_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowAll.BackgroundImage")));
            this.btnShowAll.Location = new System.Drawing.Point(881, 7);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 12;
            this.btnShowAll.Text = "显示所有";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1288, 599);
            this.Controls.Add(this.plVipUserList);
            this.Controls.Add(this.plProjectList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用新形象会员管理系统";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.plProjectList.ResumeLayout(false);
            this.plProjectList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProjectList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVipUserList)).EndInit();
            this.plVipUserList.ResumeLayout(false);
            this.plVipUserList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel plProjectList;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmProjectList;
        private System.Windows.Forms.ToolStripMenuItem tmProjectAdd;
        private System.Windows.Forms.ToolStripMenuItem tmVipMan;
        private System.Windows.Forms.ToolStripMenuItem tmVipList;
        private System.Windows.Forms.ToolStripMenuItem tmVipAdd;
        private System.Windows.Forms.ToolStripMenuItem tmClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchPro;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnProjectAdd;
        private System.Windows.Forms.DataGridView dgProjectList;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgVipUserList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVipName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSearchVip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbVipStatus;
        private System.Windows.Forms.Panel plVipUserList;
        private System.Windows.Forms.Button btnVipAdd;
        private System.Windows.Forms.Button btnVipReset;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem tlDbBack;
        private System.Windows.Forms.Button btnShowAll;


    }
}