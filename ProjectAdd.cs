using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xinxingxiang
{
    public partial class ProjectAdd : Form
    {
        public ProjectAdd(string id)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(id))
            {
                string sql = string.Format("SELECT * FROM PROJECT WHERE ID='{0}'", id);
                DataSet ds = DbHelperMySQL.Query(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtProjectName.Text = ds.Tables[0].Rows[0]["PROJECT_NAME"].ToString();
                    txtJiancheng.Text = ds.Tables[0].Rows[0]["PROJECT_JIANCHENG"].ToString();
                    txtRemark.Text = ds.Tables[0].Rows[0]["REMARK"].ToString();
                    lblId.Text = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                this.plID.Visible = true;
                this.Text = "项目修改";
            }
            else
            {
                this.plID.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageBox.Show("请输入项目名称。", "非空提示", MessageBoxButtons.OK);
                txtProjectName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtJiancheng.Text))
            {
                MessageBox.Show("请输入项目简称。", "非空提示", MessageBoxButtons.OK);
                txtProjectName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                MessageBox.Show("单价不能为空。", "非空提示", MessageBoxButtons.OK);
                txtProjectName.Focus();
                return;
            }
            string sqlStr = "";
            //添加
            if (string.IsNullOrEmpty(lblId.Text))
            {
                //判定项目是否已经存在
                string sqlStr1 = string.Format(@"SELECT * FROM PROJECT WHERE PROJECT_NAME= '{0}'", txtProjectName.Text);
                if (DbHelperMySQL.Query(sqlStr1).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("项目已经存在，请重新输入。", "保存提示", MessageBoxButtons.OK);
                    txtProjectName.Focus();
                    return;
                }
                else
                {
                    StringBuilder sqlBui = new StringBuilder();
                    DateTime addTime = DateTime.Now;
                    string remark = txtRemark.Text;
                    sqlBui.Append("INSERT INTO PROJECT(ID,PROJECT_NAME,PROJECT_JIANCHENG,REMARK,ADD_USER_ID,ADD_USER_NAME,ADD_TIME,UNIT_PRICE)");
                    sqlBui.AppendFormat(@"VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})",
                        Guid.NewGuid().ToString("N"), txtProjectName.Text, txtJiancheng.Text, txtRemark.Text, Program.userId, Program.userName, addTime, txtUnitPrice.Text);
                    sqlStr = sqlBui.ToString();
                }
            }
            else
            {
                sqlStr = string.Format("UPDATE PROJECT SET PROJECT_NAME='{0}',PROJECT_JIANCHENG='{1}',REMARK='{2}',EDIT_TIME='{4}',UNIT_PRICE={5} WHERE ID='{3}'",
                    txtProjectName.Text, txtJiancheng.Text, txtRemark.Text, lblId.Text, DateTime.Now, txtUnitPrice.Text);
            }
            int result = DbHelperMySQL.ExecuteSql(sqlStr);
            if (result > 0)
            {
                MessageBox.Show("保存成功！", "保存提示", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
