namespace xinxingxiang
{
    partial class VipUserAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VipUserAdd));
            this.plID = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVipName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVipNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVipPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radMan = new System.Windows.Forms.RadioButton();
            this.radWoMan = new System.Windows.Forms.RadioButton();
            this.txtDiscRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBlance = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.plID.SuspendLayout();
            this.SuspendLayout();
            // 
            // plID
            // 
            this.plID.Controls.Add(this.lblId);
            this.plID.Controls.Add(this.label4);
            this.plID.Location = new System.Drawing.Point(13, 4);
            this.plID.Name = "plID";
            this.plID.Size = new System.Drawing.Size(260, 29);
            this.plID.TabIndex = 20;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(60, 10);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 12);
            this.lblId.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "编    号：";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Location = new System.Drawing.Point(184, 383);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.Location = new System.Drawing.Point(89, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存并打印";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(75, 279);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(198, 90);
            this.txtRemark.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "备注：";
            // 
            // txtVipName
            // 
            this.txtVipName.Location = new System.Drawing.Point(75, 71);
            this.txtVipName.Name = "txtVipName";
            this.txtVipName.Size = new System.Drawing.Size(198, 21);
            this.txtVipName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "会员姓名：";
            // 
            // txtVipNo
            // 
            this.txtVipNo.Location = new System.Drawing.Point(75, 41);
            this.txtVipNo.Name = "txtVipNo";
            this.txtVipNo.ReadOnly = true;
            this.txtVipNo.Size = new System.Drawing.Size(198, 21);
            this.txtVipNo.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "会员卡号：";
            // 
            // txtVipPhone
            // 
            this.txtVipPhone.Location = new System.Drawing.Point(75, 102);
            this.txtVipPhone.Name = "txtVipPhone";
            this.txtVipPhone.Size = new System.Drawing.Size(198, 21);
            this.txtVipPhone.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "会员电话：";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(75, 203);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(198, 33);
            this.txtAddress.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "会员住址：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "会员性别：";
            // 
            // radMan
            // 
            this.radMan.AutoSize = true;
            this.radMan.Checked = true;
            this.radMan.Location = new System.Drawing.Point(75, 146);
            this.radMan.Name = "radMan";
            this.radMan.Size = new System.Drawing.Size(35, 16);
            this.radMan.TabIndex = 3;
            this.radMan.TabStop = true;
            this.radMan.Text = "男";
            this.radMan.UseVisualStyleBackColor = true;
            // 
            // radWoMan
            // 
            this.radWoMan.AutoSize = true;
            this.radWoMan.Location = new System.Drawing.Point(115, 146);
            this.radWoMan.Name = "radWoMan";
            this.radWoMan.Size = new System.Drawing.Size(35, 16);
            this.radWoMan.TabIndex = 3;
            this.radWoMan.Text = "女";
            this.radWoMan.UseVisualStyleBackColor = true;
            // 
            // txtDiscRate
            // 
            this.txtDiscRate.Location = new System.Drawing.Point(75, 173);
            this.txtDiscRate.Name = "txtDiscRate";
            this.txtDiscRate.Size = new System.Drawing.Size(179, 21);
            this.txtDiscRate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "会员折扣：";
            // 
            // txtBlance
            // 
            this.txtBlance.Location = new System.Drawing.Point(75, 244);
            this.txtBlance.Name = "txtBlance";
            this.txtBlance.Size = new System.Drawing.Size(198, 21);
            this.txtBlance.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "会员余额：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(74, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "注意：会员电话唯一。";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(259, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "折";
            // 
            // VipUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 419);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBlance);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDiscRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radWoMan);
            this.Controls.Add(this.radMan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtVipPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.plID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVipName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVipNo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VipUserAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "会员添加";
            this.plID.ResumeLayout(false);
            this.plID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plID;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVipName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVipNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVipPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radMan;
        private System.Windows.Forms.RadioButton radWoMan;
        private System.Windows.Forms.TextBox txtDiscRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBlance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}