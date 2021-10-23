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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void linkLabelModifyAssets_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FormManageAssets formManageAssets = new FormManageAssets();
            formManageAssets.ShowDialog();
        }

        private void linkLabelModifyTransactionType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManageTransactionType formManageTransactionType = new FormManageTransactionType();
            formManageTransactionType.ShowDialog();
        }
    }
}
