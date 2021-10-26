
namespace BookkeepingAssistant
{
    partial class FormRefund
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
            this.txtRefundAmount = new System.Windows.Forms.TextBox();
            this.btnEditAmount = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "退款金额";
            // 
            // txtRefundAmount
            // 
            this.txtRefundAmount.Enabled = false;
            this.txtRefundAmount.Location = new System.Drawing.Point(239, 71);
            this.txtRefundAmount.Name = "txtRefundAmount";
            this.txtRefundAmount.Size = new System.Drawing.Size(150, 30);
            this.txtRefundAmount.TabIndex = 2;
            // 
            // btnEditAmount
            // 
            this.btnEditAmount.Location = new System.Drawing.Point(395, 69);
            this.btnEditAmount.Name = "btnEditAmount";
            this.btnEditAmount.Size = new System.Drawing.Size(112, 34);
            this.btnEditAmount.TabIndex = 1;
            this.btnEditAmount.Text = "修改金额";
            this.btnEditAmount.UseVisualStyleBackColor = true;
            this.btnEditAmount.Click += new System.EventHandler(this.btnEditAmount_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(202, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(269, 59);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 362);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnEditAmount);
            this.Controls.Add(this.txtRefundAmount);
            this.Controls.Add(this.label1);
            this.Name = "FormRefund";
            this.Text = "退款";
            this.Load += new System.EventHandler(this.FormRefund_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRefundAmount;
        private System.Windows.Forms.Button btnEditAmount;
        private System.Windows.Forms.Button btnOK;
    }
}