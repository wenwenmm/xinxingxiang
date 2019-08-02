using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace xinxingxiang
{
    public partial class SaleAdd : Form
    {
        private string vipId = "";//会员ID
        private string vipName = "";//会员名
        private string printVipNameStr = "";//会员名-打印用
        private string vipNo = "";//会员编号

        public SaleAdd(string id)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(id))
            {
                vipId = id;
                string sql = string.Format("SELECT * FROM VIP_USER WHERE ID='{0}'", id);
                DataSet ds = DbHelperMySQL.Query(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblVipNo.Text = ds.Tables[0].Rows[0]["VIP_NO"].ToString();
                    lblVipBlanceMoney.Text = ds.Tables[0].Rows[0]["VIP_BLAN_MONEY"].ToString();
                    vipName = ds.Tables[0].Rows[0]["VIP_NAME"].ToString();
                    printVipNameStr = ds.Tables[0].Rows[0]["VIP_NAME"].ToString();
                    vipNo = ds.Tables[0].Rows[0]["VIP_NO"].ToString();
                    txtDisc.Text = ds.Tables[0].Rows[0]["VIP_DISC_RATE"].ToString();
                }
            }
            string sqlStr = "SELECT ID,CONCAT(PROJECT_JIANCHENG,' ',UNIT_PRICE) PROJECT_JIANCHENG FROM PROJECT WHERE IS_DEL=0;";
            DataSet dsPro = DbHelperMySQL.Query(sqlStr);
            if (dsPro.Tables[0].Rows.Count > 0)
            {
                chkProject.DataSource = dsPro.Tables[0];
                chkProject.ValueMember = "ID";
                chkProject.DisplayMember = "PROJECT_JIANCHENG";
            }
        }

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region  鼠标离开
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMoney_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMoney.Text))
            {
                double vipBlanceMoney = Convert.ToDouble(lblVipBlanceMoney.Text);//当前余额
                double saleMoney = Convert.ToDouble(txtMoney.Text);//消费金额
                if (vipBlanceMoney - saleMoney < 0)
                {
                    MessageBox.Show("当前会员的余额已经不够支付，请先充值。", "余额不足提示", MessageBoxButtons.OK);
                    AddMoney form = new AddMoney(vipId);
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                    {
                        string sql = string.Format("SELECT * FROM VIP_USER WHERE ID='{0}'", vipId);
                        DataSet ds = DbHelperMySQL.Query(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblVipBlanceMoney.Text = ds.Tables[0].Rows[0]["VIP_BLAN_MONEY"].ToString();
                        }
                    }
                }
            }
        }

        #endregion

        #region 消费
        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSale_Click(object sender, EventArgs e)
        {
            //1.会员主表余额变化、积分变化
            string checkedText = string.Empty;
            List<string> chkProjectList = new List<string>();//項目
            List<double> moneyList = new List<double>();//单价
            List<String> checkedTextList = new List<string>();
            for (int i = 0; i < this.chkProject.Items.Count; i++)
            {
                if (this.chkProject.GetItemChecked(i))
                {
                    this.chkProject.SetSelected(i, true);
                    checkedText += (String.IsNullOrEmpty(checkedText) ? "" : "+") + this.chkProject.GetItemText(this.chkProject.Items[i]);
                    checkedTextList.Add(this.chkProject.GetItemText(this.chkProject.Items[i]));
                }
            }

            if (checkedTextList.Count > 0)
            {
                double saleMoney = 0D;//消费金额
                for (int i = 0; i < checkedTextList.Count; i++)
                {
                    string[] strTmps = checkedTextList[i].Split(' ');
                    chkProjectList.Add(strTmps[0].ToString());
                    moneyList.Add(Convert.ToDouble(strTmps[1]));
                }
            }
            if (String.IsNullOrEmpty(checkedText))
            {
                MessageBox.Show("请选择消费项目。", "非空提示", MessageBoxButtons.OK);
                chkProject.Focus();
            }
            else if (String.IsNullOrEmpty(txtMoney.Text))
            {
                MessageBox.Show("请输入消费金额。", "非空提示", MessageBoxButtons.OK);
                txtMoney.Focus();
            }
            else
            {
                Random r = new Random();
                int num = r.Next(10000, 99999);//随机生成一个5位整数
                string ticketNo = DateTime.Now.ToString("yyyyMMddHHmmss") + num;

                List<string> sqlList = new List<string>();
                double vipBlanceMoney = Convert.ToDouble(lblVipBlanceMoney.Text);//当前余额
                double saleMoney = Convert.ToDouble(txtMoney.Text);
                double discSaleMoney = Convert.ToDouble(txtDiscMoney.Text);
                //double newBlanceMoney = vipBlanceMoney - saleMoney;//最新消费余额
                double newBlanceMoney = vipBlanceMoney - discSaleMoney;//最新消费余额
                string sqlStr = string.Format(@"UPDATE VIP_USER SET VIP_BLAN_MONEY={0},EDIT_TIME='{2}' WHERE ID='{1}';", newBlanceMoney, vipId, DateTime.Now);
                sqlList.Add(sqlStr);
                //2.会员消费记录表添加
                StringBuilder sqlBui = new StringBuilder();
                DateTime addTime = DateTime.Now;
                if (!string.IsNullOrEmpty(txtSaleName.Text))
                {
                    vipName = txtSaleName.Text;
                }
                sqlBui.Append(@"INSERT INTO VIP_SALE(ID,SALE_PROJECT,SALE_MONEY,THIS_BLANCE_MONEY,VIP_POINT
                                                    ,SALE_DATE,VIP_ID,VIP_SALE_NAME,REMARK,ADD_USER_ID,ADD_USER_NAME,ADD_TIME,VIP_NO,TICKET_NO,VIP_DISC_RATE,DISC_MONEY,SALE_MONEY_LIST)");
                sqlBui.AppendFormat(@"VALUES ('{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},{15},{16});",
                    Guid.NewGuid().ToString("N"), string.Join("+", chkProjectList), Convert.ToDouble(txtMoney.Text), newBlanceMoney, 0, addTime, vipId, vipName, txtRemark.Text
                    , Program.userId, Program.userName, addTime, vipNo, ticketNo
                    , txtDisc.Text, txtDiscMoney.Text, string.Join("+", moneyList));

                sqlList.Add(sqlBui.ToString());
                int result = DbHelperMySQL.ExecuteSqlTran(sqlList);
                if (result > 0)
                {
                    printTicket(chkProjectList, moneyList, vipNo, printVipNameStr, Convert.ToDouble(txtMoney.Text), newBlanceMoney, ticketNo, txtRemark.Text, txtDisc.Text, txtDiscMoney.Text);
                    MessageBox.Show("消费成功。", "保存提示", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }

        #endregion

        #region 打印小票
        /// <summary>
        /// 打印小票
        /// </summary>
        /// <param name="chkProject">消费项目</param>
        /// <param name="vipNo">会员编号</param>
        /// <param name="vipName">会员姓名</param>
        /// <param name="money">消费金额</param>
        /// <param name="blanceMoney">账户余额</param>
        /*private void printTicket(CheckedListBox chkProject, string printVipNo, string printVipName, double money, double blanceMoney, string ticketNo, string remark)
        {
            string[] salePorject = new string[chkProject.CheckedItems.Count];
            int salePorjectIndes = 0;
            for (int i = 0; i < this.chkProject.Items.Count; i++)
            {
                if (this.chkProject.GetItemChecked(i))
                {
                    salePorject[salePorjectIndes] = this.chkProject.GetItemText(this.chkProject.Items[i]);
                    salePorjectIndes += 1;
                }
            }
            SelectQuery selectQuery = new SelectQuery("Win32_USBHub");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
            foreach (ManagementObject disk in searcher.Get())
            {
                string PNPDeviceID = disk["PNPDeviceID"] as String;
                UsbPrinter usbPrint = new UsbPrinter();
                usbPrint.BeginPrint(PNPDeviceID, DateTime.Now, ticketNo, salePorject, money.ToString(), blanceMoney.ToString(), printVipNo, printVipName, remark, Program.userName);
            }
            //MessageBox.Show("打印成功。");
        }*/
        #endregion

        #region 打印小票
        /// <summary>
        /// 打印小票
        /// </summary>
        /// <param name="chkProject">消费项目</param>
        /// <param name="vipNo">会员编号</param>
        /// <param name="vipName">会员姓名</param>
        /// <param name="money">消费金额</param>
        /// <param name="blanceMoney">账户余额</param>
        private void printTicket(List<String> chkProjects, List<Double> moneys, string printVipNo, string printVipName, double money, double blanceMoney, string ticketNo, string remark, string disc, string discMoney)
        {
            string[] salePorject = new string[chkProjects.Count];
            int salePorjectIndes = 0;
            for (int i = 0; i < this.chkProject.Items.Count; i++)
            {
                if (this.chkProject.GetItemChecked(i))
                {
                    salePorject[salePorjectIndes] = this.chkProject.GetItemText(this.chkProject.Items[i]);
                    salePorjectIndes += 1;
                }
            }
            SelectQuery selectQuery = new SelectQuery("Win32_USBHub");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
            foreach (ManagementObject disk in searcher.Get())
            {
                string PNPDeviceID = disk["PNPDeviceID"] as String;
                UsbPrinter usbPrint = new UsbPrinter();
                usbPrint.BeginPrint(PNPDeviceID, DateTime.Now, ticketNo, salePorject, moneys, money.ToString(), blanceMoney.ToString(), printVipNo, printVipName, remark, Program.userName, disc, discMoney);
            }
            //MessageBox.Show("打印成功。");
        }
        #endregion


        private void ChkProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> checkedTextList = new List<string>();
            for (int i = 0; i < this.chkProject.Items.Count; i++)
            {
                if (this.chkProject.GetItemChecked(i))
                {
                    checkedTextList.Add(this.chkProject.GetItemText(this.chkProject.Items[i]));
                }
            }
            if (checkedTextList.Count > 0)
            {
                List<string> chkProjects = new List<string>();//項目
                List<double> money = new List<double>();//单价
                double saleMoney = 0D;//消费金额
                for (int i = 0; i < checkedTextList.Count; i++)
                {
                    string[] strTmps = checkedTextList[i].Split(' ');
                    chkProjects.Add(strTmps[0].ToString());
                    money.Add(Convert.ToDouble(strTmps[1]));
                    saleMoney += Convert.ToDouble(strTmps[1]);
                }
                txtMoney.Text = saleMoney.ToString();
                double disc = Convert.ToDouble(txtDisc.Text);
                txtDiscMoney.Text = (saleMoney * disc / 10).ToString();
                btnSale.Enabled = true;
            }
            else
            {
                txtMoney.Text = "0";
                txtDiscMoney.Text = "0";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double saleMoney = Convert.ToDouble(txtMoney.Text);
            double disc = Convert.ToDouble(txtDisc.Text);
            double discSaleMoney = (saleMoney * disc / 10);
            txtDiscMoney.Text = discSaleMoney.ToString();
            Random r = new Random();
            int num = r.Next(10000, 99999);//随机生成一个5位整数
            string ticketNo = DateTime.Now.ToString("yyyyMMddHHmmss") + num;

            List<string> sqlList = new List<string>();
            double vipBlanceMoney = Convert.ToDouble(lblVipBlanceMoney.Text);//当前余额
            double newBlanceMoney = vipBlanceMoney - discSaleMoney;//最新消费余额
            string sqlStr = string.Format(@"UPDATE VIP_USER SET VIP_BLAN_MONEY={0},EDIT_TIME='{2}' WHERE ID='{1}';", newBlanceMoney, vipId, DateTime.Now);
            sqlList.Add(sqlStr);
            //2.会员消费记录表添加
            StringBuilder sqlBui = new StringBuilder();
            DateTime addTime = DateTime.Now;
            if (!string.IsNullOrEmpty(txtSaleName.Text))
            {
                vipName = txtSaleName.Text;
            }
            sqlBui.Append(@"INSERT INTO VIP_SALE(ID,SALE_PROJECT,SALE_MONEY,THIS_BLANCE_MONEY,VIP_POINT
                                                    ,SALE_DATE,VIP_ID,VIP_SALE_NAME,REMARK,ADD_USER_ID,ADD_USER_NAME,ADD_TIME,VIP_NO,TICKET_NO,VIP_DISC_RATE,DISC_MONEY,SALE_MONEY_LIST)");
            sqlBui.AppendFormat(@"VALUES ('{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},{15},{16});",
                Guid.NewGuid().ToString("N"), "套餐", Convert.ToDouble(txtMoney.Text), newBlanceMoney, 0, addTime, vipId, vipName, txtRemark.Text
                , Program.userId, Program.userName, addTime, vipNo, ticketNo
                , txtDisc.Text, txtDiscMoney.Text, discSaleMoney);

            sqlList.Add(sqlBui.ToString());
            int result = DbHelperMySQL.ExecuteSqlTran(sqlList);
            if (result > 0)
            {
                string[] chkProjectList = { "套餐" };//項目
                List<double> moneyList = new List<double>();//单价
                moneyList.Add(saleMoney);
                printTicket2(chkProjectList, moneyList, vipNo, printVipNameStr, Convert.ToDouble(txtMoney.Text), newBlanceMoney, ticketNo, txtRemark.Text, txtDisc.Text, txtDiscMoney.Text);
                MessageBox.Show("消费成功。", "保存提示", MessageBoxButtons.OK);
                this.Close();
            }
        }

        #region 打印小票
        /// <summary>
        /// 打印小票
        /// </summary>
        /// <param name="chkProject">消费项目</param>
        /// <param name="vipNo">会员编号</param>
        /// <param name="vipName">会员姓名</param>
        /// <param name="money">消费金额</param>
        /// <param name="blanceMoney">账户余额</param>
        private void printTicket2(string[] salePorject, List<Double> moneys, string printVipNo, string printVipName, double money, double blanceMoney, string ticketNo, string remark, string disc, string discMoney)
        {
            int salePorjectIndes = 0;
            SelectQuery selectQuery = new SelectQuery("Win32_USBHub");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
            foreach (ManagementObject disk in searcher.Get())
            {
                string PNPDeviceID = disk["PNPDeviceID"] as String;
                UsbPrinter usbPrint = new UsbPrinter();
                usbPrint.BeginPrint(PNPDeviceID, DateTime.Now, ticketNo, salePorject, moneys, money.ToString(), blanceMoney.ToString(), printVipNo, printVipName, remark, Program.userName, disc, discMoney);
            }
            //MessageBox.Show("打印成功。");
        }
        #endregion
    }
}
