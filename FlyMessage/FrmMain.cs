using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Configuration;

namespace FlyMessage
{
    public partial class FrmMain : Form
    {
        ///// <summary>
        ///// 皮肤控件
        ///// </summary>
        //private Sunisoft.IrisSkin.SkinEngine skinEngine1;

        /// <summary>
        /// 定义作为服务器端接受信息套接字
        /// </summary>
        public Socket socketReceive = null;

        /// <summary>
        /// 定义作为客户端发送信息套接字
        /// </summary>
        public Socket socketSent = null;

        /// <summary>
        /// 定义接受信息的IP地址和端口号
        /// </summary>
        public IPEndPoint ipReceive = null;

        /// <summary>
        /// 定义发送信息的IP地址和端口号
        /// </summary>
        public IPEndPoint ipSent = null;

        /// <summary>
        /// 定义接受信息的套接字
        /// </summary>
        public Socket chat = null;
       
        //定义是否封装
        public string  pack = "0";

        //public static Thread tBroadCast;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            //this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            //this.skinEngine1.SkinFile = "Midsummer.ssk";
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            UdpThread startUdpThread = new UdpThread(this);
            Thread tUdpThread = new Thread(new ThreadStart(startUdpThread.StartUdpThread));
            tUdpThread.IsBackground = true;
            tUdpThread.Start();

            LanBroadCast broadCast = new LanBroadCast();
            Thread tBroadCast = new Thread(new ThreadStart(broadCast.BroadCast));
            tBroadCast.IsBackground = true;
            tBroadCast.Start();

            Thread receive = new Thread(new ThreadStart(ReceiveNews));
            receive.IsBackground = true;
            receive.Start();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < this.lvwDisplayPerson.Items.Count; i++)
            //{
            //    this.lvwDisplayPerson.Items.RemoveAt(i);
            //}
            this.lvwDisplayUser.Items.Clear();

        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSentMessage_Click(object sender, EventArgs e)
        {
            string msg = "MSG" + txtMessage.Text;
            string ip = string.Empty;
            for (int i = 0; i < lvwDisplayUser.SelectedItems.Count; i++)
            {
                try
                {
                    ip = this.lvwDisplayUser.SelectedItems[i].SubItems[2].Text;

                    //初始化接受套接字：寻址方案，以字符流方式和Tcp通信
                    socketSent = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    int port = 8001;
                    string sendPort = ConfigurationManager.AppSettings["sendPort"];
                    if (!string.IsNullOrEmpty(sendPort))
                        port = Convert.ToInt32(sendPort);
                    //设置服务器IP地址和端口
                    ipSent = new IPEndPoint(IPAddress.Parse(ip), port);

                    //与服务器进行连接
                    socketSent.Connect(ipSent);

                    //是否封装
                    socketSent.Send(Encoding.Default.GetBytes(pack));

                    //将要发送的消息转化为字节流，然后发送
                    socketSent.Send(Encoding.Default.GetBytes(msg));
                    socketSent.Close();
                }
                catch
                {
                    MessageBox.Show(this.lvwDisplayUser.SelectedItems[i].SubItems[0].Text + "已经下线！");
                }
            }
        }

        /// <summary>
        /// 处理接受到的信息，分别对文件和普通消息进行处理
        /// </summary>
        private void ReceiveNews()
        {
            try
            {
                //初始化接受套接字：寻址方案，以字符流方式和Tcp通信
                socketReceive = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                int port = 8001;
                string sendPort = ConfigurationManager.AppSettings["sendPort"];
                if (!string.IsNullOrEmpty(sendPort))
                    port = Convert.ToInt32(sendPort);
                //获取本机IP地址并设置接受信息的端口
                ipReceive = new IPEndPoint(IPAddress.Parse(LanBroadCast.GetIPv4()), port);

                //将本机IP地址和接受端口绑定到接受套接字
                socketReceive.Bind(ipReceive);

                //监听端口，并设置监听缓存大小为1024byte
                socketReceive.Listen(1024);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            //定义接受信息时缓冲区
            byte[] buff = new byte[1024];

            //连续接受客户端发送过来的信息
            while (true)
            {
                if (socketReceive.IsBound)
                {
                    //定义一个chat套接字用来接受信息
                    Socket chat = socketReceive.Accept();

                    //定义一个处理信息的对象
                    ChatSession cs = new ChatSession(chat, this);

                    //定义一个新的线程用来接受其他主机发送的信息
                    Thread newThread = new Thread(new ThreadStart(cs.StartChat));

                    //启动新的线程
                    newThread.Start();
                }
            }
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSentFile_Click(object sender, EventArgs e)
        {
            //打开文件
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string ip = string.Empty;
                LanSocket socketConnet = null;
                SentLanFile sentFile = null;
                Thread tConnection = null;
                Thread tSentFile = null;
                for (int i = 0; i < lvwDisplayUser.SelectedItems.Count; i++)
                {
                    ip = this.lvwDisplayUser.SelectedItems[i].SubItems[2].Text;

                    //初始化接受套接字：寻址方案，以字符流方式和Tcp通信
                    socketSent = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

                    int port = 8001;
                    string sendPort = ConfigurationManager.AppSettings["sendPort"];
                    if (!string.IsNullOrEmpty(sendPort))
                        port = Convert.ToInt32(sendPort);
                    //设置服务器IP地址和端口
                    ipSent = new IPEndPoint(IPAddress.Parse(ip), port);

                    //与服务器进行连接
                    socketConnet = new LanSocket(socketSent, ipSent);
                    tConnection = new Thread(new ThreadStart(socketConnet.SocketConnect));
                    tConnection.Start();
                    Thread.Sleep(100);

                    //将要发送的文件加上"DAT"标识符
                    sentFile = new SentLanFile(dlg, socketSent);
                    tSentFile = new Thread(new ThreadStart(sentFile.SentFile));
                    tSentFile.Start();
                }
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// 退出应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
            //CancelEventArgs cancel = new CancelEventArgs(false);
            //Application.Exit(cancel);
        }
        
        /// <summary>
        /// 托盘右键设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetUp_Click(object sender, EventArgs e)
        {
            FrmSetUp setUp = new FrmSetUp();
            setUp.Show();
        }

        /// <summary>
        /// 系统托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        /// <summary>
        /// 是否封装消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPack_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbPack.Checked == true)
            {
                pack = "1";
            }
            else
            {
                pack = "0";
            }
        }
    }
}