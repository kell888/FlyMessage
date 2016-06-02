using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
namespace FlyMessage
{
    internal class SentLanFile
    {
        private OpenFileDialog dlg;
        private Socket socketSent;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dlg"></param>
        /// <param name="socketSent"></param>
        public SentLanFile(OpenFileDialog dlg, Socket socketSent)
        {
            this.dlg = dlg;
            this.socketSent = socketSent;
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        public void SentFile()
        {
            string msg = "0DAT" + dlg.FileName;

            //将 "msg" 转化为字节流的形式进行传送
            socketSent.Send(Encoding.Default.GetBytes(msg));

            //定义一个读文件流
            FileStream read = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

            //设置缓冲区为1024byte
            byte[] buff = new byte[1024];
            int len = 0;
            while ((len = read.Read(buff, 0, 1024)) != 0)
            {
                //按实际的字节总量发送信息
                socketSent.Send(buff, 0, len, SocketFlags.None);
            }
            socketSent.Close();
            read.Close();
        }
    }
}
