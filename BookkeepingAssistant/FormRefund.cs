using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookkeepingAssistant
{
    public partial class FormRefund : Form
    {
        public decimal RefundAmount { get; set; }
        public FormRefund(decimal refundAmount)
        {
            this.RefundAmount = refundAmount;
            InitializeComponent();
        }

        private void btnEditAmount_Click(object sender, EventArgs e)
        {
            txtRefundAmount.Enabled = true;
            txtRefundAmount.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(txtRefundAmount.Text.Trim(), out amount))
            {
                MessageBox.Show("不能输入非数字。");
                return;
            }
            if (amount > RefundAmount)
            {
                MessageBox.Show($"退款金额不能大于{RefundAmount}。");
                return;
            }
            if (amount <= 0)
            {
                MessageBox.Show("退款金额必须大于0。");
                return;
            }

            RefundAmount = amount;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormRefund_Load(object sender, EventArgs e)
        {
            txtRefundAmount.Text = RefundAmount.ToString();
        }
    }
}
