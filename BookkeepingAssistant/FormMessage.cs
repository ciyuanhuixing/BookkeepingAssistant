using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookkeepingAssistant
{
    public partial class FormMessage : Form
    {
        private string _message = string.Empty;
        public FormMessage(string message)
        {
            InitializeComponent();
            _message = message;
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            label1.Text = _message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static void Show(string message)
        {
            new FormMessage(message).ShowDialog();
        }
    }
}
