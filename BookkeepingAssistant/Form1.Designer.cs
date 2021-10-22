
namespace BookkeepingAssistant
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(101, 31);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(132, 30);
            this.txtDir.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(964, 31);
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
            this.comboBoxAssetType.Location = new System.Drawing.Point(339, 33);
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
            this.comboBoxTransactionType.Location = new System.Drawing.Point(656, 33);
            this.comboBoxTransactionType.Name = "comboBoxTransactionType";
            this.comboBoxTransactionType.Size = new System.Drawing.Size(182, 32);
            this.comboBoxTransactionType.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 450);
            this.Controls.Add(this.comboBoxTransactionType);
            this.Controls.Add(this.comboBoxAssetType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboBoxAssetType;
        private System.Windows.Forms.ComboBox comboBoxTransactionType;
    }
}

