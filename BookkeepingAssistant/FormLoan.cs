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
        private TransferType _transferType;
        private string _transferTypeShortName;
        private Action _refreshParent;

        public FormLoan(TransferType transferType, Action refreshParent)
        {
            InitializeComponent();
            _transferType = transferType;
            _refreshParent = refreshParent;
            switch (_transferType)
            {
                case TransferType.资产间转账:
                    _transferTypeShortName = "转";
                    break;
                case TransferType.借款:
                    _transferTypeShortName = "借";
                    break;
                case TransferType.还款:
                    _transferTypeShortName = "还";
                    break;
                default:
                    break;
            }
            Text = _transferType.ToString();
            lblPayType.Text = _transferTypeShortName;
            if (_transferType == TransferType.还款)
            {
                lblTip.Visible = true;
            }
        }

        private void FormLoan_Load(object sender, EventArgs e)
        {
            DisplayAssets();
        }

        private void DisplayAssets()
        {
            if (_transferType == TransferType.资产间转账)
            {
                var assets = DAL.Singleton.GetDisplayAssets();
                if (!assets.Any())
                {
                    btnOK.Enabled = false;
                    return;
                }
                BindComboBox(comboBoxFromAssets, assets);
                BindComboBox(comboBoxToAssets, assets);
                return;
            }

            var negativeAssets = DAL.Singleton.GetNegativeAssets();
            if (negativeAssets.Any())
            {
                if (_transferType == TransferType.借款)
                {
                    BindComboBox(comboBoxFromAssets, negativeAssets);
                }
                else if (_transferType == TransferType.还款)
                {
                    BindComboBox(comboBoxToAssets, negativeAssets);
                }
            }
            else
            {
                btnOK.Enabled = false;
            }
            var plusAssets = DAL.Singleton.GetPlusAssets();
            if (plusAssets.Any())
            {
                if (_transferType == TransferType.还款)
                {
                    BindComboBox(comboBoxFromAssets, plusAssets);
                }
                else if (_transferType == TransferType.借款)
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
                FormMessage.Show($"{_transferType}金额不能填入非数字。");
                return;
            }

            string resultMessage = string.Empty;
            try
            {
                resultMessage = DAL.Singleton.Loan(comboBoxFromAssets.SelectedValue.ToString(),
                    comboBoxToAssets.SelectedValue.ToString(), loanAmount, _transferType);
            }
            catch (Exception ex)
            {
                FormMessage.Show($"新增{_transferType}记录失败：{ ex.Message}。");
                return;
            }

            if (_refreshParent != null)
            {
                _refreshParent();
            }
            txtLoanAmount.Clear();
            FormMessage.Show(new StringBuilder().AppendLine($"已新增{_transferType}记录，资产变动计算过程：")
                .AppendLine(resultMessage).ToString());
            DisplayAssets();
            comboBoxFromAssets.Focus();
        }

        private void FormLoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}
