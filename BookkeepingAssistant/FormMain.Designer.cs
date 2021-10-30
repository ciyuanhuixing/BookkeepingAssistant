
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRepay = new System.Windows.Forms.Button();
            this.btnLoan = new System.Windows.Forms.Button();
            this.lblInOut = new System.Windows.Forms.Label();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnDeleteSelect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemake = new System.Windows.Forms.TextBox();
            this.btnRefund = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTransactionTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAssets = new System.Windows.Forms.ComboBox();
            this.linkLabelManageTransactionType = new System.Windows.Forms.LinkLabel();
            this.linkLabelManageAssets = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtAssets = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeight = 42;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 112);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowHeadersWidth = 62;
            this.dgvDetail.RowTemplate.Height = 42;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(1359, 696);
            this.dgvDetail.TabIndex = 13;
            this.dgvDetail.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDetail_RowPrePaint);
            this.dgvDetail.SelectionChanged += new System.EventHandler(this.dgvDetail_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTransfer);
            this.panel1.Controls.Add(this.btnRepay);
            this.panel1.Controls.Add(this.btnLoan);
            this.panel1.Controls.Add(this.lblInOut);
            this.panel1.Controls.Add(this.btnStatistics);
            this.panel1.Controls.Add(this.btnDeleteSelect);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRemake);
            this.panel1.Controls.Add(this.btnRefund);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxTransactionTypes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxAssets);
            this.panel1.Controls.Add(this.linkLabelManageTransactionType);
            this.panel1.Controls.Add(this.linkLabelManageAssets);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1720, 112);
            this.panel1.TabIndex = 0;
            // 
            // btnRepay
            // 
            this.btnRepay.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRepay.Location = new System.Drawing.Point(1359, 61);
            this.btnRepay.Name = "btnRepay";
            this.btnRepay.Size = new System.Drawing.Size(70, 38);
            this.btnRepay.TabIndex = 32;
            this.btnRepay.Text = "还款";
            this.btnRepay.UseVisualStyleBackColor = true;
            this.btnRepay.Click += new System.EventHandler(this.btnRepay_Click);
            // 
            // btnLoan
            // 
            this.btnLoan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoan.Location = new System.Drawing.Point(1277, 61);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(71, 38);
            this.btnLoan.TabIndex = 31;
            this.btnLoan.Text = "借款";
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // lblInOut
            // 
            this.lblInOut.AutoSize = true;
            this.lblInOut.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInOut.Location = new System.Drawing.Point(261, 18);
            this.lblInOut.Name = "lblInOut";
            this.lblInOut.Size = new System.Drawing.Size(78, 31);
            this.lblInOut.TabIndex = 30;
            this.lblInOut.Text = "(收支)";
            // 
            // btnStatistics
            // 
            this.btnStatistics.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStatistics.Location = new System.Drawing.Point(1153, 13);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(118, 86);
            this.btnStatistics.TabIndex = 29;
            this.btnStatistics.Text = "记账统计(&F8)";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnDeleteSelect
            // 
            this.btnDeleteSelect.Enabled = false;
            this.btnDeleteSelect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteSelect.Location = new System.Drawing.Point(1686, 14);
            this.btnDeleteSelect.Name = "btnDeleteSelect";
            this.btnDeleteSelect.Size = new System.Drawing.Size(56, 86);
            this.btnDeleteSelect.TabIndex = 28;
            this.btnDeleteSelect.Text = "删除所选记录";
            this.btnDeleteSelect.UseVisualStyleBackColor = true;
            this.btnDeleteSelect.Click += new System.EventHandler(this.btnDeleteSelect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(49, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 31);
            this.label4.TabIndex = 27;
            this.label4.Text = "备注";
            // 
            // txtRemake
            // 
            this.txtRemake.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRemake.Location = new System.Drawing.Point(117, 61);
            this.txtRemake.Name = "txtRemake";
            this.txtRemake.Size = new System.Drawing.Size(971, 39);
            this.txtRemake.TabIndex = 4;
            this.txtRemake.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // btnRefund
            // 
            this.btnRefund.Enabled = false;
            this.btnRefund.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefund.Location = new System.Drawing.Point(1617, 14);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(38, 86);
            this.btnRefund.TabIndex = 6;
            this.btnRefund.Text = "退款";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 31);
            this.label1.TabIndex = 24;
            this.label1.Text = "金额(&F2)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(352, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "交易类型";
            // 
            // comboBoxTransactionTypes
            // 
            this.comboBoxTransactionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransactionTypes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxTransactionTypes.FormattingEnabled = true;
            this.comboBoxTransactionTypes.Location = new System.Drawing.Point(468, 14);
            this.comboBoxTransactionTypes.Name = "comboBoxTransactionTypes";
            this.comboBoxTransactionTypes.Size = new System.Drawing.Size(182, 39);
            this.comboBoxTransactionTypes.TabIndex = 2;
            this.comboBoxTransactionTypes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(670, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 31);
            this.label3.TabIndex = 22;
            this.label3.Text = "资产类型";
            // 
            // comboBoxAssets
            // 
            this.comboBoxAssets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssets.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxAssets.FormattingEnabled = true;
            this.comboBoxAssets.Location = new System.Drawing.Point(786, 14);
            this.comboBoxAssets.Name = "comboBoxAssets";
            this.comboBoxAssets.Size = new System.Drawing.Size(302, 39);
            this.comboBoxAssets.TabIndex = 3;
            this.comboBoxAssets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // linkLabelManageTransactionType
            // 
            this.linkLabelManageTransactionType.AutoSize = true;
            this.linkLabelManageTransactionType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelManageTransactionType.Location = new System.Drawing.Point(1434, 64);
            this.linkLabelManageTransactionType.Name = "linkLabelManageTransactionType";
            this.linkLabelManageTransactionType.Size = new System.Drawing.Size(158, 31);
            this.linkLabelManageTransactionType.TabIndex = 21;
            this.linkLabelManageTransactionType.TabStop = true;
            this.linkLabelManageTransactionType.Text = "管理交易类型";
            this.linkLabelManageTransactionType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModifyTransactionType_LinkClicked);
            // 
            // linkLabelManageAssets
            // 
            this.linkLabelManageAssets.AutoSize = true;
            this.linkLabelManageAssets.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelManageAssets.Location = new System.Drawing.Point(1434, 18);
            this.linkLabelManageAssets.Name = "linkLabelManageAssets";
            this.linkLabelManageAssets.Size = new System.Drawing.Size(110, 31);
            this.linkLabelManageAssets.TabIndex = 20;
            this.linkLabelManageAssets.TabStop = true;
            this.linkLabelManageAssets.Text = "管理资产";
            this.linkLabelManageAssets.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModifyAssets_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(1103, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 86);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAmount.Location = new System.Drawing.Point(117, 14);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(144, 39);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtAssets
            // 
            this.txtAssets.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtAssets.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAssets.Location = new System.Drawing.Point(1359, 112);
            this.txtAssets.Multiline = true;
            this.txtAssets.Name = "txtAssets";
            this.txtAssets.ReadOnly = true;
            this.txtAssets.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAssets.Size = new System.Drawing.Size(361, 696);
            this.txtAssets.TabIndex = 14;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTransfer.Location = new System.Drawing.Point(1277, 11);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(151, 38);
            this.btnTransfer.TabIndex = 33;
            this.btnTransfer.Text = "资产间转账";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 808);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtAssets);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "记账助手";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTransactionTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxAssets;
        private System.Windows.Forms.LinkLabel linkLabelManageTransactionType;
        private System.Windows.Forms.LinkLabel linkLabelManageAssets;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtAssets;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemake;
        private System.Windows.Forms.Button btnDeleteSelect;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Label lblInOut;
        private System.Windows.Forms.Button btnRepay;
        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnTransfer;
    }
}

