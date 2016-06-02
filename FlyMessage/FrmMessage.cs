using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FlyMessage
{
    public partial class FrmMessage : Form
    {
        private string pack;
        private string msg;
        public FrmMessage(string msg,string pack)
        {
            this.msg = msg;
            this.pack = pack;
            InitializeComponent();
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            if (pack == "1")
            {
                this.btnPack.Visible = true;
            }
            else
            {
                this.btnPack.Visible = false;
            }
            this.txtMessage.Text = msg.Substring(4);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPack_Click(object sender, EventArgs e)
        {
            this.btnPack.Visible = false;
        }
    }
}