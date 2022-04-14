using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;

namespace CustomObjects
{
    public class OpeningBalance : ObjectBase
    {

        #region PrivateVariables
        private int pLedgerEntryId;
        private int pAccountId = -5000;
        private int pParticulars = 5000; //1 is the AccountId of OpeningBalance
        private decimal pDebitAmount;
        private decimal pCreditAmount;
        private DateTime pEntryDate;
        private string pNarration = string.Empty;
        private int pVoucherId = 0; // OpeningBalance will not have any voucher id
        private int pVoucherTypeId = 4; //Hidden voucher type.
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public int LedgerEntryId
        {
            get { return pLedgerEntryId; }
            set
            {
                if (!value.Equals(pLedgerEntryId))
                {
                    pLedgerEntryId = value;
                    PropertyHasChanged("LedgerEntryId");
                }
            }
        }

        public int AccountId
        {
            get { return pAccountId; }
            set
            {
                if (!value.Equals(pAccountId))
                {
                    pAccountId = value;
                    PropertyHasChanged("AccountId");
                }
            }
        }

        public int Particulars
        {
            get { return pParticulars; }
            //set
            //{
            //    if (!value.Equals(pParticulars))
            //    {
            //        pParticulars = value;
            //        PropertyHasChanged("Particulars");
            //    }
            //}
        }

        public decimal DebitAmount
        {
            get { return pDebitAmount; }
            set
            {
                if (!value.Equals(pDebitAmount))
                {
                    pDebitAmount = value;
                    PropertyHasChanged("DebitAmount");
                }
            }
        }

        public decimal CreditAmount
        {
            get { return pCreditAmount; }
            set
            {
                if (!value.Equals(pCreditAmount))
                {
                    pCreditAmount = value;
                    PropertyHasChanged("CreditAmount");
                }
            }
        }

        public DateTime EntryDate
        {
            get { return pEntryDate; }
            set
            {
                if (!value.Equals(pEntryDate))
                {
                    pEntryDate = value;
                    PropertyHasChanged("EntryDate");
                }
            }
        }

        public string Narration
        {
            get { return pNarration; }
            set
            {
                if (!value.Equals(pNarration))
                {
                    pNarration = value;
                    PropertyHasChanged("Narration");
                }
            }
        }

        public int VoucherId
        {
            get { return pVoucherId; }
            //set
            //{
            //    if (!value.Equals(pVoucherId))
            //    {
            //        pVoucherId = value;
            //        PropertyHasChanged("VoucherId");
            //    }
            //}
        }

        public int VoucherTypeId
        {
            get { return pVoucherTypeId; }
            //set
            //{
            //    if (!value.Equals(pVoucherTypeId))
            //    {
            //        pVoucherTypeId = value;
            //        PropertyHasChanged("VoucherTypeId");
            //    }
            //}
        }

        #endregion

        #region Constructors
        public OpeningBalance()
        {
        }

