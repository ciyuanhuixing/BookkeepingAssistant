using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookkeepingAssistant
{
    public partial class FormStatistics : Form
    {
        private List<TransactionRecordModel> _models;

        public FormStatistics(List<TransactionRecordModel> models)
        {
            InitializeComponent();
            _models = models;
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
