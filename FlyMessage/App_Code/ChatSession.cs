using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace FlyMessage
{
    /// <summary>
    /// 聊天会话
    /// </summary>
    class ChatSession
    {
        FrmMain owner;
        private static string fileName = string.Empty;
        private Socket chat;
        private string pack;
        /// <summary>
        /// 初始化构造方法
        /// </summary>
        /// <param name="chat">套接字</param>
        /// <param name="form">主窗体</param>
        public ChatSession(Socket chat, FrmMain owner)
        {
            this.chat = chat;
            this.owner = owner;
        }

        /// <summary>
        /// 对信息进行处理
        /// </summary>
        public void StartChat()
        {
            //获取远程主机的IP地址和端口号
            IPEndPoint ep = (IPEndPoint)chat.RemoteEndPoint;

            //设置
            byte[] buff = new byte[1024];
            int len;
            while ((len = chat.Receive(buff)) != 0)
            {
                string msg = Encoding.Default.GetString(buff, 0, len);
                pack = msg.Substring(0, 1);
                string cmd = msg.Substring(1, 3);
                if (cmd == "DAT")
                {
                    //if (DialogResult.Yes == MessageBox.Show(ep.Address.ToString() + "向你发送文件？", "发送文件", MessageBoxButtons.YesNoCancel))
                    //{
                    //fileName = Application.StartupPath + "\\temp";
                    string address = ep.Address.ToString();
                    if (owner.InvokeRequired)
                    {
                        owner.Invoke(new Action<string, byte[], int, string>(SaveFile), address, buff, len, msg);
                    }
                    else
                    {
                        SaveFile(address, buff, len, msg);
                    }
                    //}
                }
                else if (cmd == "MSG")
                {
                    msg = Encoding.Default.GetString(buff);
                    FrmMessage message = new FrmMessage(msg, pack);
                    message.ShowDialog();
                }
            }
            chat.Close();
        }

        private void SaveFile(string address, byte[] buff, int len, string msg)
        {
            using (SaveFileDialog sfdlg = new SaveFileDialog())
            {
                sfdlg.Title = address + "向你发送文件,保存在";
                sfdlg.Filter = "文件(*.*)|*.*";
                sfdlg.FileName = "save";
                if (sfdlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = sfdlg.FileName;
                    ReceiveFile(buff, len, msg);
                    //File.Move(fileName, sfdlg.FileName);
                }
                MessageBox.Show("保存完毕！");
            }
        }

        /// <summary>
        /// 接收文件
        /// </summary>
        /// <param name="buff">文件字节缓冲区</param>
        /// <param name="len">传输文件大小</param>
        /// <param name="msg">命令消息</param>
        private void ReceiveFile(byte[] buff, int len, string msg)
        {
            string extName = string.Empty;
            if (msg.IndexOf('.') >= 0)
            {
                extName = msg.Substring(msg.LastIndexOf('.'));//后缀名称
            }
            FileStream writer = new FileStream(fileName + extName, FileMode.OpenOrCreate, FileAccess.Write);
            while ((len = chat.Receive(buff)) != 0)
            {
                writer.Write(buff, 0, len);
            }
            writer.Write(buff, 0, len);
            writer.Close();
        }
    }
}
