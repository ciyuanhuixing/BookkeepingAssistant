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
        private string _assetsDataFile;
        private Dictionary<string, int> _dicAssets = new Dictionary<string, int>();
        private Dictionary<string, string> _dicDisplayAssets = new Dictionary<string, string>();

        public FormManageAssets(string assetsDataFile)
        {
            if (string.IsNullOrWhiteSpace(assetsDataFile))
            {
                throw new Exception("资产数据文件路径不能为空。");
            }
            _assetsDataFile = assetsDataFile;
            InitializeComponent();
        }

        private void FormManageAssets_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_assetsDataFile))
            {
                return;
            }

            string[] assetLines = File.ReadAllLines(_assetsDataFile);
            foreach (var line in assetLines)
            {
                string[] arr = line.Trim().Split('：', ':');
                if (arr.Length != 2)
                {
                    continue;
                }
                int assetValue;
                if (!int.TryParse(arr[1].Trim(), out assetValue))
                {
                    continue;
                }

                _dicAssets.Add(arr[0].Trim(), assetValue);
            }

            DisplayAssets();
        }

        private void addAsset_Click(object sender, EventArgs e)
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
            WriteAssetsDataFile();
            MessageBox.Show($"已新增「{assetName}」");
        }

        private void DisplayAssets()
        {
            _dicDisplayAssets.Clear();
            foreach (var kvp in _dicAssets)
            {
                _dicDisplayAssets.Add(kvp.Key, string.Join('：', kvp.Key, kvp.Value));
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = _dicDisplayAssets;
            comboBoxAssets.DisplayMember = "Value";
            comboBoxAssets.ValueMember = "Key";
            comboBoxAssets.DataSource = bs;
        }

        private void WriteAssetsDataFile()
        {
            StringBuilder sbAssets = new StringBuilder();
            foreach (var kvp in _dicAssets)
            {
                sbAssets.AppendLine(string.Join('：', kvp.Key, kvp.Value));
            }
            File.WriteAllText(_assetsDataFile, sbAssets.ToString());
            DisplayAssets();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string assetName = (string)comboBoxAssets.SelectedValue;
            if (MessageBox.Show($"确认删除{assetName}？", "确认删除？", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            _dicAssets.Remove(assetName);
            WriteAssetsDataFile();
        }
    }
}
