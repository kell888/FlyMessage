namespace FlyMessage
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lvwDisplayUser = new System.Windows.Forms.ListView();
            this.chUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chComputerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWorkGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSentMessage = new System.Windows.Forms.Button();
            this.btnSentFile = new System.Windows.Forms.Button();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SetUp = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPack = new System.Windows.Forms.CheckBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwDisplayUser
            // 
            this.lvwDisplayUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDisplayUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chUserName,
            this.chComputerName,
            this.chIP,
            this.chWorkGroup});
            this.lvwDisplayUser.FullRowSelect = true;
            this.lvwDisplayUser.GridLines = true;
            this.lvwDisplayUser.HideSelection = false;
            this.lvwDisplayUser.Location = new System.Drawing.Point(17, 14);
            this.lvwDisplayUser.Name = "lvwDisplayUser";
            this.lvwDisplayUser.Size = new System.Drawing.Size(383, 169);
            this.lvwDisplayUser.TabIndex = 0;
            this.lvwDisplayUser.UseCompatibleStateImageBehavior = false;
            this.lvwDisplayUser.View = System.Windows.Forms.View.Details;
            // 
            // chUserName
            // 
            this.chUserName.Text = "用户名";
            this.chUserName.Width = 80;
            // 
            // chComputerName
            // 
            this.chComputerName.Text = "主机名";
            this.chComputerName.Width = 80;
            // 
            // chIP
            // 
            this.chIP.Text = "IP";
            this.chIP.Width = 100;
            // 
            // chWorkGroup
            // 
            this.chWorkGroup.Text = "工作组";
            this.chWorkGroup.Width = 80;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(325, 187);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "刷新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(17, 221);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(383, 102);
            this.txtMessage.TabIndex = 3;
            // 
            // btnSentMessage
            // 
            this.btnSentMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSentMessage.Location = new System.Drawing.Point(34, 331);
            this.btnSentMessage.Name = "btnSentMessage";
            this.btnSentMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSentMessage.TabIndex = 4;
            this.btnSentMessage.Text = "发送消息";
            this.btnSentMessage.UseVisualStyleBackColor = true;
            this.btnSentMessage.Click += new System.EventHandler(this.btnSentMessage_Click);
            // 
            // btnSentFile
            // 
            this.btnSentFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSentFile.Location = new System.Drawing.Point(325, 331);
            this.btnSentFile.Name = "btnSentFile";
            this.btnSentFile.Size = new System.Drawing.Size(75, 23);
            this.btnSentFile.TabIndex = 5;
            this.btnSentFile.Text = "发送文件";
            this.btnSentFile.UseVisualStyleBackColor = true;
            this.btnSentFile.Click += new System.EventHandler(this.btnSentFile_Click);
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Location = new System.Drawing.Point(15, 192);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(65, 12);
            this.lblUserCount.TabIndex = 6;
            this.lblUserCount.Text = "在线人数：";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "局域网文件传输";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetUp,
            this.toolStripSeparator1,
            this.Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 76);
            // 
            // SetUp
            // 
            this.SetUp.Name = "SetUp";
            this.SetUp.Size = new System.Drawing.Size(152, 22);
            this.SetUp.Text = "设置";
            this.SetUp.Click += new System.EventHandler(this.SetUp_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(152, 22);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // cbPack
            // 
            this.cbPack.AutoSize = true;
            this.cbPack.Location = new System.Drawing.Point(115, 335);
            this.cbPack.Name = "cbPack";
            this.cbPack.Size = new System.Drawing.Size(72, 16);
            this.cbPack.TabIndex = 7;
            this.cbPack.Text = "隐蔽消息";
            this.cbPack.UseVisualStyleBackColor = true;
            this.cbPack.CheckedChanged += new System.EventHandler(this.cbPack_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 366);
            this.Controls.Add(this.cbPack);
            this.Controls.Add(this.lblUserCount);
            this.Controls.Add(this.btnSentFile);
            this.Controls.Add(this.btnSentMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lvwDisplayUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "局域网文件传输";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSentMessage;
        private System.Windows.Forms.Button btnSentFile;
        private System.Windows.Forms.ColumnHeader chUserName;
        private System.Windows.Forms.ColumnHeader chComputerName;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chWorkGroup;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SetUp;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.CheckBox cbPack;
        internal System.Windows.Forms.ListView lvwDisplayUser;
        internal System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

