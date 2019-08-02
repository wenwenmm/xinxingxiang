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
    public partial class AddMoney : Form
    {
        private string vipId = "";//会员ID
        private string vipName = "";//会员名
        private string vipNo = "";//会员编号
        private double oldBlanceMoney;//会员余额

        public AddMoney(string id)
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
                    lblVipName.Text = ds.Tables[0].Rows[0]["VIP_NAME"].ToString();
                    vipName = ds.Tables[0].Rows[0]["VIP_NAME"].ToString();
                    vipNo = ds.Tables[0].Rows[0]["VIP_NO"].ToString();
                    oldBlanceMoney = Convert.ToDouble(ds.Tables[0].Rows[0]["VIP_BLAN_MONEY"]);//余额
                }
            }
        }

        #region 余额充值
        /// <summary>
        /// 余额充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMoney_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMoney.Text))
            {
                MessageBox.Show("请输入充值金额。", "非空提示", MessageBoxButtons.OK);
                txtMoney.Focus();
                return;
            }
            else
            {
                Random r = new Random();
                int num = r.Next(10000, 99999);//随机生成一个5位整数
                string ticketNo = DateTime.Now.ToString("yyyyMMddHHmmss") + num;

                List<string> sqlList = new List<string>();
                //1.会员主表余额变化、积分变化
                double addMoney = Convert.ToDouble(txtMoney.Text);//消费金额
                double newBlanceMoney = oldBlanceMoney + addMoney;//最新消费余额
                string sqlStr = string.Format(@"UPDATE VIP_USER SET VIP_BLAN_MONEY={0},EDIT_TIME='{2}' WHERE ID='{1}';", newBlanceMoney, vipId, DateTime.Now);
                sqlList.Add(sqlStr);
                //2.会员消费记录表添加
                StringBuilder sqlBui = new StringBuilder();
                DateTime addTime = DateTime.Now;
                //创建会员添加一条消费记录
                sqlBui.Append(@"INSERT INTO VIP_SALE(ID,SALE_PROJECT,SALE_MONEY,THIS_BLANCE_MONEY,VIP_POINT
                                                    ,SALE_DATE,VIP_ID,VIP_SALE_NAME,REMARK,ADD_USER_ID,ADD_USER_NAME,ADD_TIME,VIP_NO,TICKET_NO)");
                sqlBui.AppendFormat(@"VALUES ('{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}');",
                    Guid.NewGuid().ToString("N"), "充值", -addMoney, newBlanceMoney, 0, addTime, vipId, vipName, "", Program.userId, Program.userName, addTime, vipNo, ticketNo);

                sqlList.Add(sqlBui.ToString());
                int result = DbHelperMySQL.ExecuteSqlTran(sqlList);
                if (result > 0)
                {
                    printTicket(vipNo, vipName, addMoney, newBlanceMoney, ticketNo, "", "", "");
                    MessageBox.Show("充值成功。", "保存提示", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }
        #endregion

        #region 打印
        private void printTicket(string printVipNo, string printVipName, double money, double blanceMoney, string ticketNo, string remark, string disc, string discMoney)
        {
            string[] salePorject = new string[1] { "充值" };
            List<double> moneyList = new List<double>();
            moneyList.Add(money);
            SelectQuery selectQuery = new SelectQuery("Win32_USBHub");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
            foreach (ManagementObject disk in searcher.Get())
            {
                string PNPDeviceID = disk["PNPDeviceID"] as String;
                UsbPrinter usbPrint = new UsbPrinter();
                usbPrint.BeginPrint(PNPDeviceID, DateTime.Now, ticketNo, salePorject, moneyList, money.ToString(), blanceMoney.ToString(), printVipNo, printVipName, remark, Program.userName, disc, discMoney);
            }
        }
        #endregion
    }
}
