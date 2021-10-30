using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookkeepingAssistant
{
    public partial class FormLoan : Form
    {
        public FormLoan()
        {
            InitializeComponent();
        }

        private void FormLoan_Load(object sender, EventArgs e)
        {
            DisplayAssets();
        }

        private void DisplayAssets()
        {
            var canBeBorrowedAssets = DAL.Singleton.GetDisplayCanBeBorrowedAssets();
            if (canBeBorrowedAssets.Any())
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = canBeBorrowedAssets;
                comboBoxFromAssets.DisplayMember = "Value";
                comboBoxFromAssets.ValueMember = "Key";
                comboBoxFromAssets.DataSource = bs;
            }
            else
            {
                btnOK.Enabled = false;
            }
            var canBorrowAssets = DAL.Singleton.GetDisplayCanBorrowAssets();
            if (canBorrowAssets.Any())
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = canBorrowAssets;
                comboBoxToAssets.DisplayMember = "Value";
                comboBoxToAssets.ValueMember = "Key";
                comboBoxToAssets.DataSource = bs;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal loanAmount;
            if (!decimal.TryParse(txtLoanAmount.Text.Trim(), out loanAmount))
            {
                FormMessage.Show("借款金额不能填入非数字。");
                return;
            }

            string resultMessage = string.Empty;
            try
            {
                resultMessage = DAL.Singleton.Loan(comboBoxFromAssets.SelectedValue.ToString(),
                    comboBoxToAssets.SelectedValue.ToString(), loanAmount);
            }
            catch (Exception ex)
            {
                FormMessage.Show($"新增借款记录失败：{ ex.Message}。");
                return;
            }

            txtLoanAmount.Clear();
            FormMessage.Show(new StringBuilder().AppendLine("已新增借款记录，借款资产变动计算过程：")
                .AppendLine(resultMessage).ToString());
        }
    }
}
