using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace FlyMessage
{   

    public partial class FrmSetUp : Form
    {
        public FrmSetUp()
        {
            InitializeComponent();
            OpenRead();
        }

        /// <summary>
        /// 读取文本文件
        /// </summary>
        internal void OpenRead()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                using (FileStream read = new FileStream(path + "UserInformation.txt", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(read))
                    {
                        string userInfo = sr.ReadLine();
                        if (!string.IsNullOrEmpty(userInfo))
                        {
                            string[] info = null;
                            if (userInfo.IndexOf(':') >= 0)
                            {
                                info = userInfo.Split(':');
                            }
                            if (info.Length == 2)
                            {
                                this.txtUserName.Text = info[0];
                                this.txtWorkGroup.Text = info[1];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作有误：" + ex.Message);
            }
        }

        /// <summary>
        /// 添加局域网用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text;
            string workGroup = this.txtWorkGroup.Text;
            if (userName ==string.Empty|| workGroup == string.Empty)
            {
                MessageBox.Show("请正确输入用户名和工作组！");
            }
            else
            {
                try
                {
                    //添加用户到文本文件
                    FileStream write = new FileStream(@"UserInformation.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    string data = userName + ":" + workGroup;
                    StreamWriter sw = new StreamWriter(write);
                    sw.Write(data);
                    sw.Close();
                    write.Close();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("操作失败");
                }
            }
        }
    }
}