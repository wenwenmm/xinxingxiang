using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

namespace xinxingxiang
{
    public class DalSql
    { //链接数据库对象
        public SqlConnection con;


        #region 封装连接数据库的打开和关闭方法


        //创建并打开连接数据库的对象【如果con为空那么就创建一个对象，如果con的状态为关闭状态就打开它】
        private void ConOpen()
        {
            try
            {
                if (this.con == null)
                {
                    string ConnString = ConfigurationManager.ConnectionStrings["ConnectionStringxinxingxiang"].ConnectionString.ToString();

                    //实例化链接数据库对象
                    con = new SqlConnection(ConnString);
                    con.Open();
                }
                else
                {
                    if (this.con.State == ConnectionState.Closed)
                    {
                        this.con.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //关闭连接数据库的对象
        private void ConClose()
        {
            //如果链接数据库对象的状态是打开的那么就关闭它
            if (this.con.State == ConnectionState.Open)
            {
                this.con.Close();
            }
        }

        //创建新的存储过程参数
        /// <summary>
        /// 存储过程参数名，字段类型，长度
        /// </summary>
        /// <param name="ParamName">存储参数名</param>
        /// <param name="DbType">字段</param>
        /// <param name="Size">长度</param>
        /// <returns>SqlParameter</returns>
        private SqlParameter CreateSqlParamenter(string ParamName, SqlDbType DbType, Int32 Size)
        {
            if (Size > 0)
            {
                return new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                return new SqlParameter(ParamName, DbType);
            }
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="StartIndex"></param>
        /// <param name="PartNum"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public DataSet QueryByFind(string Sql, Int32 StartIndex, Int32 PartNum, string TableName)
        {
            DataSet ds = new DataSet();
            try
            {
                ConOpen();
                SqlDataAdapter MyDA = new SqlDataAdapter();
                MyDA.SelectCommand = new SqlCommand(Sql, con);
                MyDA.Fill(ds, StartIndex, PartNum, TableName);
            }
            catch (Exception ex)
            {
                ds.Dispose();
                throw ex;
            }
            finally
            {
                this.ConClose();
            }

            return ds;
        }
        #endregion

        //    数据层通用接口，如有做更改请写下更改原因
        //    不是特别需要不对此进行增加或是删除或是修改

        #region  执行存储过程,返回数据集或是影响行数，执行单一SQL，执行SQL返回数据集

        /// <summary>
        /// 生成存储过程中的参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="size">大小</param>
        /// <param name="ParamDirection">参数的具体情况【输入(Input)、输出(Output)、输入输出(InputOutput)、返回值(ReturnValue)】</param>
        /// <param name="value">参数具体值</param>
        /// <returns></returns>
        public SqlParameter SetParameter(string paramName, SqlDbType dbType, Int32 size, string ParamDirection, object value)
        {
            SqlParameter Parameter = CreateSqlParamenter(paramName, dbType, size);
            switch (ParamDirection)
            {
                case "Input": Parameter.Direction = ParameterDirection.Input; Parameter.Value = value; break;
                case "InputOutput": Parameter.Direction = ParameterDirection.InputOutput; Parameter.Value = value; break;
                case "Output": Parameter.Direction = ParameterDirection.Output; break;
                case "ReturnValue": Parameter.Direction = ParameterDirection.ReturnValue; Parameter.Value = value; break;
            }
            return Parameter;
        }



        /// <summary>
        /// 生成一个执行【insert、delete、update】存储过程的方法【返回值为整型】
        /// 1为执行的存储过程成功，-1为不成功 存储过程中OUTPUT的变量必须为[@out]
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="paras">参数数组名称</param>
        /// <returns></returns>
        public string RunProc(string procName, SqlParameter[] paras)
        {
            ConOpen();

            SqlCommand com = new SqlCommand(procName, con);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandTimeout = 600;
            if (paras != null)
            {
                foreach (SqlParameter Para in paras)
                {
                    com.Parameters.Add(Para);
                }
            }

            try
            {
                com.ExecuteNonQuery();//执行存储过程
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConClose();//关闭数据库连接
            }


            return com.Parameters["@out"].Value.ToString();//返回存储过程中返回的值
        }







        /// <summary>
        /// 
        /// 若有多个输出参数，返回一个list。
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="paras">参数数组名称</param>        
        public ArrayList RuturnProc(string procName, SqlParameter[] paras)
        {
            ArrayList list = new ArrayList();
            ConOpen();

            SqlCommand com = new SqlCommand(procName, con);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandTimeout = 600;
            if (paras != null)
            {
                foreach (SqlParameter Para in paras)
                {
                    com.Parameters.Add(Para);
                }
            }

            try
            {
                com.ExecuteNonQuery();//执行存储过程
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConClose();//关闭数据库连接
            }




            if (paras != null)
            {
                foreach (SqlParameter Para in paras)
                {
                    if (Para.Direction == ParameterDirection.Output)
                        list.Add(Para.Value.ToString());
                }
            }
            return list;
        }






        /// <summary>
        /// 执行存储过程，并返回数据集
        /// </summary>
        /// <param name="ProcName">存储过程名</param>
        /// <param name="Paras">参数集</param>
        /// <returns>存储过程中返回的数据集</returns>
        public DataSet RunProSel(string ProcName, SqlParameter[] Paras)
        {
            ConOpen();
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter Sda = new SqlDataAdapter();
                SqlCommand com = new SqlCommand(ProcName, con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 600;
                if (Paras != null)
                {
                    foreach (SqlParameter Para in Paras)
                    {
                        com.Parameters.Add(Para);
                    }
                }
                Sda.SelectCommand = com;
                Sda.SelectCommand.ExecuteNonQuery();
                Sda.Fill(ds, "T");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ConClose();
            }

            return ds;
        }

        /// <returns>存储过程中返回的值</returns>
        public string RunProGetValue(string ProcName, SqlParameter[] Paras)
        {
            string returnvalue = "";
            ConOpen();

            try
            {
                SqlParameter rtnval = new SqlParameter("rval", SqlDbType.Int);
                rtnval.Direction = ParameterDirection.ReturnValue;
                SqlCommand com = new SqlCommand(ProcName, con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 600;
                if (Paras != null)
                {
                    foreach (SqlParameter Para in Paras)
                    {
                        com.Parameters.Add(Para);
                    }
                    com.Parameters.Add(rtnval);
                }

                com.ExecuteNonQuery();//执行存储过程
                returnvalue = rtnval.Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
                //returnvalue = "连接服务器超时";
            }
            finally
            {
                ConClose();
            }

            return returnvalue;
        }


        /// <summary>
        /// 执行参数化sql语句
        /// </summary>
        /// <param name="commandText">命令文本</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="paras">参数集</param>
        /// <returns>所影响的行数</returns>
        public int ExecuteParasSqlText(string commandText, CommandType commandType, SqlParameter[] paras)
        {
            ConOpen();
            Int32 i = -1;

            //实例化执行Sql命令语句对象
            SqlCommand com = this.con.CreateCommand();
            com.CommandText = commandText;
            com.CommandType = commandType;
            com.CommandTimeout = 600;
            //参数
            if (paras != null)
            {
                com.Parameters.Clear();
                foreach (SqlParameter para in paras)
                {
                    com.Parameters.Add(para);
                }
            }

            try
            {
                i = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ConClose();
            }

            return i;
        }



        /// <summary>
        /// 执行存储过程，不需要返回数据集，只返回影响的记录行数
        /// </summary>
        /// <param name="ProcName">存储过程名</param>
        /// <param name="Paras">存储过程的参数集</param>
        /// <returns>程序影响的行数</returns>
        public Int32 RunProExec(string ProcName, SqlParameter[] Paras)
        {

            ConOpen();
            DataSet ds = new DataSet();
            Int32 i = -1;
            try
            {
                SqlDataAdapter Sda = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.CommandText = ProcName;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 600;
                Sda.SelectCommand = com;
                if (Paras != null)
                {
                    foreach (SqlParameter Para in Paras)
                    {
                        Sda.SelectCommand.Parameters.Add(Para);
                    }
                }

                i = Sda.SelectCommand.ExecuteNonQuery();
                Sda.Fill(ds, "T");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConClose();
            }

            return i;
        }

        /// <summary>
        /// 查询数据库中部分数据 返回[PartNum]条记录
        /// </summary>
        /// <param name="Sql">查询语句</param>
        /// <param name="StartIndex">起始记录数</param>
        /// <param name="PartNum">返回的记录条数</param>
        /// <param name="TableName">返回的表格名</param>


        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>返回[DATASET]数据集表名为“T”</returns>
        public DataSet QueryByFind(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                //打开连接
                this.ConOpen();

                SqlDataAdapter sda = new SqlDataAdapter(sql, this.con);

                sda.Fill(ds, "T");


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //关闭连接
                this.ConClose();
            }
            return ds;
        }

        public DataSet QueryByFind(string sqlStr, SqlParameter[] pars)
        {
            DataSet ds = new DataSet();
            try
            {
                ConOpen();

                SqlCommand command = new SqlCommand(sqlStr, con);
                command.Parameters.AddRange(pars);

                SqlDataAdapter MyDA = new SqlDataAdapter(command);

                MyDA.Fill(ds);
            }
            catch (Exception ex)
            {
                ConClose();
                ds.Dispose();
                throw ex;
            }
            finally
            {
                this.ConClose();
            }
            return ds;
        }

        public DataSet QueryByFind(string sqlStr, SqlParameter[] pars, Int32 StartIndex, Int32 PartNum, string TableName)
        {
            DataSet ds = new DataSet();
            try
            {
                ConOpen();

                SqlCommand command = new SqlCommand(sqlStr, con);
                command.Parameters.AddRange(pars);

                SqlDataAdapter MyDA = new SqlDataAdapter(command);

                MyDA.Fill(ds, StartIndex, PartNum, TableName);
            }
            catch (Exception ex)
            {
                ConClose();
                ds.Dispose();
                throw ex;
            }
            finally
            {
                this.ConClose();
            }
            return ds;
        }



        /// <summary>
        /// 查询或是执行SQL语句
        /// 事务处理，有错则回滚
        /// 返回整型，-1为执行不成功
        /// </summary>
        /// <param name="sql">查询或执行的句子</param>
        /// <returns>返回整型，-1为执行不成功</returns>
        public int QueryExecTran(string sql)
        {
            //打开链接
            this.ConOpen();
            SqlTransaction transaction = con.BeginTransaction();

            //实例化执行Sql命令语句对象
            SqlCommand com = this.con.CreateCommand();
            com.Transaction = transaction;
            com.CommandText = sql;
            com.CommandType = CommandType.Text;
            com.CommandTimeout = 600;
            int i = -1;
            try
            {
                i = com.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                //关闭连接
                this.ConClose();
            }

            return i;
        }

        #endregion

        #region 解除锁定处理
        public int DisLockCust(int per_id, int ctm_id, string lock_type)
        {
            int i = 0;
            string sql = "DisLock_ctm";
            SqlCommand command = new SqlCommand(sql);
            SqlParameter per = new SqlParameter("@oper_id", SqlDbType.Int, 4);
            SqlParameter ctm = new SqlParameter("@ctm_id", SqlDbType.Int, 4);
            SqlParameter loc = new SqlParameter("@lock_type", SqlDbType.VarChar, 50);
            per.Value = per_id;
            ctm.Value = ctm_id;
            loc.Value = lock_type;
            command.Parameters.Add(per);
            command.Parameters.Add(ctm);
            command.Parameters.Add(loc);
            command.CommandType = CommandType.StoredProcedure;

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                command.Connection = conn;
                conn.Open();
                i = command.ExecuteNonQuery();
            }
            return i;

        }
        #endregion

        #region  新增底层处理函数
        /// <summary>
        /// 判断记录是否存在 底层函数名称不按规范改了，改动较多 东旭 2015 1 31
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>存在 true 不存在 false</returns>
        public bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {
            //打开链接
            this.ConOpen();
            SqlCommand cmd = new SqlCommand(SQLString, con);
            try
            {
                object obj = cmd.ExecuteScalar();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                //connection.Close();
                throw e;
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询的首行首列结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            //打开链接
            this.ConOpen();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, con, null, SQLString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    this.ConClose();
                }
            }

        }

        /// <summary>
        /// cmd对象绑定参数
        /// </summary>
        /// <param name="cmd">命令对象</param>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="trans">事物对象</param>
        /// <param name="cmdText">文档模式</param>
        /// <param name="cmdParms">参数</param>
        public void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            //打开链接
            this.ConOpen();

            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, con, null, SQLString, cmdParms);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    this.ConClose();
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            //打开链接
            this.ConOpen();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, con, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    this.ConClose();
                }
            }
        }

        #endregion
    }
}
