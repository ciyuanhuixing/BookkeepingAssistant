
namespace BookkeepingAssistant
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDir = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.comboBoxAssetType = new System.Windows.Forms.ComboBox();
            this.comboBoxTransactionType = new System.Windows.Forms.ComboBox();
            this.linkLabelManageAssets = new System.Windows.Forms.LinkLabel();
            this.linkLabelManageTransactionType = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(129, 147);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(132, 30);
            this.txtDir.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(992, 145);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // comboBoxAssetType
            // 
            this.comboBoxAssetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssetType.FormattingEnabled = true;
            this.comboBoxAssetType.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxAssetType.Location = new System.Drawing.Point(367, 146);
            this.comboBoxAssetType.Name = "comboBoxAssetType";
            this.comboBoxAssetType.Size = new System.Drawing.Size(182, 32);
            this.comboBoxAssetType.TabIndex = 1;
            // 
            // comboBoxTransactionType
            // 
            this.comboBoxTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransactionType.FormattingEnabled = true;
            this.comboBoxTransactionType.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxTransactionType.Location = new System.Drawing.Point(684, 146);
            this.comboBoxTransactionType.Name = "comboBoxTransactionType";
            this.comboBoxTransactionType.Size = new System.Drawing.Size(182, 32);
            this.comboBoxTransactionType.TabIndex = 2;
            // 
            // linkLabelManageAssets
            // 
            this.linkLabelManageAssets.AutoSize = true;
            this.linkLabelManageAssets.Location = new System.Drawing.Point(25, 22);
            this.linkLabelManageAssets.Name = "linkLabelManageAssets";
            this.linkLabelManageAssets.Size = new System.Drawing.Size(82, 24);
            this.linkLabelManageAssets.TabIndex = 4;
            this.linkLabelManageAssets.TabStop = true;
            this.linkLabelManageAssets.Text = "管理资产";
            this.linkLabelManageAssets.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModifyAssets_LinkClicked);
            // 
            // linkLabelManageTransactionType
            // 
            this.linkLabelManageTransactionType.AutoSize = true;
            this.linkLabelManageTransactionType.Location = new System.Drawing.Point(157, 22);
            this.linkLabelManageTransactionType.Name = "linkLabelManageTransactionType";
            this.linkLabelManageTransactionType.Size = new System.Drawing.Size(118, 24);
            this.linkLabelManageTransactionType.TabIndex = 5;
            this.linkLabelManageTransactionType.TabStop = true;
            this.linkLabelManageTransactionType.Text = "管理交易类型";
            this.linkLabelManageTransactionType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModifyTransactionType_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 450);
            this.Controls.Add(this.linkLabelManageTransactionType);
            this.Controls.Add(this.linkLabelManageAssets);
            this.Controls.Add(this.comboBoxTransactionType);
            this.Controls.Add(this.comboBoxAssetType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDir);
            this.Name = "FormMain";
            this.Text = "记账助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboBoxAssetType;
        private System.Windows.Forms.ComboBox comboBoxTransactionType;
        private System.Windows.Forms.LinkLabel linkLabelManageAssets;
        private System.Windows.Forms.LinkLabel linkLabelManageTransactionType;
    }
}

