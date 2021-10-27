
namespace BookkeepingAssistant
{
    partial class FormInit
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
            this.txtGitRepoDir = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSelectGitDir = new System.Windows.Forms.Button();
            this.txtRemoteUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGitUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGitEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据（Git 仓库）文件夹";
            // 
            // txtGitRepoDir
            // 
            this.txtGitRepoDir.Location = new System.Drawing.Point(282, 35);
            this.txtGitRepoDir.Name = "txtGitRepoDir";
            this.txtGitRepoDir.ReadOnly = true;
            this.txtGitRepoDir.Size = new System.Drawing.Size(596, 30);
            this.txtGitRepoDir.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(379, 345);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(342, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSelectGitDir
            // 
            this.btnSelectGitDir.Location = new System.Drawing.Point(1009, 33);
            this.btnSelectGitDir.Name = "btnSelectGitDir";
            this.btnSelectGitDir.Size = new System.Drawing.Size(112, 34);
            this.btnSelectGitDir.TabIndex = 3;
            this.btnSelectGitDir.Text = "浏览";
            this.btnSelectGitDir.UseVisualStyleBackColor = true;
            this.btnSelectGitDir.Click += new System.EventHandler(this.btnSelectGitDir_Click);
            // 
            // txtRemoteUrl
            // 
            this.txtRemoteUrl.Location = new System.Drawing.Point(284, 85);
            this.txtRemoteUrl.Name = "txtRemoteUrl";
            this.txtRemoteUrl.Size = new System.Drawing.Size(837, 30);
            this.txtRemoteUrl.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Git 仓库推送远程地址（HTTPS）";
            // 
            // txtGitUsername
            // 
            this.txtGitUsername.Location = new System.Drawing.Point(282, 181);
            this.txtGitUsername.Name = "txtGitUsername";
            this.txtGitUsername.Size = new System.Drawing.Size(335, 30);
            this.txtGitUsername.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Git 用户名";
            // 
            // txtGitEmail
            // 
            this.txtGitEmail.Location = new System.Drawing.Point(727, 184);
            this.txtGitEmail.Name = "txtGitEmail";
            this.txtGitEmail.Size = new System.Drawing.Size(394, 30);
            this.txtGitEmail.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(645, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Git 邮箱";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(758, 48);
            this.label5.TabIndex = 10;
            this.label5.Text = "格式：https://[用户名]:[Token]@[仓库链接]\r\n例如：https://ciyuanhuixing:d2088d98058@gitee.com/c" +
    "iyuanhuixing/bookkeeping.git\r\n";
            // 
            // FormInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGitEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGitUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemoteUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectGitDir);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtGitRepoDir);
            this.Controls.Add(this.label1);
            this.Name = "FormInit";
            this.Text = "记账助手 - 初始化";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInit_FormClosing);
            this.Load += new System.EventHandler(this.FormInit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGitRepoDir;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSelectGitDir;
        private System.Windows.Forms.TextBox txtRemoteUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGitUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGitEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}