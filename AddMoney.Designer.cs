namespace xinxingxiang
{
    partial class AddMoney
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMoney));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.lblVipNo = new System.Windows.Forms.Label();
            this.lblVipName = new System.Windows.Forms.Label();
            this.btnAddMoney = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员卡号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "会员姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "充值金额：";
            // 
            // txtMoney
            // 
            this.txtMoney.ForeColor = System.Drawing.Color.Black;
            this.txtMoney.Location = new System.Drawing.Point(92, 80);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(145, 21);
            this.txtMoney.TabIndex = 3;
            // 
            // lblVipNo
            // 
            this.lblVipNo.AutoSize = true;
            this.lblVipNo.ForeColor = System.Drawing.Color.Black;
            this.lblVipNo.Location = new System.Drawing.Point(92, 24);
            this.lblVipNo.Name = "lblVipNo";
            this.lblVipNo.Size = new System.Drawing.Size(0, 12);
            this.lblVipNo.TabIndex = 4;
            // 
            // lblVipName
            // 
            this.lblVipName.AutoSize = true;
            this.lblVipName.ForeColor = System.Drawing.Color.Black;
            this.lblVipName.Location = new System.Drawing.Point(94, 54);
            this.lblVipName.Name = "lblVipName";
            this.lblVipName.Size = new System.Drawing.Size(0, 12);
            this.lblVipName.TabIndex = 5;
            // 
            // btnAddMoney
            // 
            this.btnAddMoney.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddMoney.BackgroundImage")));
            this.btnAddMoney.ForeColor = System.Drawing.Color.Black;
            this.btnAddMoney.Location = new System.Drawing.Point(92, 114);
            this.btnAddMoney.Name = "btnAddMoney";
            this.btnAddMoney.Size = new System.Drawing.Size(145, 23);
            this.btnAddMoney.TabIndex = 6;
            this.btnAddMoney.Text = "充值并打印";
            this.btnAddMoney.UseVisualStyleBackColor = true;
            this.btnAddMoney.Click += new System.EventHandler(this.btnAddMoney_Click);
            // 
            // AddMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(264, 151);
            this.Controls.Add(this.btnAddMoney);
            this.Controls.Add(this.lblVipName);
            this.Controls.Add(this.lblVipNo);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "余额充值";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label lblVipNo;
        private System.Windows.Forms.Label lblVipName;
        private System.Windows.Forms.Button btnAddMoney;
    }
}