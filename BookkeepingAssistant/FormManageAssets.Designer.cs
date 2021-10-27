
namespace BookkeepingAssistant
{
    partial class FormManageAssets
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
            this.comboBoxAssets = new System.Windows.Forms.ComboBox();
            this.txtAssetName = new System.Windows.Forms.TextBox();
            this.addAsset = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtAssetValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAssets
            // 
            this.comboBoxAssets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssets.FormattingEnabled = true;
            this.comboBoxAssets.Location = new System.Drawing.Point(133, 228);
            this.comboBoxAssets.Name = "comboBoxAssets";
            this.comboBoxAssets.Size = new System.Drawing.Size(182, 32);
            this.comboBoxAssets.TabIndex = 8;
            // 
            // txtAssetName
            // 
            this.txtAssetName.Location = new System.Drawing.Point(133, 81);
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.Size = new System.Drawing.Size(190, 30);
            this.txtAssetName.TabIndex = 0;
            // 
            // addAsset
            // 
            this.addAsset.Location = new System.Drawing.Point(637, 79);
            this.addAsset.Name = "addAsset";
            this.addAsset.Size = new System.Drawing.Size(140, 34);
            this.addAsset.TabIndex = 2;
            this.addAsset.Text = "新增";
            this.addAsset.UseVisualStyleBackColor = true;
            this.addAsset.Click += new System.EventHandler(this.btnAddAsset_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(363, 227);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 34);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "删除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtAssetValue
            // 
            this.txtAssetValue.Location = new System.Drawing.Point(397, 81);
            this.txtAssetValue.Name = "txtAssetValue";
            this.txtAssetValue.Size = new System.Drawing.Size(221, 30);
            this.txtAssetValue.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "资产名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "余额";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "资产";
            // 
            // FormManageAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 595);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAssetValue);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.addAsset);
            this.Controls.Add(this.txtAssetName);
            this.Controls.Add(this.comboBoxAssets);
            this.Name = "FormManageAssets";
            this.Text = "资产管理";
            this.Load += new System.EventHandler(this.FormManageAssets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAssets;
        private System.Windows.Forms.TextBox txtAssetName;
        private System.Windows.Forms.Button addAsset;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtAssetValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}