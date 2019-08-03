using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace xinxingxiang
{
    public partial class SaleAddNew : Form
    {
        private string vipId = "";//会员ID
        private string vipName = "";//会员名
        private string printVipNameStr = "";//会员名-打印用
        private string vipNo = "";//

        public SaleAddNew(string id)
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
            string sqlStr = "SELECT PROJECT_JIANCHENG AS 项目 ,UNIT_PRICE AS 单价 FROM PROJECT WHERE IS_DEL=0;";
            DataSet dsPro = DbHelperMySQL.Query(sqlStr);
            if (dsPro.Tables[0].Rows.Count > 0)
            {
                this.dataGridView1.DataSource = dsPro;
                this.dataGridView1.DataMember = dsPro.Tables[0].TableName;
            }
        }

        /// <summary>
        /// 绑定DataGridView数据到DataTable
        /// </summary>
        /// <param name="dgv">复制数据的DataGridView</param>
        /// <returns>返回的绑定数据后的DataTable</returns>
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }
            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                string strTmp = Convert.ToString(dgv.Rows[count].Cells[0].Value);
                if (strTmp != "")
                {
                    DataRow dr = dt.NewRow();
                    for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                    {
                        dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                DataTable dt = GetDgvToTable(dataGridView2);
                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add(new DataColumn("项目", typeof(string)));
                    dt.Columns.Add(new DataColumn("单价", typeof(string)));
                }
                DataRow dr = dt.NewRow(); ;
                dr["项目"] = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dr["单价"] = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                dt.Rows.Add(dr);
                dataGridView2.DataSource = dt;
                calcMoney();
            }
        }

        private void DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count - 1)
            {
                dataGridView2.Rows.Remove(dataGridView2.Rows[e.RowIndex]);
                calcMoney();
            }
        }
        private void calcMoney()
        {
            DataTable dt = GetDgvToTable(dataGridView2);
            double saleMoney = 0d;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    saleMoney += Convert.ToDouble(dt.Rows[i][1]);
                }
            }
            txtMoney.Text = saleMoney.ToString();
            double disc = Convert.ToDouble(txtDisc.Text);
            txtDiscMoney.Text = (saleMoney * disc / 10).ToString();
        }

        private void BtnSale_Click(object sender, EventArgs e)
        {
            //1.会员主表余额变化、积分变化
            string checkedText = string.Empty;
            List<string> chkProjectList = new List<string>();//項目
            List<double> moneyList = new List<double>();//单价
            List<String> checkedTextList = new List<string>();
            DataTable dt = GetDgvToTable(dataGridView2);
            double saleMoney = 0D;//消费金额
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chkProjectList.Add(dt.Rows[i][0].ToString());
                    moneyList.Add(Convert.ToDouble(dt.Rows[i][1]));
                    saleMoney += Convert.ToDouble(dt.Rows[i][1]);
                }
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("请选择消费项目。", "非空提示", MessageBoxButtons.OK);
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
            for (int i = 0; i < chkProjects.Count; i++)
            {
                salePorject[salePorjectIndes] = chkProjects[i];
                salePorjectIndes += 1;
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
                Guid.NewGuid().ToString("N"), txtRemark.Text == "" ? "套餐" : txtRemark.Text, Convert.ToDouble(txtMoney.Text), newBlanceMoney, 0, addTime, vipId, vipName, txtRemark.Text
                , Program.userId, Program.userName, addTime, vipNo, ticketNo
                , txtDisc.Text, txtDiscMoney.Text, discSaleMoney);

            sqlList.Add(sqlBui.ToString());
            int result = DbHelperMySQL.ExecuteSqlTran(sqlList);
            if (result > 0)
            {
                string[] chkProjectList = { txtRemark.Text == "" ? "套餐" : txtRemark.Text };//項目
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
