   namespace Didago.BizTalk.PortInfo
{
    partial class frmBizTalkPortInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbSQLServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBtsMgmtDb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.chkIntSecurity = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblConnecting = new System.Windows.Forms.Label();
            this.progressBtsApps = new System.Windows.Forms.ProgressBar();
            this.btnGetBtsApps = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBtsAppInfo = new System.Windows.Forms.ProgressBar();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.btnGetAppInfo = new System.Windows.Forms.Button();
            this.chkBtsAppList = new System.Windows.Forms.CheckedListBox();
            this.tvReceivePorts = new System.Windows.Forms.TreeView();
            this.tvSendPorts = new System.Windows.Forms.TreeView();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbSearchResult = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressSearch = new System.Windows.Forms.ProgressBar();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Server name:";
            // 
            // tbSQLServer
            // 
            this.tbSQLServer.Location = new System.Drawing.Point(118, 23);
            this.tbSQLServer.Name = "tbSQLServer";
            this.tbSQLServer.Size = new System.Drawing.Size(157, 20);
            this.tbSQLServer.TabIndex = 1;
            this.tbSQLServer.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "BizTalk Mgmt Db:";
            // 
            // tbBtsMgmtDb
            // 
            this.tbBtsMgmtDb.Location = new System.Drawing.Point(118, 49);
            this.tbBtsMgmtDb.Name = "tbBtsMgmtDb";
            this.tbBtsMgmtDb.Size = new System.Drawing.Size(157, 20);
            this.tbBtsMgmtDb.TabIndex = 1;
            this.tbBtsMgmtDb.Text = "BizTalkMgmtDb";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Id:";
            // 
            // tbUserId
            // 
            this.tbUserId.Enabled = false;
            this.tbUserId.Location = new System.Drawing.Point(118, 75);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(157, 20);
            this.tbUserId.TabIndex = 1;
            this.tbUserId.Text = "user";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password:";
            // 
            // tbPwd
            // 
            this.tbPwd.Enabled = false;
            this.tbPwd.Location = new System.Drawing.Point(118, 101);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.Size = new System.Drawing.Size(157, 20);
            this.tbPwd.TabIndex = 1;
            this.tbPwd.Text = "password";
            // 
            // chkIntSecurity
            // 
            this.chkIntSecurity.AutoSize = true;
            this.chkIntSecurity.Checked = true;
            this.chkIntSecurity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIntSecurity.Location = new System.Drawing.Point(114, 123);
            this.chkIntSecurity.Name = "chkIntSecurity";
            this.chkIntSecurity.Size = new System.Drawing.Size(134, 17);
            this.chkIntSecurity.TabIndex = 2;
            this.chkIntSecurity.Text = "Use integrated security";
            this.chkIntSecurity.UseVisualStyleBackColor = true;
            this.chkIntSecurity.CheckedChanged += new System.EventHandler(this.chkIntSecurity_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblConnecting);
            this.groupBox1.Controls.Add(this.progressBtsApps);
            this.groupBox1.Controls.Add(this.btnGetBtsApps);
            this.groupBox1.Controls.Add(this.chkIntSecurity);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 172);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Info";
            // 
            // lblConnecting
            // 
            this.lblConnecting.AutoSize = true;
            this.lblConnecting.ForeColor = System.Drawing.Color.Red;
            this.lblConnecting.Location = new System.Drawing.Point(12, 124);
            this.lblConnecting.Name = "lblConnecting";
            this.lblConnecting.Size = new System.Drawing.Size(79, 13);
            this.lblConnecting.TabIndex = 5;
            this.lblConnecting.Text = "Connecting......";
            this.lblConnecting.Visible = false;
            // 
            // progressBtsApps
            // 
            this.progressBtsApps.Location = new System.Drawing.Point(178, 143);
            this.progressBtsApps.Name = "progressBtsApps";
            this.progressBtsApps.Size = new System.Drawing.Size(93, 23);
            this.progressBtsApps.TabIndex = 3;
            // 
            // btnGetBtsApps
            // 
            this.btnGetBtsApps.Location = new System.Drawing.Point(12, 143);
            this.btnGetBtsApps.Name = "btnGetBtsApps";
            this.btnGetBtsApps.Size = new System.Drawing.Size(160, 23);
            this.btnGetBtsApps.TabIndex = 4;
            this.btnGetBtsApps.Text = "Retrieve BizTalk Applications";
            this.btnGetBtsApps.UseVisualStyleBackColor = true;
            this.btnGetBtsApps.Click += new System.EventHandler(this.btnGetBtsApps_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBtsAppInfo);
            this.groupBox2.Controls.Add(this.chkCheckAll);
            this.groupBox2.Controls.Add(this.btnGetAppInfo);
            this.groupBox2.Controls.Add(this.chkBtsAppList);
            this.groupBox2.Location = new System.Drawing.Point(4, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 327);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BizTalk Application Overview";
            // 
            // progressBtsAppInfo
            // 
            this.progressBtsAppInfo.Location = new System.Drawing.Point(178, 294);
            this.progressBtsAppInfo.Name = "progressBtsAppInfo";
            this.progressBtsAppInfo.Size = new System.Drawing.Size(92, 23);
            this.progressBtsAppInfo.TabIndex = 3;
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new System.Drawing.Point(12, 20);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(120, 17);
            this.chkCheckAll.TabIndex = 2;
            this.chkCheckAll.Text = "Check/Uncheck All";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // btnGetAppInfo
            // 
            this.btnGetAppInfo.Location = new System.Drawing.Point(12, 294);
            this.btnGetAppInfo.Name = "btnGetAppInfo";
            this.btnGetAppInfo.Size = new System.Drawing.Size(160, 23);
            this.btnGetAppInfo.TabIndex = 1;
            this.btnGetAppInfo.Text = "Retrieve Application Info";
            this.btnGetAppInfo.UseVisualStyleBackColor = true;
            this.btnGetAppInfo.Click += new System.EventHandler(this.btnGetAppInfo_Click);
            // 
            // chkBtsAppList
            // 
            this.chkBtsAppList.CheckOnClick = true;
            this.chkBtsAppList.FormattingEnabled = true;
            this.chkBtsAppList.Location = new System.Drawing.Point(12, 43);
            this.chkBtsAppList.Name = "chkBtsAppList";
            this.chkBtsAppList.Size = new System.Drawing.Size(259, 244);
            this.chkBtsAppList.TabIndex = 0;
            // 
            // tvReceivePorts
            // 
            this.tvReceivePorts.Location = new System.Drawing.Point(303, 24);
            this.tvReceivePorts.Name = "tvReceivePorts";
            this.tvReceivePorts.Size = new System.Drawing.Size(524, 242);
            this.tvReceivePorts.TabIndex = 6;
            this.tvReceivePorts.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvReceivePorts_AfterSelect);
            // 
            // tvSendPorts
            // 
            this.tvSendPorts.Location = new System.Drawing.Point(6, 267);
            this.tvSendPorts.Name = "tvSendPorts";
            this.tvSendPorts.Size = new System.Drawing.Size(524, 227);
            this.tvSendPorts.TabIndex = 6;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(12, 14);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(259, 20);
            this.tbSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(299, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(258, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search through artifacts in Application Info above";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tvSendPorts);
            this.groupBox3.Location = new System.Drawing.Point(296, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(539, 504);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Application Info - Receive - Send";
            // 
            // lbSearchResult
            // 
            this.lbSearchResult.FormattingEnabled = true;
            this.lbSearchResult.HorizontalScrollbar = true;
            this.lbSearchResult.Location = new System.Drawing.Point(12, 44);
            this.lbSearchResult.Name = "lbSearchResult";
            this.lbSearchResult.Size = new System.Drawing.Size(810, 173);
            this.lbSearchResult.TabIndex = 11;
            this.lbSearchResult.SelectedIndexChanged += new System.EventHandler(this.lbSearchResult_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressSearch);
            this.groupBox4.Controls.Add(this.btnExport);
            this.groupBox4.Controls.Add(this.lbSearchResult);
            this.groupBox4.Controls.Add(this.tbSearch);
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Location = new System.Drawing.Point(4, 515);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(831, 225);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            // 
            // progressSearch
            // 
            this.progressSearch.Location = new System.Drawing.Point(564, 14);
            this.progressSearch.Name = "progressSearch";
            this.progressSearch.Size = new System.Drawing.Size(123, 23);
            this.progressSearch.TabIndex = 13;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(693, 14);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(129, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export App Info";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmBizTalkPortInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 745);
            this.Controls.Add(this.tvReceivePorts);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUserId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBtsMgmtDb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSQLServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "frmBizTalkPortInfo";
            this.Text = "BizTalk Application Port Information - Didago IT Consultancy";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSQLServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBtsMgmtDb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.CheckBox chkIntSecurity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetBtsApps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chkBtsAppList;
        private System.Windows.Forms.TreeView tvReceivePorts;
        private System.Windows.Forms.TreeView tvSendPorts;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbSearchResult;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGetAppInfo;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ProgressBar progressBtsApps;
        private System.Windows.Forms.ProgressBar progressBtsAppInfo;
        private System.Windows.Forms.ProgressBar progressSearch;
        private System.Windows.Forms.Label lblConnecting;
    }
}

