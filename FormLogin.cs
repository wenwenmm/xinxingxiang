using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xinxingxiang
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login()
        {
            string userName = this.txtUserName.Text.ToString();
            string password = this.txtPassword.Text.ToString();
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(userName))
            {
                strWhere += string.Format(@" AND USER_LOGIN_NAME = '{0}'", userName);
            }
            if (!string.IsNullOrEmpty(password))
            {
                strWhere += string.Format(@" AND PASSWORD = '{0}'", password);
            }
            string strSql = string.Format(@"SELECT * FROM SYS_USER WHERE 1=1 {0};", strWhere);
            DataSet ds = DbHelperMySQL.Query(strSql);
            //大于0说明存在记录
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态
                Program.userId = ds.Tables[0].Rows[0]["ID"].ToString();
                Program.userName = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                Program.userloninName = ds.Tables[0].Rows[0]["USER_LOGIN_NAME"].ToString();
                //备份数据库
                //Program.BackData("登录备份");
                this.Close();//关闭登录窗口this
            }
            else
            {
                MessageBox.Show("用户名或密码错误，请重新输入！");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                login();
            }
        }
    }
}
