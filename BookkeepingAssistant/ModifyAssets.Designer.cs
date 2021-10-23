
namespace BookkeepingAssistant
{
    partial class ModifyAssets
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
            this.SuspendLayout();
            // 
            // comboBoxAssets
            // 
            this.comboBoxAssets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssets.FormattingEnabled = true;
            this.comboBoxAssets.Location = new System.Drawing.Point(119, 229);
            this.comboBoxAssets.Name = "comboBoxAssets";
            this.comboBoxAssets.Size = new System.Drawing.Size(182, 32);
            this.comboBoxAssets.TabIndex = 0;
            // 
            // txtAssetName
            // 
            this.txtAssetName.Location = new System.Drawing.Point(151, 78);
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.Size = new System.Drawing.Size(150, 30);
            this.txtAssetName.TabIndex = 1;
            // 
            // addAsset
            // 
            this.addAsset.Location = new System.Drawing.Point(567, 76);
            this.addAsset.Name = "addAsset";
            this.addAsset.Size = new System.Drawing.Size(112, 34);
            this.addAsset.TabIndex = 2;
            this.addAsset.Text = "新增";
            this.addAsset.UseVisualStyleBackColor = true;
            this.addAsset.Click += new System.EventHandler(this.addAsset_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(374, 227);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 34);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "删除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtAssetValue
            // 
            this.txtAssetValue.Location = new System.Drawing.Point(356, 80);
            this.txtAssetValue.Name = "txtAssetValue";
            this.txtAssetValue.Size = new System.Drawing.Size(150, 30);
            this.txtAssetValue.TabIndex = 4;
            // 
            // ModifyAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtAssetValue);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.addAsset);
            this.Controls.Add(this.txtAssetName);
            this.Controls.Add(this.comboBoxAssets);
            this.Name = "ModifyAssets";
            this.Text = "ModifyAssets";
            this.Load += new System.EventHandler(this.ModifyAssets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAssets;
        private System.Windows.Forms.TextBox txtAssetName;
        private System.Windows.Forms.Button addAsset;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtAssetValue;
    }
}