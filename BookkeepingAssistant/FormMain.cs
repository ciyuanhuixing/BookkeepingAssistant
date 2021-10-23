using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BookkeepingAssistant
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            comboBoxInOut.DataSource = new string[] { "支", "收" };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshComboBox();
            dgvDetail.DataSource = Data.SingletonInstance.TransactionRecords;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TransactionRecord tr = new TransactionRecord();
            tr.Time = DateTime.Now;
            tr.isIncome = (string)comboBoxInOut.SelectedValue == "收" ? true : false;
            int amount;
            if (!int.TryParse(txtAmount.Text.Trim(),out amount))
            {
                MessageBox.Show("新增失败：金额不能填入非数字。");
                return;
            }
            tr.Amount = amount;
            tr.AssetName = (string)comboBoxAssets.SelectedValue;
            tr.TransactionType = (string)comboBoxTransactionTypes.SelectedValue;

            Data.SingletonInstance.TransactionRecords.Add(tr);
            Data.SingletonInstance.AppendToTransactionRecordsDataFile(tr);
        }

        private void linkLabelModifyAssets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageAssets formManageAssets = new FormManageAssets();
            formManageAssets.ShowDialog();
            RefreshComboBox();
        }

        private void linkLabelModifyTransactionType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageTransactionType formManageTransactionType = new FormManageTransactionType();
            formManageTransactionType.ShowDialog();
            RefreshComboBox();
        }

        private void RefreshComboBox()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = Data.SingletonInstance.DicDisplayAssets;
            comboBoxAssets.DisplayMember = "Value";
            comboBoxAssets.ValueMember = "Key";
            comboBoxAssets.DataSource = bs;

            comboBoxTransactionTypes.DataSource = null;
            comboBoxTransactionTypes.DataSource = Data.SingletonInstance.TransactionTypes;
        }
    }
}
