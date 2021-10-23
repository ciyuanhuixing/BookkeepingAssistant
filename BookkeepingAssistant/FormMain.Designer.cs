
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
            this.linkLabelManageAssets = new System.Windows.Forms.LinkLabel();
            this.linkLabelManageTransactionType = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAssets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxInOut = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(187, 15);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(132, 30);
            this.txtDir.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1030, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // linkLabelManageAssets
            // 
            this.linkLabelManageAssets.AutoSize = true;
            this.linkLabelManageAssets.Location = new System.Drawing.Point(1185, 18);
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
            this.linkLabelManageTransactionType.Location = new System.Drawing.Point(1288, 18);
            this.linkLabelManageTransactionType.Name = "linkLabelManageTransactionType";
            this.linkLabelManageTransactionType.Size = new System.Drawing.Size(118, 24);
            this.linkLabelManageTransactionType.TabIndex = 5;
            this.linkLabelManageTransactionType.TabStop = true;
            this.linkLabelManageTransactionType.Text = "管理交易类型";
            this.linkLabelManageTransactionType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModifyTransactionType_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "资产类型";
            // 
            // comboBoxAssets
            // 
            this.comboBoxAssets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssets.FormattingEnabled = true;
            this.comboBoxAssets.Location = new System.Drawing.Point(422, 14);
            this.comboBoxAssets.Name = "comboBoxAssets";
            this.comboBoxAssets.Size = new System.Drawing.Size(273, 32);
            this.comboBoxAssets.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(717, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "交易类型";
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(805, 14);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(182, 32);
            this.comboBoxTypes.TabIndex = 12;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDetail.Location = new System.Drawing.Point(0, 64);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 62;
            this.dgvDetail.RowTemplate.Height = 32;
            this.dgvDetail.Size = new System.Drawing.Size(1421, 744);
            this.dgvDetail.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "金额";
            // 
            // comboBoxInOut
            // 
            this.comboBoxInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInOut.FormattingEnabled = true;
            this.comboBoxInOut.Location = new System.Drawing.Point(12, 14);
            this.comboBoxInOut.Name = "comboBoxInOut";
            this.comboBoxInOut.Size = new System.Drawing.Size(110, 32);
            this.comboBoxInOut.TabIndex = 15;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 808);
            this.Controls.Add(this.comboBoxInOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxAssets);
            this.Controls.Add(this.linkLabelManageTransactionType);
            this.Controls.Add(this.linkLabelManageAssets);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDir);
            this.Name = "FormMain";
            this.Text = "记账助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.LinkLabel linkLabelManageAssets;
        private System.Windows.Forms.LinkLabel linkLabelManageTransactionType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxAssets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxInOut;
    }
}

