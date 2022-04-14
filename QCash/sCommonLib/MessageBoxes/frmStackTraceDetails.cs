using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sCommonLib.MessageBoxes
{
    public partial class frmStackTraceDetails : Form
    {
        private string StackTraceDetails;

        public frmStackTraceDetails()
        {
            InitializeComponent();
        }

        public frmStackTraceDetails(string StackTraceData)
        {
            InitializeComponent(); StackTraceDetails = StackTraceData;
        }

        private void frmStackTraceDetails_Load(object sender, EventArgs e)
        {
            txtStackTrace.Text = StackTraceDetails;
        }


    }
}
