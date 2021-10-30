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
        private bool _isRepay;
        private string _payType;

        public FormLoan(bool isRepay = false)
        {
            InitializeComponent();
            _isRepay = isRepay;
            _payType = _isRepay ? "还" : "借";
            Text = _payType + "款";
            lblPayType.Text = _payType;
            lblTip.Visible = _isRepay;
        }

        private void FormLoan_Load(object sender, EventArgs e)
        {
            DisplayAssets();
        }

        private void DisplayAssets()
        {
            var negativeAssets = DAL.Singleton.GetNegativeAssets();
            if (negativeAssets.Any())
            {
                if (_isRepay)
                {
                    BindComboBox(comboBoxToAssets, negativeAssets);
                }
                else
                {
                    BindComboBox(comboBoxFromAssets, negativeAssets);
                }
            }
            else
            {
                btnOK.Enabled = false;
            }
            var plusAssets = DAL.Singleton.GetPlusAssets();
            if (plusAssets.Any())
            {
                if (_isRepay)
                {
                    BindComboBox(comboBoxFromAssets, plusAssets);
                }
                else
                {
                    BindComboBox(comboBoxToAssets, plusAssets);
                }
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void BindComboBox(ComboBox comboBox, Dictionary<string, string> dataSource)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            comboBox.DataSource = bs;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal loanAmount;
            if (!decimal.TryParse(txtLoanAmount.Text.Trim(), out loanAmount))
            {
                FormMessage.Show($"{_payType}款金额不能填入非数字。");
                return;
            }

            string resultMessage = string.Empty;
            try
            {
                resultMessage = DAL.Singleton.Loan(comboBoxFromAssets.SelectedValue.ToString(),
                    comboBoxToAssets.SelectedValue.ToString(), loanAmount, _isRepay);
            }
            catch (Exception ex)
            {
                FormMessage.Show($"新增{_payType}款记录失败：{ ex.Message}。");
                return;
            }

            txtLoanAmount.Clear();
            FormMessage.Show(new StringBuilder().AppendLine($"已新增{_payType}款记录，{_payType}款资产变动计算过程：")
                .AppendLine(resultMessage).ToString());
        }
    }
}
