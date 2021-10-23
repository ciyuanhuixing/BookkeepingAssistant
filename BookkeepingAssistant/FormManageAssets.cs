using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BookkeepingAssistant
{
    public partial class FormManageAssets : Form
    {
        public Dictionary<string, int> _dicAssets = Data.SingletonInstance.DicAssets;

        public FormManageAssets()
        {
            InitializeComponent();
        }

        private void FormManageAssets_Load(object sender, EventArgs e)
        {
            DisplayAssets();
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            string assetName = txtAssetName.Text.Trim();
            if (_dicAssets.ContainsKey(assetName))
            {
                MessageBox.Show("新增失败：已存在该名称的资产。");
                return;
            }

            int assetValue;
            if (!int.TryParse(txtAssetValue.Text.Trim(), out assetValue))
            {
                MessageBox.Show("新增失败：资产余额不能填非数字。");
                return;
            }

            _dicAssets.Add(assetName, assetValue);
            Data.SingletonInstance.WriteAssetsDataFile();
            DisplayAssets();
            MessageBox.Show($"已新增「{assetName}」");
        }

        private void DisplayAssets()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = Data.SingletonInstance.DicDisplayAssets;
            comboBoxAssets.DisplayMember = "Value";
            comboBoxAssets.ValueMember = "Key";
            comboBoxAssets.DataSource = bs;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string assetName = (string)comboBoxAssets.SelectedValue;
            if (MessageBox.Show($"确认删除{assetName}？", "确认删除？", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            _dicAssets.Remove(assetName);
            Data.SingletonInstance.WriteAssetsDataFile();
            DisplayAssets();
        }
    }
}
