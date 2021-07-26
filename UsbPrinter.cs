using System;
using System.Collections.Generic;
using System.IO;

namespace xinxingxiang
{
    public class UsbPrinter
    {
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct OVERLAPPED { int Internal; int InternalHigh; int Offset; int OffSetHigh; int hEvent; }
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool WriteFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten, out OVERLAPPED lpOverlapped);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool CloseHandle(int hObject);
        private int iHandle;

        public bool Open(string PNPDeviceID)
        {
            //{A5DCBF10-6530-11D2-901F-00C04FB951ED}是USB设备类的classID
            iHandle = CreateFile("\\\\.\\" + PNPDeviceID.Replace('\\', '#') + "#{A5DCBF10-6530-11D2-901F-00C04FB951ED}"
                , (uint)FileAccess.ReadWrite, 0, 0, (int)FileMode.Open, 0, 0);
            if (iHandle != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Write(string Mystring)
        {
            if (iHandle != -1)
            {
                int i; OVERLAPPED x;
                byte[] mybyte = System.Text.Encoding.Default.GetBytes(Mystring);
                return WriteFile(iHandle, mybyte, mybyte.Length, out i, out x);
            }
            else { throw new Exception("端口未打开。"); }
        }
        public bool Close()
        {
            return CloseHandle(iHandle);
        }

        /// <summary>
        /// 小票打印
        /// </summary>
        /// <param name="PNPDeviceID">驱动ID</param>
        /// <param name="saleTime">消费时间</param>
        /// <param name="ticketNo">小票编号</param>
        /// <param name="saleProject">消费项目</param>
        /// <param name="saleMoney">消费金额</param>
        /// <param name="blanceMoney">余额</param>
        /// <param name="vipNo">会员编号</param>
        /// <param name="vipUserName">会员姓名</param>
        /// <param name="remark">备注信息</param>
        /// <param name="loginUserName">当前登录人</param>
        public void BeginPrint(string PNPDeviceID, DateTime saleTime, String ticketNo, string[] saleProject, List<Double> moneys, string saleMoney, string blanceMoney, string vipNo, string vipUserName, string remark, string loginUserName, string disc, string discMoney)
        {
            //cmd += "\x0002" + "L" + "D11" + "\r\n" + "191108010000025ABCDEF" + "\r\n" + "E\r\n";
            string printStr = "\r\n";
            printStr += "      新形象发型设计工作室" + "\r\n";
            printStr += "            消费小票" + "\r\n";
            printStr += "================================" + "\r\n";
            printStr += "结账日期：" + saleTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
            printStr += "小票编号：" + ticketNo + "\r\n";
            printStr += "================================" + "\r\n";
            printStr += "项目                单价" + "\r\n";
            printStr += "--------------------------------" + "\r\n";
            for (int i = 0; i < saleProject.Length; i++)
            {
                string porjectName = saleProject[i].ToString();
                string money = moneys[i].ToString();
                printStr += porjectName + "                 " + money + "\r\n";
            }
            printStr += "--------------------------------" + "\r\n";
            printStr += "消费金额：￥" + saleMoney + "\r\n";
            if (disc != "10")
            {
                printStr += "折    扣：" + disc + "折\r\n";
            }
            else
            {
                printStr += "折    扣：无\r\n";
            }
            printStr += "折后金额：￥" + discMoney + "\r\n";
            printStr += "会员余额：￥" + blanceMoney + "\r\n";
            printStr += "会员编号：" + vipNo + "\r\n";
            printStr += "会员姓名：" + vipUserName + "\r\n";
            printStr += "\r\n";
            printStr += "消费签名：\r\n";
            printStr += "备注信息：" + remark + "\r\n";
            printStr += "================================" + "\r\n";
            printStr += "收银员：" + loginUserName + "\r\n";
            printStr += "请保存好您的小票\r\n";
            printStr += "感谢惠顾，欢迎您下次光临\r\n";
            printStr += "本程序归新形象发型设计工作室所有\r\n";
            printStr += "\r\n";
            printStr += "\r\n";
            printStr += "-----------我是底线-----------\r\n";
            printStr += "\r\n";
            printStr += "\r\n";
            printStr += "\r\n";
            if (!Open(PNPDeviceID))
            {
                return;
            }
            Write(printStr);
            if (!Close())
            {
                return;
            }
        }
    }
}
