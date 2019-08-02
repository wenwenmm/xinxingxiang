using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xinxingxiang
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.toolStripStatusLabel1.Text = "欢迎：" + Program.userName + "，使用新形象会员管理系统";
            this.toolStripStatusLabel2.Text = "当前系统时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.timer1.Start();
            this.plProjectList.Visible = false;
            this.plVipUserList.Visible = false;
            this.toolStripStatusLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        }

        #region 显示当前时间
        /// <summary>
        /// 显示当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = "当前系统时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region 显示项目列表
        /// <summary>
        /// 显示项目列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmProjectList_Click(object sender, EventArgs e)
        {
            this.plVipUserList.Visible = false;
            this.plProjectList.Visible = true;
            bindProjectData(null, null);
        }
        #endregion

        #region 项目数据绑定
        /// <summary>
        /// 项目数据绑定
        /// </summary>
        /// <param name="projectName"></param>
        private void bindProjectData(string projectName, string status)
        {
            dgProjectList.Columns.Clear();
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(projectName))
            {
                strWhere += string.Format(@" AND PROJECT_NAME LIKE '%{0}%'", projectName);
            }
            if (!string.IsNullOrEmpty(status))
            {
                strWhere += string.Format(@" AND IS_DEL = {0}", status);
            }

            string strSql = string.Format(@"SELECT ID AS 系统编号, PROJECT_NAME AS 项目名称,UNIT_PRICE AS 单价,PROJECT_JIANCHENG AS 项目简称,ADD_USER_NAME AS 添加人,REMARK AS 备注内容
                                    ,CASE IS_DEL WHEN 0 THEN '未删除' ELSE '已删除' END 删除状态
                                    FROM PROJECT WHERE 1=1 {0} ORDER BY IS_DEL,ADD_TIME DESC ", strWhere);

            DataSet ds = DbHelperMySQL.Query(strSql);
            this.dgProjectList.DataSource = ds;
            this.dgProjectList.DataMember = ds.Tables[0].TableName;

            DataGridViewButtonColumn buttonsEdit = new DataGridViewButtonColumn();
            {
                buttonsEdit.HeaderText = "修改";
                buttonsEdit.Text = "修改";
                buttonsEdit.Name = "edit";
                buttonsEdit.UseColumnTextForButtonValue = true;
                buttonsEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttonsEdit.FlatStyle = FlatStyle.Popup;
                buttonsEdit.CellTemplate.Style.BackColor = Color.Honeydew;
                buttonsEdit.DisplayIndex = 8;
            }
            DataGridViewButtonColumn buttonsDel = new DataGridViewButtonColumn();
            {
                buttonsDel.HeaderText = "删除";
                buttonsDel.Text = "删除";
                buttonsDel.Name = "del";
                buttonsDel.UseColumnTextForButtonValue = true;
                buttonsDel.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttonsDel.FlatStyle = FlatStyle.Popup;
                buttonsDel.CellTemplate.Style.BackColor = Color.Honeydew;
                buttonsDel.DisplayIndex = 9;
            }
            DataGridViewButtonColumn buttonsRecover = new DataGridViewButtonColumn();
            {
                buttonsRecover.HeaderText = "恢复";
                buttonsRecover.Text = "恢复";
                buttonsRecover.Name = "recover";
                buttonsRecover.UseColumnTextForButtonValue = true;
                buttonsRecover.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttonsRecover.FlatStyle = FlatStyle.Popup;
                buttonsRecover.CellTemplate.Style.BackColor = Color.Honeydew;
                buttonsRecover.DisplayIndex = 10;
            }

            dgProjectList.Columns.Add(buttonsEdit);
            dgProjectList.Columns.Add(buttonsDel);
            dgProjectList.Columns.Add(buttonsRecover);
            autoSizeColumn(dgProjectList);
        }
        #endregion

        #region 项目列表修改删除
        /// <summary>
        /// 项目列表修改删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProjectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgProjectList.Columns[e.ColumnIndex].Name == "edit")
            {
                if (e.RowIndex >= 0)
                {
                    string id = dgProjectList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ProjectAdd form = new ProjectAdd(id);
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                    {
                        bindProjectData(null, null);
                    }
                }
            }
            if (this.dgProjectList.Columns[e.ColumnIndex].Name == "del")
            {
                if (e.RowIndex >= 0)
                {
                    if (dgProjectList.Rows[e.RowIndex].Cells[5].Value.ToString() == "已删除")
                    {
                        MessageBox.Show("本记录为无效数据，不能再次删除。", "系统提示", MessageBoxButtons.OK);
                        return;
                    }
                    if (MessageBox.Show("确定删除？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string id = dgProjectList.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string updateSql = string.Format("UPDATE PROJECT SET IS_DEL=1,EDIT_TIME='{1}' WHERE ID='{0}'", id, DateTime.Now);
                        if (DbHelperMySQL.ExecuteSql(updateSql) > 0)
                        {
                            MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK);
                            bindProjectData(null, null);
                        }
                    }
                }
            }
            if (this.dgProjectList.Columns[e.ColumnIndex].Name == "recover")
            {
                if (e.RowIndex >= 0)
                {
                    if (dgProjectList.Rows[e.RowIndex].Cells[5].Value.ToString() == "未删除")
                    {
                        MessageBox.Show("本记录为有效数据，不能再次恢复。", "系统提示", MessageBoxButtons.OK);
                        return;
                    }
                    if (MessageBox.Show("确定恢复？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string id = dgProjectList.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string updateSql = string.Format("UPDATE PROJECT SET IS_DEL=0,EDIT_TIME='{1}'WHERE ID='{0}'", id, DateTime.Now);
                        if (DbHelperMySQL.ExecuteSql(updateSql) > 0)
                        {
                            MessageBox.Show("恢复成功。", "恢复提示", MessageBoxButtons.OK);
                            bindProjectData(null, null);
                        }
                    }
                }
            }
        }
        #endregion

        #region 项目添加
        /// <summary>
        /// 项目添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmProjectAdd_Click(object sender, EventArgs e)
        {
            ProjectAdd form = new ProjectAdd(null);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                this.plProjectList.Visible = true;
                bindProjectData(null, null);
            }
        }
        #endregion

        #region 退出系统
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出系统？", "退出提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //备份数据库
                Program.BackData("退出备份");
                this.Close();
            }
        }
        #endregion

        #region 会员列表
        /// <summary>
        /// 会员列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmVipList_Click(object sender, EventArgs e)
        {
            this.plProjectList.Visible = false;
            this.plVipUserList.Visible = true;
            bindVipUserData(null, null, null, null);
        }
        #endregion

        #region 项目查询
        /// <summary>
        /// 项目查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchPro_Click(object sender, EventArgs e)
        {
            string status = "";
            if (cmbStatus.Text == "已删除")
            {
                status = "1";
            }
            else if (cmbStatus.Text == "未删除")
            {
                status = "0";
            }
            bindProjectData(this.txtProjectName.Text, status);
        }
        #endregion

        #region 会员查询
        /// <summary>
        /// 会员查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchVip_Click(object sender, EventArgs e)
        {
            string status = "";
            if (cmbVipStatus.Text == "已删除")
            {
                status = "1";
            }
            else if (cmbVipStatus.Text == "未删除")
            {
                status = "0";
            }
            bindVipUserData(this.txtNo.Text, this.txtVipName.Text, this.txtPhone.Text, status);
        }
        #endregion

        #region 会员添加
        /// <summary>
        /// 会员添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmVipAdd_Click(object sender, EventArgs e)
        {
            VipUserAdd form = new VipUserAdd(null);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                this.plVipUserList.Visible = true;
                bindVipUserData(null, null, null, null);
            }
        }
        #endregion

        #region 会员数据绑定
        /// <summary>
        /// 会员数据绑定
        /// </summary>
        /// <param name="vipNo"></param>
        /// <param name="vipName"></param>
        /// <param name="vipPhone"></param>
        /// <param name="status"></param>
        private void bindVipUserData(string vipNo, string vipName, string vipPhone, string status)
        {
            dgVipUserList.Columns.Clear();
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(vipNo))
            {
                strWhere += string.Format(@" AND VIP_NO LIKE '%{0}%'", vipNo);
            }
            if (!string.IsNullOrEmpty(vipName))
            {
                strWhere += string.Format(@" AND VIP_NAME LIKE '%{0}%'", vipName);
            }
            if (!string.IsNullOrEmpty(vipPhone))
            {
                strWhere += string.Format(@" AND VIP_PHONE LIKE '%{0}%'", vipPhone);
            }
            if (!string.IsNullOrEmpty(status))
            {
                strWhere += string.Format(@" AND IS_DEL = {0}", status);
            }

            string strSql = string.Format(@"SELECT ID AS 系统编号, VIP_NO AS 会员卡号,VIP_NAME AS 会员姓名,VIP_PHONE AS 会员电话
                                            ,CASE VIP_SEX WHEN 0 THEN '女' ELSE '男' END 性别,VIP_DISC_RATE AS `会员折扣`,VIP_BLAN_MONEY AS 会员余额
                                            ,CASE IS_DEL WHEN 0 THEN '未删除' ELSE '已删除' END 删除状态
                                            FROM VIP_USER WHERE 1=1 {0} ORDER BY IS_DEL,VIP_NO,VIP_SEX,ADD_TIME DESC ", strWhere);

            DataSet ds = DbHelperMySQL.Query(strSql);
            this.dgVipUserList.DataSource = ds;
            this.dgVipUserList.DataMember = ds.Tables[0].TableName;

            DataGridViewButtonColumn buttonsSale = new DataGridViewButtonColumn();
            {
                buttonsSale.HeaderText = "消费明细";
                buttonsSale.Text = "消费明细";
                buttonsSale.Name = "sale";
                buttonsSale.UseColumnTextForButtonValue = true;
                buttonsSale.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttonsSale.FlatStyle = FlatStyle.Popup;
                buttonsSale.CellTemplate.Style.BackColor = Color.Honeydew;
                buttonsSale.DisplayIndex = 8;
            }

            DataGridViewButtonColumn buttonsEdit = new DataGridViewButtonColumn();
            {
                buttonsEdit.HeaderText = "修改";
                buttonsEdit.Text = "修改";
                buttonsEdit.Name = "edit";
                buttonsEdit.UseColumnTextForButtonValue = true;
                buttonsEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttonsEdit.FlatStyle = FlatStyle.Popup;
                buttonsEdit.CellTemplate.Style.BackColor = Color.Honeydew;
                buttonsEdit.DisplayIndex = 9;
            }
            DataGridViewButtonColumn buttonsDel = new DataGridViewButtonColumn();
            {
                buttonsDel.HeaderText = "删除";
                buttonsDel.Text = "删除";
                buttonsDel.Name = "del";
                buttonsDel.UseColumnTextForButtonValue = true;
                buttonsDel.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttonsDel.FlatStyle = FlatStyle.Popup;
                buttonsDel.CellTemplate.Style.BackColor = Color.Honeydew;
                buttonsDel.DisplayIndex = 10;
            }
           
            DataGridViewButtonColumn buttonsRecover = new DataGridViewButtonColumn();
            {
                buttonsRecover.HeaderText = "恢复";
                buttonsRecover.Text = "恢复";
                buttonsRecover.Name = "recover";
                buttonsRecover.UseColumnTextForButtonValue = true;
                buttonsRecover.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttonsRecover.FlatStyle = FlatStyle.Popup;
                buttonsRecover.CellTemplate.Style.BackColor = Color.Honeydew;
                buttonsRecover.DisplayIndex = 12;
            }
            if (Program.userloninName == "admin")//只有系统管理员才有消费管理权限
            {
                dgVipUserList.Columns.Add(buttonsSale);
            }
            dgVipUserList.Columns.Add(buttonsEdit);
            dgVipUserList.Columns.Add(buttonsDel);
            dgVipUserList.Columns.Add(buttonsRecover);
            autoSizeColumn(dgVipUserList);
        }
        #endregion

        #region 会员删除修改
        /// <summary>
        /// 会员删除修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgVipUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgVipUserList.Columns[e.ColumnIndex].Name == "edit")
            {
                if (e.RowIndex >= 0)
                {
                    string id = dgVipUserList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    VipUserAdd form = new VipUserAdd(id);
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                    {
                        bindVipUserData(null, null, null, null);
                    }
                }
            }
            if (this.dgVipUserList.Columns[e.ColumnIndex].Name == "del")
            {
                if (e.RowIndex >= 0)
                {
                    if (dgVipUserList.Rows[e.RowIndex].Cells[7].Value.ToString() == "已删除")
                    {
                        MessageBox.Show("本记录为无效数据，不能再次删除。", "系统提示", MessageBoxButtons.OK);
                        return;
                    }
                    if (MessageBox.Show("确定删除？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string id = dgVipUserList.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string updateSql = string.Format("UPDATE VIP_USER SET IS_DEL=1,EDIT_TIME='{1}' WHERE ID='{0}'", id, DateTime.Now);
                        if (DbHelperMySQL.ExecuteSql(updateSql) > 0)
                        {
                            MessageBox.Show("删除成功！", "删除提示", MessageBoxButtons.OK);
                            bindVipUserData(null, null, null, null);
                        }
                    }
                }

            }
            if (this.dgVipUserList.Columns[e.ColumnIndex].Name == "recover")
            {
                if (e.RowIndex >= 0)
                {
                    if (dgVipUserList.Rows[e.RowIndex].Cells[7].Value.ToString() == "未删除")
                    {
                        MessageBox.Show("本记录为有效数据，不能再次恢复。", "系统提示", MessageBoxButtons.OK);
                        return;
                    }
                    if (MessageBox.Show("确定恢复？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string id = dgVipUserList.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string updateSql = string.Format("UPDATE VIP_USER SET IS_DEL=0,EDIT_TIME='{1}' WHERE ID='{0}'", id, DateTime.Now);
                        if (DbHelperMySQL.ExecuteSql(updateSql) > 0)
                        {
                            MessageBox.Show("恢复成功！", "恢复提示", MessageBoxButtons.OK);
                            bindVipUserData(null, null, null, null);
                        }
                    }
                }

            }
            if (this.dgVipUserList.Columns[e.ColumnIndex].Name == "sale")
            {
                if (e.RowIndex >= 0)
                {
                    string id = dgVipUserList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string vipNo = dgVipUserList.Rows[e.RowIndex].Cells[1].Value.ToString();
                    VipUserSaleDetial form = new VipUserSaleDetial(id);
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                    {
                        this.plVipUserList.Visible = true;
                        txtNo.Text = vipNo;
                        bindVipUserData(vipNo, null, null, null);
                    }
                }
            }
        }
        #endregion

        #region 项目添加
        /// <summary>
        /// 项目添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectAdd_Click(object sender, EventArgs e)
        {
            ProjectAdd form = new ProjectAdd(null);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                this.plProjectList.Visible = true;
                bindProjectData(null, null);
            }
        }
        #endregion

        #region 项目搜索条件
        /// <summary>
        /// 项目搜索条件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtProjectName.Text = null;
            cmbStatus.Text = "全部";
        }
        #endregion

        #region 会员搜索重置
        /// <summary>
        /// 会员搜索重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVipReset_Click(object sender, EventArgs e)
        {
            txtNo.Text = null;
            txtPhone.Text = null;
            txtVipName.Text = null;
            cmbVipStatus.Text = "全部";
        }
        #endregion

        #region 添加会员
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVipAdd_Click(object sender, EventArgs e)
        {
            VipUserAdd form = new VipUserAdd(null);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                this.plVipUserList.Visible = true;
                bindVipUserData(null, null, null, null);
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

        #region 数据库备份
        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlDbBack_Click(object sender, EventArgs e)
        {
            //备份数据库
            Program.BackData("主动备份");
        }
        #endregion

        #region 显示所有人员
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtNo.Text = null;
            txtPhone.Text = null;
            txtVipName.Text = null;
            cmbVipStatus.Text = "全部";
            this.plProjectList.Visible = false;
            this.plVipUserList.Visible = true;
            bindVipUserData(null, null, null, null);
        }
        #endregion
    }
}
