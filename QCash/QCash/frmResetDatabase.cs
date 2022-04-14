using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QCash
{
    public partial class frmResetDatabase : Form
    {
        public frmResetDatabase()
        {
            InitializeComponent();
        }

        private ArrayList list = new ArrayList();
        private void frmResetDatabase_Load(object sender, EventArgs e)
        {
            //Note SQL string to reset database tables.
            list.Add("*tblRawItem");
            list.Add("DELETE * FROM tblRawItem");
            list.Add("ALTER TABLE tblRawItem ALTER COLUMN RawItemId  AUTOINCREMENT(0,1)");
            list.Add("INSERT INTO tblRawItem(RawItemName, UnitName, OpeningQuantity,ReOrderLevel,CurrentQuantity) VALUES('','',0,0,0)");
            list.Add("#tblRawItem");

        }

        private void btnResetDatabase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("sure?", "sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.Text;
                        Connection.Open();
                        foreach (string item in list)
                        {
                            if (item.StartsWith("*"))
                            {
                                string TableName = item.Remove(0, 1);
                                txtStatus.AppendText(TableName + " ====================================================== " + Environment.NewLine);
                            }

                            else if (item.StartsWith("#"))
                            {
                                // string TableName = item.Remove(0, 1);
                                txtStatus.AppendText(Environment.NewLine + Environment.NewLine);
                            }
                            else
                            {
                                txtStatus.AppendText(item.ToString() + Environment.NewLine);
                                DialogResult exetueSQL = MessageBox.Show(this, "Execute this statement?", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                if (exetueSQL == DialogResult.Yes)
                                {
                                    cmd.CommandText = item.ToString();
                                    cmd.ExecuteNonQuery();
                                    txtStatus.AppendText("EXECUTED." + Environment.NewLine);
                                }
                                else
                                {
                                    txtStatus.AppendText("SKIPPED." + Environment.NewLine);
                                }
                            }



                            //txtStatus.AppendText("-----------------------------------------------------------------------------------" + Environment.NewLine);
                        }
                        txtStatus.AppendText("===================================================================== " + Environment.NewLine + "ALL SUCCESS.");
                        //txtStatus.AppendText("----->ALL SUCCESS <------" + Environment.NewLine);
                        Connection.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
