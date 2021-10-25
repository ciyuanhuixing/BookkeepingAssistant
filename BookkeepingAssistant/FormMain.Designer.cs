
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxInOut = new System.Windows.Forms.ComboBox();
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
            this.btnRefund = new System.Windows.Forms.Button();
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
            this.dgvDetail.ColumnHeadersHeight = 34;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 58);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 62;
            this.dgvDetail.RowTemplate.Height = 32;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(1145, 750);
            this.dgvDetail.TabIndex = 13;
            this.dgvDetail.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDetail_RowPrePaint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefund);
            this.panel1.Controls.Add(this.comboBoxInOut);
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
            this.panel1.Size = new System.Drawing.Size(1616, 58);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxInOut
            // 
            this.comboBoxInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInOut.FormattingEnabled = true;
            this.comboBoxInOut.Location = new System.Drawing.Point(12, 12);
            this.comboBoxInOut.Name = "comboBoxInOut";
            this.comboBoxInOut.Size = new System.Drawing.Size(110, 32);
            this.comboBoxInOut.TabIndex = 0;
            this.comboBoxInOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxInOut_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(817, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "金额";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(520, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "交易类型";
            // 
            // comboBoxTransactionTypes
            // 
            this.comboBoxTransactionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransactionTypes.FormattingEnabled = true;
            this.comboBoxTransactionTypes.Location = new System.Drawing.Point(608, 12);
            this.comboBoxTransactionTypes.Name = "comboBoxTransactionTypes";
            this.comboBoxTransactionTypes.Size = new System.Drawing.Size(182, 32);
            this.comboBoxTransactionTypes.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "资产类型";
            // 
            // comboBoxAssets
            // 
            this.comboBoxAssets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssets.FormattingEnabled = true;
            this.comboBoxAssets.Location = new System.Drawing.Point(225, 12);
            this.comboBoxAssets.Name = "comboBoxAssets";
            this.comboBoxAssets.Size = new System.Drawing.Size(273, 32);
            this.comboBoxAssets.TabIndex = 1;
            // 
            // linkLabelManageTransactionType
            // 
            this.linkLabelManageTransactionType.AutoSize = true;
            this.linkLabelManageTransactionType.Location = new System.Drawing.Point(1477, 19);
            this.linkLabelManageTransactionType.Name = "linkLabelManageTransactionType";
            this.linkLabelManageTransactionType.Size = new System.Drawing.Size(118, 24);
            this.linkLabelManageTransactionType.TabIndex = 21;
            this.linkLabelManageTransactionType.TabStop = true;
            this.linkLabelManageTransactionType.Text = "管理交易类型";
            this.linkLabelManageTransactionType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModifyTransactionType_LinkClicked);
            // 
            // linkLabelManageAssets
            // 
            this.linkLabelManageAssets.AutoSize = true;
            this.linkLabelManageAssets.Location = new System.Drawing.Point(1374, 19);
            this.linkLabelManageAssets.Name = "linkLabelManageAssets";
            this.linkLabelManageAssets.Size = new System.Drawing.Size(82, 24);
            this.linkLabelManageAssets.TabIndex = 20;
            this.linkLabelManageAssets.TabStop = true;
            this.linkLabelManageAssets.Text = "管理资产";
            this.linkLabelManageAssets.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModifyAssets_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1030, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 34);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(869, 13);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(132, 30);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // txtAssets
            // 
            this.txtAssets.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtAssets.Location = new System.Drawing.Point(1145, 58);
            this.txtAssets.Multiline = true;
            this.txtAssets.Name = "txtAssets";
            this.txtAssets.ReadOnly = true;
            this.txtAssets.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAssets.Size = new System.Drawing.Size(471, 750);
            this.txtAssets.TabIndex = 14;
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(1177, 12);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(156, 34);
            this.btnRefund.TabIndex = 25;
            this.btnRefund.Text = "对选中记录退款";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1616, 808);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.txtAssets);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "记账助手";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxInOut;
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
    }
}

