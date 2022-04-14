using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using System.Collections;

namespace QCash.UtilityMenuForms
{
    public partial class frmExportData : Form
    {


        #region Constructors

        public frmExportData()
        {
            InitializeComponent();

        }

        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {


             //this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
             //this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
             //this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);


        }

        #endregion

        #region Event Handlers


        #region BackGroundWorker Event Handlers
        /*
        //=========================================================For Reference
        // private void btnStart_Click(object sender, EventArgs e)
        //{
        //    string ArgId = txtArgId.Text.Trim();
        //    string Name = txtArgName.Text.Trim();
        //    string Age = txtArgAge.Text.Trim();

        //    object[] Args = new object[] { ArgId, Name, Age };
        //   StartPrimaryWorker(Args);
        //}
        //===========================================================
          
         
        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                object[] Args = (object[])e.Argument;
                string ArgId = Args[0].ToString();
                string Name = Args[1].ToString();
                string Age = Args[2].ToString();

                e.Result = new object[] { ArgId,Name,Age};
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }
         
         
        private void PrimaryProgress(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Position = e.ProgressPercentage;
        }
         
        private void PrimaryWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //For Help
                //DataSet dsData = e.Result as DataSet;
                

                if (e.Cancelled)
                {
                    //CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Cancelled", "Tasks Cancelled", "Tasks have been cancelled. Please try again."));
                }
                else if (e.Error != null)
                {
                    //CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Error", "Error", e.Error.Message));
                }
                else
                {
                    if (e.Result != null)
                    {
                        object[] Result;

                        Result = (object[])e.Result;
                        string ArgId = Result[0].ToString();
                        string Name = Result[1].ToString();
                        string Age = Result[2].ToString();

                        txtResultId.Text = ArgId;
                        txtResultName.Text = Name;
                        txtResultAge.Text = Age;
                    }
                    else
                    {
                        //Show message if result is empty.
                    }
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        } 
         
          
        */
        #endregion

        
        #endregion

        

        #region Helper Methods

        

        #region BackgroundWorker Helper Methods
        /*
        private int ProgressValue;
        private void StartPrimaryWorker(object[] Args) 
        {
            this.Cursor = Cursors.WaitCursor;
            this.MyProgressBar.Maximum = 10;
            this.MyProgressBar.Value = 0;
            this.MyProgressBar.Visible = true;
            bgwPrimaryWorker.RunWorkerAsync(Args);
        }

        private void ReportPrimaryProgress()
        {
            ProgressValue += 1;
            bgwPrimaryWorker.ReportProgress(ProgressValue);
            System.Threading.Thread.Sleep(100);
        }

        private void ReportPostProgress()
        {
            Application.DoEvents();
            //ProgressValue += 1;
            MyProgressBar.Value += 1;
            System.Threading.Thread.Sleep(100);
        }
          
        private void ReportSpinningProgress()
        {
            Application.DoEvents();
            MyProgressDisk.Value++;
            System.Threading.Thread.Sleep(50);
        } 
         
         */
        #endregion


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime ExportDate;

                Boolean IsFromDateValid = DateTime.TryParseExact(txtFromDate.Text.Trim(), GlobalVariables.InputDateFormatsAllowed, GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowInnerWhite, out ExportDate);

                if (!IsFromDateValid)
                {
                    MessageBox.Show("Invalid date."); txtFromDate.Focus(); return;
                }

                //--> check whether this date exist in tblExport
                Boolean IsExported=false;
                Int32 oldExportId=0; DateTime oldExportDate; Int32 oldExportQuantity=0;
                using (OleDbConnection Connection =new OleDbConnection(GlobalVariables.ConnectionString))
                {
                    using (OleDbCommand cmd=new OleDbCommand("Select ExportId, ExportDate,ExportedRecordsQuantity from tblPreviousExport Where ExportDate=#"+ ExportDate.ToString("dd MMM yyyy") +"#",Connection))
                    {
                        Connection.Open();
                        OleDbDataReader reader=cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        if (reader.HasRows)
                        {
                            IsExported = true;
                            while (reader.Read())
                            {
                                oldExportId = Convert.ToInt32(reader[0]);
                                oldExportDate=Convert.ToDateTime(reader[1]);
                                oldExportQuantity = Convert.ToInt32(reader[2]);
                            }
                        }

                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }


                        if (IsExported)
                        {
                            ConfirmationMessage msg = new ConfirmationMessage("Export Data", "Sure?", "You already export data of this date. Do you want to export it again?");
                            if (CustomMessageBox.ShowConfirmationMessage(msg) != DialogResult.Yes)
                            {
                                return;
                            }
                        }
                    }
                }
                //<-- check whether this date exist in tblExport

                String sourceFilename = Path.Combine(Application.StartupPath, "DataExporter.mdb");
                if (!File.Exists(sourceFilename))
                {
                    MessageBox.Show("DateExporter template not found.");  return;
                }


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Data File|*.Dat";

