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
    public partial class VipUserSaleDetial : Form
    {
        private string vipId = "";

        public VipUserSaleDetial(string id)
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
                }
                bindVipSaleData(id, "");
            }
        }

        #region 绑定会员消费信息
        private void bindVipSaleData(string vipId, string tickNo)
        {
            this.dgSaleList.DataSource = null;
            this.dgSaleList.DataMember = null;
            dgSaleList.Columns.Clear();
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(vipId))
            {
                strWhere += string.Format(@" AND VIP_ID = '{0}'", vipId);
            }
            if (!string.IsNullOrEmpty(tickNo))
            {
                strWhere += string.Format(@" AND TICKET_NO LIKE '{0}%'", tickNo);
            }
            string strSql = string.Format(@"SELECT S.ID 消费编号,S.VIP_NO AS 会员编号,S.SALE_PROJECT AS 消费项目,S.SALE_DATE AS 消费时间
                                            ,S.SALE_MONEY AS 消费金额,S.VIP_DISC_RATE AS 折扣,S.DISC_MONEY AS 折后金额
                                            ,S.THIS_BLANCE_MONEY AS 消费后余额
                                            ,U.VIP_NAME 会员姓名,S.VIP_SALE_NAME AS 消费人员,S.TICKET_NO 小票编号,S.REMARK 备注 FROM VIP_SALE S
                                            INNER JOIN VIP_USER U ON S.VIP_ID=U.ID WHERE 1=1 {0} ORDER BY SALE_DATE DESC;", strWhere);

            DataSet ds = DbHelperMySQL.Query(strSql);
            this.dgSaleList.DataSource = ds;
            this.dgSaleList.DataMember = ds.Tables[0].TableName;
            DataGridViewButtonColumn buttonsPrint = new DataGridViewButtonColumn();
            {
                buttonsPrint.HeaderText = "补打小票";
                buttonsPrint.Text = "补打小票";
                buttonsPrint.Name = "print";
                buttonsPrint.UseColumnTextForButtonValue = true;
                buttonsPrint.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttonsPrint.FlatStyle = FlatStyle.Popup;
                buttonsPrint.CellTemplate.Style.BackColor = Color.Honeydew;
                buttonsPrint.DisplayIndex = 11;
            }
            dgSaleList.Columns.Add(buttonsPrint);
            autoSizeColumn(dgSaleList);
        }
        #endregion

        #region 添加消费记录
        /// <summary>
        /// 添加消费记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSale_Click(object sender, EventArgs e)
        {
            SaleAdd form = new SaleAdd(vipId);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                bindVipSaleData(vipId, "");
            }
        }
        #endregion

        #region 充值
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMoney_Click(object sender, EventArgs e)
        {
            AddMoney form = new AddMoney(vipId);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                string sql = string.Format("SELECT * FROM VIP_USER WHERE ID='{0}'", vipId);
                DataSet ds = DbHelperMySQL.Query(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    bindVipSaleData(vipId, "");
                }
            }
        }
        #endregion

        #region 使DataGridView的列自适应宽度
        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        private void autoSizeColumn(DataGridView dgViewFiles)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgViewFiles.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            //dgViewFiles.Columns[1].Frozen = true;
        }
        #endregion

        #region 打印小票
        private void dgSaleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgSaleList.Columns[e.ColumnIndex].Name == "print")
            {
                if (e.RowIndex >= 0)
                {
                    string id = dgSaleList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string id1 = dgSaleList.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string sqlStr = string.Format(@"SELECT U.VIP_NO,U.VIP_NAME,S.SALE_PROJECT,S.SALE_DATE,S.TICKET_NO
                                                    ,S.SALE_MONEY,S.THIS_BLANCE_MONEY,S.REMARK 
                                                    ,S.SALE_MONEY_LIST,S.VIP_DISC_RATE,S.DISC_MONEY
                                                    FROM VIP_USER U
                                                    INNER JOIN VIP_SALE S
                                                    ON U.ID=S.VIP_ID WHERE S.ID='{0}' or S.ID='{1}'", id, id1);
                    DataSet ds = DbHelperMySQL.Query(sqlStr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string printVipNo = ds.Tables[0].Rows[0]["VIP_NO"].ToString();
                        string printVipName = ds.Tables[0].Rows[0]["VIP_NAME"].ToString();
                        string[] salePorject = ds.Tables[0].Rows[0]["SALE_PROJECT"].ToString().Split('+');
                        string[] moneys = ds.Tables[0].Rows[0]["SALE_MONEY_LIST"].ToString().Split('+');
                        List<Double> moneyList = new List<double>();
                        for (int i = 0; i < moneys.Length; i++)
                        {
                            moneyList.Add(Convert.ToDouble(moneys[i]));
                        }
                        DateTime saleTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["SALE_DATE"]);
                        string ticketNo = ds.Tables[0].Rows[0]["TICKET_NO"].ToString();

                        string money = ds.Tables[0].Rows[0]["SALE_MONEY"].ToString().Replace("-", "");
                        string blanceMoney = ds.Tables[0].Rows[0]["THIS_BLANCE_MONEY"].ToString();
                        string remark = ds.Tables[0].Rows[0]["REMARK"].ToString();
                        string disc = ds.Tables[0].Rows[0]["VIP_DISC_RATE"].ToString();
                        string discMoney = ds.Tables[0].Rows[0]["DISC_MONEY"].ToString();
                        SelectQuery selectQuery = new SelectQuery("Win32_USBHub");
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
                        foreach (ManagementObject disk in searcher.Get())
                        {
                            string PNPDeviceID = disk["PNPDeviceID"] as String;
                            UsbPrinter usbPrint = new UsbPrinter();
                            usbPrint.BeginPrint(PNPDeviceID, saleTime, ticketNo, salePorject, moneyList, money, blanceMoney.ToString(), printVipNo, printVipName, remark, Program.userName, disc, discMoney);
                        }

                        MessageBox.Show("打印成功。");
                    }
                }
            }
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindVipSaleData(vipId, this.txtTicketNo.Text);
        }
        #endregion
    }
}
