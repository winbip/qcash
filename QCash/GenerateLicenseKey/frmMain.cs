using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenerateLicenseKey
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private string ExtractLicenseKey(string data, int StartingPosition)
        {
            string str = string.Empty;
            int length = data.Length;
            if (length > 25)
            {
                int num = length / 3;
                if (num > 25)
                {
                    for (int i = StartingPosition; i < length; i += 3)
                    {
                        str = str + data.Substring(i, 1);
                    }
                    this.ExtractLicenseKey(str, StartingPosition++);
                    return str;
                }
                return data;
            }
            return data;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int num; string str2; byte[] bytes; string CalculatedLicenseKey=string.Empty;

            String pProductKey = txtProductKey.Text.Trim();

            for (num = 0; num < pProductKey.Length; num++)
            {
                str2 = pProductKey.Substring(num, 1);
                bytes = Encoding.ASCII.GetBytes(str2);
                foreach (byte num2 in bytes)
                {
                    CalculatedLicenseKey = CalculatedLicenseKey + num2.ToString();
                }
            }

            CalculatedLicenseKey = ExtractLicenseKey(CalculatedLicenseKey, 0);

            String ApplicationName = txtApplicationName.Text.Trim();

            for (num = 0; num < ApplicationName.Length; num++)
            {
                str2 = ApplicationName.Substring(num, 1);
                bytes = Encoding.ASCII.GetBytes(str2);
                foreach (byte num2 in bytes)
                {
                    CalculatedLicenseKey = CalculatedLicenseKey + num2.ToString();
                }
            }

            txtLicenseKey.Text = CalculatedLicenseKey;
        }
    }
}
