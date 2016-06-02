using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Configuration;

namespace FlyMessage
{
   internal class UdpThread
    {
        private FrmMain owner;

        public UdpThread(FrmMain owner)
        {
            this.owner = owner;
        }

       /// <summary>
       /// 启动udp通信线程
       /// </summary>
        public void StartUdpThread()
        {
            int port = 7999;
            string onlinePort = ConfigurationManager.AppSettings["onlinePort"];
            if (!string.IsNullOrEmpty(onlinePort))
                port = Convert.ToInt32(onlinePort);
            UdpClient server = new UdpClient(port);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            string user = string.Empty;
            string cmd = string.Empty;
            string user1 = string.Empty;
            byte[] buff = null;
            string[] userlist = null;
            ListViewItem lviUserName = null;

            while (true)
            {
                buff = server.Receive(ref ep);
                user = Encoding.Default.GetString(buff);
                cmd = user.Substring(0, 6);
                user1 = user.Substring(6);
                if (cmd == ":USER:")
                {
                    try
                    {
                        userlist = user1.Split(':');
                        lviUserName = new ListViewItem();
                        ListViewItem.ListViewSubItem lvsiComputerName = new ListViewItem.ListViewSubItem();
                        ListViewItem.ListViewSubItem lvsiIP = new ListViewItem.ListViewSubItem();
                        ListViewItem.ListViewSubItem lvsiWorkGroup = new ListViewItem.ListViewSubItem();
                        lviUserName.Text = userlist[0];
                        lvsiComputerName.Text = userlist[1];
                        lvsiIP.Text = userlist[2];
                        lvsiWorkGroup.Text = userlist[3];
                        lviUserName.SubItems.Add(lvsiComputerName);
                        lviUserName.SubItems.Add(lvsiIP);
                        lviUserName.SubItems.Add(lvsiWorkGroup);
                        if (owner.InvokeRequired)
                        {
                            owner.Invoke(new Action<ListViewItem, ListViewItem.ListViewSubItem>(UpdateUserList), lviUserName, lvsiIP);
                        }
                        else
                        {
                            UpdateUserList(lviUserName, lvsiIP);
                        }
                    }
                    catch// (Exception e)
                    {
                        MessageBox.Show("有位朋友下线了！");
                    }
                }
            }
        }

        private void UpdateUserList(ListViewItem lviUserName, ListViewItem.ListViewSubItem lvsiIP)
        {
            //if (this.owner.lvwDisplayUser.FindItemWithText(lvsiIP.Text) == null)
            //{
            //    this.owner.lvwDisplayUser.Items.Add(lviUserName);
            //}
            bool flag = true;
            for (int i = 0; i < this.owner.lvwDisplayUser.Items.Count; i++)
            {
                if (lvsiIP.Text == this.owner.lvwDisplayUser.Items[i].SubItems[2].Text)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                this.owner.lvwDisplayUser.Items.Add(lviUserName);
            }
            this.owner.lblUserCount.Text = "在线人数：" + this.owner.lvwDisplayUser.Items.Count;
        }
    }
}
