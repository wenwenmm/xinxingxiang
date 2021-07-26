using System;
using System.Collections.Generic;
using System.Data;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace xinxingxiang
{
    public partial class VipUserAdd : Form
    {
        public VipUserAdd(string id)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(id))
            {
                string sql = string.Format("SELECT * FROM VIP_USER WHERE ID='{0}'", id);
                DataSet ds = DbHelperMySQL.Query(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtVipNo.Text = ds.Tables[0].Rows[0]["VIP_NO"].ToString();
                    txtVipName.Text = ds.Tables[0].Rows[0]["VIP_NAME"].ToString();
                    txtVipPhone.Text = ds.Tables[0].Rows[0]["VIP_PHONE"].ToString();
                    if (ds.Tables[0].Rows[0]["VIP_SEX"].ToString() == "0")
                    {
                        radWoMan.Checked = true;
                        radMan.Checked = false;
                    }
                    else
                    {
                        radMan.Checked = true;
                        radWoMan.Checked = false;
                    }
                    txtDiscRate.Text = ds.Tables[0].Rows[0]["VIP_DISC_RATE"].ToString();
                    //txtDiscRate.ReadOnly = true;
                    txtAddress.Text = ds.Tables[0].Rows[0]["VIP_ADDRESS"].ToString();
                    txtBlance.Text = ds.Tables[0].Rows[0]["VIP_BLAN_MONEY"].ToString();
                    txtBlance.ReadOnly = true;
                    txtRemark.Text = ds.Tables[0].Rows[0]["REMARK"].ToString();
                    lblId.Text = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                this.plID.Visible = true;
                this.Text = "会员修改";
            }
            else
            {
                this.plID.Visible = false;
                string vipNo = "0001";
                string sql = "SELECT COUNT(0) FROM VIP_USER ";
                DataSet ds = DbHelperMySQL.Query(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    vipNo = ds.Tables[0].Rows[0][0].ToString() == "0" ? "0001" : (Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1).ToString();
                }
                if (vipNo.Length == 1)
                {
                    vipNo = "000" + vipNo;
                }
                if (vipNo.Length == 2)
                {
                    vipNo = "00" + vipNo;
                }
                if (vipNo.Length == 3)
                {
                    vipNo = "0" + vipNo;
                }
                txtVipNo.Text = DateTime.Now.ToString("yyyyMMdd") + vipNo;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVipName.Text))
            {
                MessageBox.Show("会员姓名不能为空。", "非空提示", MessageBoxButtons.OK);
                txtVipName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtVipPhone.Text))
            {
                MessageBox.Show("会员电话不能为空。", "非空提示", MessageBoxButtons.OK);
                txtVipPhone.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtBlance.Text))
            {
                MessageBox.Show("会员余额不能为空。", "非空提示", MessageBoxButtons.OK);
                txtVipPhone.Focus();
                return;
            }
            int sex = radMan.Checked ? 1 : 0;
            string sqlStr = "";
            if (string.IsNullOrEmpty(lblId.Text))
            {
                //判定项目是否已经存在
                string sqlStr1 = string.Format(@"SELECT * FROM VIP_USER WHERE VIP_PHONE= '{0}'", txtVipPhone.Text);
                if (DbHelperMySQL.Query(sqlStr1).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("此电话号码的会员已经存在，请重新输入！", "保存提示", MessageBoxButtons.OK);
                    txtVipPhone.Focus();
                    return;
                }
                else
                {
                    StringBuilder sqlBui = new StringBuilder();
                    DateTime addTime = DateTime.Now;
                    string remark = txtRemark.Text;
                    string vipId = Guid.NewGuid().ToString("N");
                    sqlBui.Append(@"INSERT INTO VIP_USER(ID,VIP_NO,VIP_NAME,VIP_SEX,VIP_PHONE,VIP_ADDRESS
                                                    ,VIP_DISC_RATE,VIP_TOTAL_MONEY,VIP_BLAN_MONEY,REMARK,ADD_USER_ID,ADD_USER_NAME,ADD_TIME)");
                    sqlBui.AppendFormat(@"VALUES ('{0}','{1}','{2}',{3},'{4}','{5}',{6},{7},{8},'{9}','{10}','{11}','{12}');",
                        vipId, txtVipNo.Text, txtVipName.Text, sex, txtVipPhone.Text, txtAddress.Text
                        , Convert.ToDouble(txtDiscRate.Text), 0, Convert.ToDouble(txtBlance.Text), txtRemark.Text, Program.userId, Program.userName, addTime);

                    //创建会员添加一条消费记录
                    sqlBui.Append(@"INSERT INTO VIP_SALE(ID,SALE_PROJECT,SALE_MONEY,THIS_BLANCE_MONEY,VIP_POINT
                                                    ,SALE_DATE,VIP_ID,VIP_SALE_NAME,REMARK,ADD_USER_ID,ADD_USER_NAME,ADD_TIME,VIP_NO)");
                    sqlBui.AppendFormat(@"VALUES ('{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');",
                        Guid.NewGuid().ToString("N"), "入会充值", -Convert.ToDouble(txtBlance.Text), Convert.ToDouble(txtBlance.Text), 0, addTime, vipId, txtVipName.Text, txtRemark.Text, Program.userId, Program.userName, addTime, txtVipNo.Text);

                    sqlStr = sqlBui.ToString();
                }
            }
            else
            {
                sqlStr = string.Format(@"UPDATE VIP_USER SET 
                                         VIP_NAME='{0}',VIP_SEX={1},VIP_PHONE='{2}',VIP_ADDRESS='{3}',VIP_DISC_RATE={4},VIP_BLAN_MONEY={5},REMARK='{6}',EDIT_TIME='{7}'
                                        ,VIP_DISC_RATE={8}
                                         WHERE ID='{9}'",
                txtVipName.Text, radMan.Checked ? 1 : 0, txtVipPhone.Text, txtAddress.Text, Convert.ToDouble(txtDiscRate.Text), Convert.ToDouble(txtBlance.Text),
                   txtRemark.Text, DateTime.Now, Convert.ToDouble(txtDiscRate.Text), lblId.Text);
            }
            int result = DbHelperMySQL.ExecuteSql(sqlStr);
            if (result > 0)
            {
                Random r = new Random();
                int num = r.Next(10000, 99999);//随机生成一个5位整数
                string ticketNo = DateTime.Now.ToString("yyyyMMddHHmmss") + num;
                string[] salePorject = new string[1] { "入会充值" };
                List<double> moneyList = new List<double>();
                moneyList.Add(Convert.ToDouble(txtBlance.Text));
                SelectQuery selectQuery = new SelectQuery("Win32_USBHub");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
                foreach (ManagementObject disk in searcher.Get())
                {
                    string PNPDeviceID = disk["PNPDeviceID"] as String;
                    UsbPrinter usbPrint = new UsbPrinter();
                    usbPrint.BeginPrint(PNPDeviceID, DateTime.Now, ticketNo, salePorject, moneyList, txtBlance.Text, txtBlance.Text, txtVipNo.Text, txtVipName.Text, txtRemark.Text, Program.userName, txtDiscRate.Text, "0");
                }
                MessageBox.Show("保存成功。", "保存提示", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
