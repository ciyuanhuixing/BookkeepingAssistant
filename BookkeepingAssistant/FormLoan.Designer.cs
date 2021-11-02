
namespace BookkeepingAssistant
{
    partial class FormLoan
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.comboBoxFromAssets = new System.Windows.Forms.ComboBox();
            this.lblPayType = new System.Windows.Forms.Label();
            this.txtLoanAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxToAssets = new System.Windows.Forms.ComboBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(183, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "从";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOK.Location = new System.Drawing.Point(337, 378);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 47);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // comboBoxFromAssets
            // 
            this.comboBoxFromAssets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFromAssets.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxFromAssets.FormattingEnabled = true;
            this.comboBoxFromAssets.Location = new System.Drawing.Point(235, 41);
            this.comboBoxFromAssets.Name = "comboBoxFromAssets";
            this.comboBoxFromAssets.Size = new System.Drawing.Size(372, 39);
            this.comboBoxFromAssets.TabIndex = 0;
            // 
            // lblPayType
            // 
            this.lblPayType.AutoSize = true;
            this.lblPayType.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPayType.Location = new System.Drawing.Point(183, 145);
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size(38, 31);
            this.lblPayType.TabIndex = 13;
            this.lblPayType.Text = "借";
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLoanAmount.Location = new System.Drawing.Point(235, 145);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Size = new System.Drawing.Size(195, 38);
            this.txtLoanAmount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(436, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "元";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(183, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 31);
            this.label4.TabIndex = 16;
            this.label4.Text = "到";
            // 
            // comboBoxToAssets
            // 
            this.comboBoxToAssets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxToAssets.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxToAssets.FormattingEnabled = true;
            this.comboBoxToAssets.Location = new System.Drawing.Point(235, 270);
            this.comboBoxToAssets.Name = "comboBoxToAssets";
            this.comboBoxToAssets.Size = new System.Drawing.Size(372, 39);
            this.comboBoxToAssets.TabIndex = 2;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTip.Location = new System.Drawing.Point(235, 186);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(150, 31);
            this.lblTip.TabIndex = 18;
            this.lblTip.Text = "(不包括利息)";
            this.lblTip.Visible = false;
            // 
            // FormLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxToAssets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLoanAmount);
            this.Controls.Add(this.lblPayType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.comboBoxFromAssets);
            this.Name = "FormLoan";
            this.Text = "借款";
            this.Load += new System.EventHandler(this.FormLoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox comboBoxFromAssets;
        private System.Windows.Forms.Label lblPayType;
        private System.Windows.Forms.TextBox txtLoanAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxToAssets;
        private System.Windows.Forms.Label lblTip;
    }
}