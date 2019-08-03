namespace xinxingxiang
{
    partial class SaleAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.lblVipNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkProject = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVipBlanceMoney = new System.Windows.Forms.Label();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSaleName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDisc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscMoney = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.项目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员编号：";
            // 
            // lblVipNo
            // 
            this.lblVipNo.AutoSize = true;
            this.lblVipNo.Location = new System.Drawing.Point(79, 19);
            this.lblVipNo.Name = "lblVipNo";
            this.lblVipNo.Size = new System.Drawing.Size(11, 12);
            this.lblVipNo.TabIndex = 1;
            this.lblVipNo.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "消费项目：";
            // 
            // chkProject
            // 
            this.chkProject.CheckOnClick = true;
            this.chkProject.FormattingEnabled = true;
            this.chkProject.Location = new System.Drawing.Point(12, 65);
            this.chkProject.Name = "chkProject";
            this.chkProject.Size = new System.Drawing.Size(637, 52);
            this.chkProject.TabIndex = 1;
            this.chkProject.SelectedIndexChanged += new System.EventHandler(this.ChkProject_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "消费金额：";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(80, 264);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(153, 21);
            this.txtMoney.TabIndex = 2;
            this.txtMoney.Leave += new System.EventHandler(this.txtMoney_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "元";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "备    注：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(80, 395);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(199, 67);
            this.txtRemark.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "当前余额：";
            // 
            // lblVipBlanceMoney
            // 
            this.lblVipBlanceMoney.AutoSize = true;
            this.lblVipBlanceMoney.Location = new System.Drawing.Point(80, 239);
            this.lblVipBlanceMoney.Name = "lblVipBlanceMoney";
            this.lblVipBlanceMoney.Size = new System.Drawing.Size(0, 12);
            this.lblVipBlanceMoney.TabIndex = 10;
            // 
            // btnSale
            // 
            this.btnSale.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSale.BackgroundImage")));
            this.btnSale.Location = new System.Drawing.Point(131, 472);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(75, 23);
            this.btnSale.TabIndex = 5;
            this.btnSale.Text = "消费并打印";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.Location = new System.Drawing.Point(210, 472);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "元";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "消费人名：";
            // 
            // txtSaleName
            // 
            this.txtSaleName.Location = new System.Drawing.Point(80, 353);
            this.txtSaleName.Name = "txtSaleName";
            this.txtSaleName.Size = new System.Drawing.Size(153, 21);
            this.txtSaleName.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(78, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "注：不填为会员本人。";
            // 
            // txtDisc
            // 
            this.txtDisc.Location = new System.Drawing.Point(80, 293);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.ReadOnly = true;
            this.txtDisc.Size = new System.Drawing.Size(153, 21);
            this.txtDisc.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "折扣：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 327);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "元";
            // 
            // txtDiscMoney
            // 
            this.txtDiscMoney.Location = new System.Drawing.Point(80, 322);
            this.txtDiscMoney.Name = "txtDiscMoney";
            this.txtDiscMoney.Size = new System.Drawing.Size(153, 21);
            this.txtDiscMoney.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 325);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "折后金额：";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(7, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "手输价格消费并打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.项目,
            this.单价,
            this.操作});
            this.dataGridView1.Location = new System.Drawing.Point(12, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(637, 96);
            this.dataGridView1.TabIndex = 23;
            // 
            // 项目
            // 
            this.项目.HeaderText = "项目";
            this.项目.Name = "项目";
            // 
            // 单价
            // 
            this.单价.HeaderText = "单价";
            this.单价.Name = "单价";
            // 
            // 操作
            // 
            this.操作.HeaderText = "操作";
            this.操作.Name = "操作";
            // 
            // SaleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(661, 509);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDiscMoney);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDisc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSaleName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.lblVipBlanceMoney);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblVipNo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaleAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加消费记录";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVipNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVipBlanceMoney;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSaleName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDisc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDiscMoney;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn 操作;
    }
}