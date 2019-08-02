using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace xinxingxiang
{
    public static class Program
    {
        public static string userId;
        public static string userName;
        public static string userloninName;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new login());

            FormLogin fl = new FormLogin();
            fl.ShowDialog();
            if (fl.DialogResult == DialogResult.OK)
            {
                Application.Run(new Main());
            }
            else
            {
                Application.Run(new FormLogin());
            }
        }

        public static string RunCmd(string strPath, string strcmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = strPath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.StandardInput.WriteLine(strcmd);
            p.StandardInput.WriteLine("exit");
            return p.StandardError.ReadToEnd();
        }

        public static void BackData(string remark)
        {
            try
            {
                //构建执行的命令
                StringBuilder sbcommand = new StringBuilder();

                string filePat = System.Windows.Forms.Application.StartupPath + @"\DBBak\" + DateTime.Now.ToString("yyyyMMddHHmmss") + remark + ".sql";
                sbcommand.AppendFormat("mysqldump -hlocalhost -P3306 -uroot -proot --default-character-set=utf8 xinxingxiang > {0}", filePat);
                String command = sbcommand.ToString();

                //获取mysqldump.exe所在路径
                //String appDirecroty = System.Windows.Forms.Application.StartupPath + "\\";
                String appDirecroty = ConfigurationManager.AppSettings["mySqlPath"].ToString();
                StartCmd(appDirecroty, command);
                //if (remark == "主动备份")
                //{
                MessageBox.Show(@"数据库已成功备份到 " + filePat + " 文件中", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库备份失败！");
            }
        }

        /// <summary>
        /// 执行Cmd命令
        /// </summary>
        /// <param name="workingDirectory">要启动的进程的目录</param>
        /// <param name="command">要执行的命令</param>
        public static void StartCmd(String workingDirectory, String command)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = workingDirectory;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(command);
            p.StandardInput.WriteLine("exit");
        }
    }
}
