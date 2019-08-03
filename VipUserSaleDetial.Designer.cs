namespace xinxingxiang
{
    partial class VipUserSaleDetial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VipUserSaleDetial));
            this.dgSaleList = new System.Windows.Forms.DataGridView();
            this.btnSale = new System.Windows.Forms.Button();
            this.lblVipNo = new System.Windows.Forms.Label();
            this.btnAddMoney = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVipName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTicketNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddSale2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSaleList
            // 
            this.dgSaleList.AllowUserToAddRows = false;
            this.dgSaleList.AllowUserToDeleteRows = false;
            this.dgSaleList.BackgroundColor = System.Drawing.Color.White;
            this.dgSaleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSaleList.Location = new System.Drawing.Point(2, 38);
            this.dgSaleList.Name = "dgSaleList";
            this.dgSaleList.ReadOnly = true;
            this.dgSaleList.RowTemplate.Height = 23;
            this.dgSaleList.Size = new System.Drawing.Size(1163, 292);
            this.dgSaleList.TabIndex = 0;
            this.dgSaleList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSaleList_CellContentClick);
            // 
            // btnSale
            // 
            this.btnSale.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSale.BackgroundImage")));
            this.btnSale.Location = new System.Drawing.Point(496, 9);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(118, 23);
            this.btnSale.TabIndex = 2;
            this.btnSale.Text = "添加消费记录备用";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // lblVipNo
            // 
            this.lblVipNo.AutoSize = true;
            this.lblVipNo.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVipNo.Location = new System.Drawing.Point(71, 11);
            this.lblVipNo.Name = "lblVipNo";
            this.lblVipNo.Size = new System.Drawing.Size(0, 16);
            this.lblVipNo.TabIndex = 3;
            // 
            // btnAddMoney
            // 
            this.btnAddMoney.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddMoney.BackgroundImage")));
            this.btnAddMoney.Location = new System.Drawing.Point(631, 9);
            this.btnAddMoney.Name = "btnAddMoney";
            this.btnAddMoney.Size = new System.Drawing.Size(91, 23);
            this.btnAddMoney.TabIndex = 4;
            this.btnAddMoney.Text = "充 值";
            this.btnAddMoney.UseVisualStyleBackColor = true;
            this.btnAddMoney.Click += new System.EventHandler(this.btnAddMoney_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "会员编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "会员姓名：";
            // 
            // lblVipName
            // 
            this.lblVipName.AutoSize = true;
            this.lblVipName.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVipName.Location = new System.Drawing.Point(271, 11);
            this.lblVipName.Name = "lblVipName";
            this.lblVipName.Size = new System.Drawing.Size(0, 16);
            this.lblVipName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(736, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "小票编号：";
            // 
            // txtTicketNo
            // 
            this.txtTicketNo.Location = new System.Drawing.Point(808, 11);
            this.txtTicketNo.Name = "txtTicketNo";
            this.txtTicketNo.Size = new System.Drawing.Size(117, 21);
            this.txtTicketNo.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.Location = new System.Drawing.Point(957, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "查 询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddSale2
            // 
            this.btnAddSale2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddSale2.BackgroundImage")));
            this.btnAddSale2.Location = new System.Drawing.Point(386, 9);
            this.btnAddSale2.Name = "btnAddSale2";
            this.btnAddSale2.Size = new System.Drawing.Size(91, 23);
            this.btnAddSale2.TabIndex = 10;
            this.btnAddSale2.Text = "添加消费记录";
            this.btnAddSale2.UseVisualStyleBackColor = true;
            this.btnAddSale2.Click += new System.EventHandler(this.BtnAddSale2_Click);
            // 
            // VipUserSaleDetial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1167, 331);
            this.Controls.Add(this.btnAddSale2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTicketNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddMoney);
            this.Controls.Add(this.lblVipNo);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.lblVipName);
            this.Controls.Add(this.dgSaleList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VipUserSaleDetial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "会员消费明细";
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSaleList;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Label lblVipNo;
        private System.Windows.Forms.Button btnAddMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVipName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTicketNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddSale2;
    }
}