        public OpeningBalance(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static OpeningBalance SaveEntity(OpeningBalance openingbalance)
        {
            if (openingbalance.IsNew)
            {
                return OpeningBalance.CreateEntity(openingbalance);
            }
            else
            {
                return OpeningBalance.UpdateEntity(openingbalance);
            }
        }

        private static OpeningBalance CreateEntity(OpeningBalance openingbalance)
        {
            OleDbConnection Connection = new OleDbConnection(openingbalance.pConnectionString);
            OleDbCommand cmdCheckVoucherEntry = new OleDbCommand("select AccountId from tblLedger where AccountId=" + openingbalance.pAccountId + " and Particulars = 5000", Connection);
            OleDbCommand cmdInsert = new OleDbCommand("INSERT INTO tblLedger(AccountId, Particulars, DebitAmount, CreditAmount, EntryDate, Narration, VoucherId, VoucherTypeId) VALUES(" + openingbalance.pAccountId + "," + openingbalance.pParticulars + "," + openingbalance.pDebitAmount + "," + openingbalance.pCreditAmount + ",#" + openingbalance.pEntryDate.ToString("dd MMM yyyy") + "#,'" + openingbalance.pNarration + "'," + openingbalance.pVoucherId + "," + openingbalance.pVoucherTypeId + ")", Connection);
            OleDbCommand cmdLastId = new OleDbCommand("SELECT MAX(LedgerEntryId) AS LastId FROM tblLedger ", Connection);
            OleDbTransaction transaction = null;
            try
            {

                if (openingbalance.pAccountId == -5000)
                {
                    throw new ArgumentException("Select account head.");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCheckVoucherEntry.Transaction = transaction;
                cmdInsert.Transaction = transaction;
                cmdLastId.Transaction = transaction;

                object objAlreadyEntered = cmdCheckVoucherEntry.ExecuteScalar();
                if (objAlreadyEntered != null)
                {
                    //                    throw new ArgumentException("Voucher entry found for this account head. Opening balance entry not possible.");
                    throw new ArgumentException("Opening balance already entered.");
                }

                cmdCheckVoucherEntry.CommandText = "select AccountID from tblLedger where AccountID=" + openingbalance.pAccountId + " and Particulars > 1";
                object objVoucherFound = cmdCheckVoucherEntry.ExecuteScalar();
                if (objVoucherFound != null)
                {
                    throw new ArgumentException("Voucher entry found for this account head. Opening balance entry not possible.");

                }

                cmdInsert.ExecuteNonQuery();
                object LastId = cmdLastId.ExecuteScalar();
                openingbalance.pLedgerEntryId = (int)LastId;
                transaction.Commit();
                Connection.Close();
                openingbalance.MarkOld();
                return openingbalance;
            }
            catch (ArgumentException AEx)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw AEx;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
        }

        private static OpeningBalance UpdateEntity(OpeningBalance openingbalance)
        {
            OleDbConnection Connection = new OleDbConnection(openingbalance.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblLedger SET AccountId=" + openingbalance.pAccountId + ", Particulars=" + openingbalance.pParticulars + ", DebitAmount=" + openingbalance.pDebitAmount + ", CreditAmount=" + openingbalance.pCreditAmount + ", EntryDate=#" + openingbalance.pEntryDate.ToString("dd MMM yyyy") + "#, Narration='" + openingbalance.pNarration + "', VoucherId=" + openingbalance.pVoucherId + ", VoucherTypeId=" + openingbalance.pVoucherTypeId + "  WHERE LedgerEntryId=" + openingbalance.pLedgerEntryId + "", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;
                cmdUpdate.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                openingbalance.MarkClean();
                return openingbalance;
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
        }

        #endregion

        #region Read Entity

        public static OpeningBalance FillEntity(OleDbDataReader Reader)
        {
            OpeningBalance openingbalance = new OpeningBalance();
            openingbalance.pLedgerEntryId = (int)Reader["LedgerEntryId"];
            openingbalance.pAccountId = (int)Reader["AccountId"];
            openingbalance.pParticulars = (int)Reader["Particulars"];
            openingbalance.pDebitAmount = (decimal)Reader["DebitAmount"];
            openingbalance.pCreditAmount = (decimal)Reader["CreditAmount"];
            openingbalance.pEntryDate = (DateTime)Reader["EntryDate"];
            openingbalance.pNarration = Reader["Narration"].ToString();
            openingbalance.pVoucherId = (int)Reader["VoucherId"];
            openingbalance.pVoucherTypeId = (int)Reader["VoucherTypeId"];
            openingbalance.MarkOld();
            return openingbalance;
        }

        public static OpeningBalance GetEntity(int ledgerentryid, string ConnectionString)
        {
            OpeningBalance openingbalance = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT LedgerEntryId, AccountId, Particulars, DebitAmount, CreditAmount, EntryDate, Narration, VoucherId, VoucherTypeId FROM tblLedger WHERE LedgerEntryId=" + ledgerentryid + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        openingbalance = FillEntity(Reader);
                        openingbalance.pConnectionString = ConnectionString;
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return openingbalance;
        }

        public static List<OpeningBalance> GetEntityList(string ConnectionString)
        {
            List<OpeningBalance> OpeningBalanceList = new List<OpeningBalance>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  LedgerEntryId, AccountId, Particulars, DebitAmount, CreditAmount, EntryDate, Narration, VoucherId, VoucherTypeId FROM tblLedger ORDER BY ---";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        OpeningBalance openingbalance = FillEntity(Reader);
                        openingbalance.pConnectionString = ConnectionString;
                        OpeningBalanceList.Add(openingbalance);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return OpeningBalanceList;
        }

        public static DataTable GetHistory(string ConnectionString)
        {
            DataTable dtOpeningBalanceHistory = new DataTable();
            dtOpeningBalanceHistory.Columns.Add("AccountId", typeof(Int32));
            dtOpeningBalanceHistory.Columns.Add("AccountName", typeof(String));
            dtOpeningBalanceHistory.Columns.Add("AccountCode", typeof(Int32));
            dtOpeningBalanceHistory.Columns.Add("DebitAmount", typeof(Decimal));
            dtOpeningBalanceHistory.Columns.Add("CreditAmount", typeof(Decimal));

            DataSet ds = new DataSet();

            try
            {
                using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
                {
                    String sqlSelectAccountHeads = "select AccountId,AccountName,AccountCode from tblAccountHead Where IsDeleted=False and AccountId>5000";
                    String  sqlSelectLedgerData  = "Select AccountId,DebitAmount,CreditAmount from tblLedger Where VoucherTypeId=4 And Particulars=5000";
                    using (OleDbCommand cmdCommand=new OleDbCommand())
                    {
                        cmdCommand.CommandType = CommandType.Text;
                        cmdCommand.Connection = Connection;
                        using (OleDbDataAdapter daData=new OleDbDataAdapter())
                        {
                            daData.SelectCommand = cmdCommand;
                            Connection.Open();
                            cmdCommand.CommandText = sqlSelectAccountHeads;
                            daData.Fill(ds,"AccountHeads");
                            cmdCommand.CommandText = sqlSelectLedgerData;
                            daData.Fill(ds, "LedgerData");
                            Connection.Close();
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            DataTable dtAccountHeads = ds.Tables[0];
            DataTable dtLedgerData = ds.Tables[1];

            DataRow dr;
            foreach (DataRow row in dtAccountHeads.Rows)
            {
                dr = dtOpeningBalanceHistory.NewRow();
                Int32 AccountId =Convert.ToInt32( row["AccountId"]);
                dr["AccountId"] = AccountId;
                dr["AccountCode"]=Convert.ToInt32(row["AccountCode"]);
                dr["AccountName"] = row["AccountName"].ToString();

                DataRow[] OpeningBalanceRow = dtLedgerData.Select("AccountId="+ AccountId +"");
                if (OpeningBalanceRow.Length==0)
                {
                    dr["DebitAmount"] = 0;
                    dr["CreditAmount"] = 0;
                }
                else
                {
                    dr["DebitAmount"] =Convert.ToDecimal(OpeningBalanceRow[0]["DebitAmount"]);
                    dr["CreditAmount"] = Convert.ToDecimal(OpeningBalanceRow[0]["CreditAmount"]);
                }

                dtOpeningBalanceHistory.Rows.Add(dr);
            }

            return dtOpeningBalanceHistory;
        }

        #endregion

        #region Delete Entity
        public void DeleteEntity()
        {
            using (OleDbConnection Connection = new OleDbConnection(pConnectionString))
            {
                Connection.Open();
                string sqlDelete = "DELETE LedgerEntryId, AccountId, Particulars, DebitAmount, CreditAmount, EntryDate, Narration, VoucherId, VoucherTypeId FROM tblLedger WHERE LedgerEntryId=" + this.pLedgerEntryId + "";
                OleDbCommand cmdDelete = new OleDbCommand(sqlDelete, Connection);
                Connection.Close();
            }
        }

        #endregion

        #region Utility
        public override string ToString()
        {
            return ".......";
        }
        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        #endregion

    }
}

