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
        public Color LabelBackColor { get; set; }
        public FormMessage(string message)
        {
            InitializeComponent();
            _message = message;
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            label1.Text = _message;
            if (LabelBackColor != Color.Empty)
            {
                label1.BackColor = LabelBackColor;
            }
        }

        public static void Show(string message)
        {
            Show(message, Color.Empty);
        }
        public static void Show(string message, Color color)
        {
            new FormMessage(message) { LabelBackColor = color }.ShowDialog();
        }

        private void FormMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}