                String savePath = String.Empty;

                DialogResult savingResult = saveFileDialog.ShowDialog();
                if (savingResult==DialogResult.OK)
                {
                    savePath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }

                if (File.Exists(savePath))
                {
                    MessageBox.Show("File aleady exists. Choose different name."); return;
                }

                File.Copy(sourceFilename, savePath);

                //---> Read Data from source
                DataTable dtDataToExport = new DataTable();
                using (OleDbConnection Connection = new OleDbConnection(GlobalVariables.ConnectionString))
                {
                    String SelectData = "Select * from qryDataToExport Where EntryDate=#"+ ExportDate.ToString("dd MMM yyyy") +"#";

                    OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
                    Connection.Open();
                    using (OleDbDataAdapter da=new OleDbDataAdapter(cmdCommand))
                    {
                        cmdCommand.CommandText = SelectData;
                        da.Fill(dtDataToExport);
                    }

                    if (!IsExported)
                    {
                        cmdCommand.CommandText = "Insert into tblPreviousExport(ExportDate, ExportedRecordsQuantity) Values(#"+ ExportDate.ToString("dd MMM yyyy") +"#,"+ dtDataToExport.Rows.Count +")";
                    }
                    else
                    {
                        cmdCommand.CommandText = "Update tblPreviousExport Set ExportedRecordsQuantity="+ dtDataToExport.Rows.Count +" Where ExportId="+ oldExportId +"";
                    }

                    cmdCommand.ExecuteNonQuery();

                    Connection.Close();
  
                }
                //<--- Read Data from source

                //---> Write to source
                String sourceConnectionString = GenerateForAccess2003(savePath);
                using (OleDbConnection Connection=new OleDbConnection(sourceConnectionString))
                {
                    OleDbCommand cmdCommand = new OleDbCommand();
                    cmdCommand.Connection = Connection;
                    Connection.Open();

                    foreach (DataRow row in dtDataToExport.Rows)
                    {
                        Int32 LedgerEntryId = Convert.ToInt32(row["LedgerEntryId"]);
                        Int32 DrAccountId = Convert.ToInt32(row["DrAccountId"]);
                        Int32 DrAccountCode = Convert.ToInt32(row["DrAccountCode"]);
                        String DrAccountName = Convert.ToString(row["DrAccountName"]);
                        Decimal DebitAmount = Convert.ToDecimal(row["DebitAmount"]);
                        Decimal CreditAmount = Convert.ToDecimal(row["CreditAmount"]);
                        DateTime EntryDate = Convert.ToDateTime(row["EntryDate"]);
                        String Narration = Convert.ToString(row["Narration"]);
                        Int32 VoucherId = Convert.ToInt32(row["VoucherId"]);
                        Int32 VoucherTypeId = Convert.ToInt32(row["VoucherTypeId"]);
                        Int32 CrAccountId = Convert.ToInt32(row["CrAccountId"]);
                        Int32 CrAccountCode = Convert.ToInt32(row["CrAccountCode"]);
                        String CrAccountName = Convert.ToString(row["CrAccountName"]);

                        String sqlInsert = "Insert into ExportedData(LedgerEntryId, DrAccountId, DrAccountCode, DrAccountName, DebitAmount, CreditAmount, EntryDate, Narration, VoucherId, VoucherTypeId, CrAccountId, CrAccountCode, CrAccountName) ";
                        sqlInsert += " Values(" + LedgerEntryId + "," + DrAccountId + "," + DrAccountCode + ",'" + DrAccountName + "'," + DebitAmount + "," + CreditAmount + ",#" + EntryDate.ToString("dd MMM yyyy") + "#,'" + Narration + "'," + VoucherId + "," + VoucherTypeId + "," + CrAccountId + "," + CrAccountCode + ",'" + CrAccountName + "')";
                        cmdCommand.CommandText = sqlInsert;
                        cmdCommand.ExecuteNonQuery();
                    }



                    Connection.Close();
                }
                //<--- Write to source

                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void frmExportData_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            txtFromDate.Text = today.ToString("d", GlobalVariables.CurrentCultureInfo);
        }


        private string GenerateForAccess2003(string DatabasePath)
        {
            string ProviderInfo = "Microsoft.Jet.OLEDB.4.0"; //for Access 2003
            //string ProviderInfo =  "Microsoft.ACE.OLEDB.12.0" // for Access 2007

            string DatabasePassword = "BigBoss";

            string DatabaseSecurityInfo = "Jet OLEDB:Database Password=" + DatabasePassword + ""; //if password

            string ConString = string.Empty;
            ConString = "Provider=" + ProviderInfo + ";Data Source= " + DatabasePath + ";" + DatabaseSecurityInfo + ";";

            return ConString;


        }

    }
}
