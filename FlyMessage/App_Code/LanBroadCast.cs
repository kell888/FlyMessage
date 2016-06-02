using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

namespace FlyMessage
{
    internal class LanBroadCast
    {
        /// <summary>
        /// 广播
        /// </summary>
        public void BroadCast()
        {
            UdpClient udpClient = new UdpClient();
            string ip = GetIPv4();
            int port = 7999;
            string onlinePort = ConfigurationManager.AppSettings["onlinePort"];
            if (!string.IsNullOrEmpty(onlinePort))
                port = Convert.ToInt32(onlinePort);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
           
            FrmSetUp setUp = new FrmSetUp();
            string computerInfo = ":USER" + ":" + setUp.txtUserName.Text + ":" + Dns.GetHostName() + ":" +
            ip + ":" + setUp.txtWorkGroup.Text;

            byte[] buff = Encoding.Default.GetBytes(computerInfo);
            while (true)
            {
                udpClient.Send(buff, buff.Length, ep);
                Thread.Sleep(2000);
            }
        }
        public static string GetIPv4()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return IPAddress.Loopback.ToString();
        }
    }
}
