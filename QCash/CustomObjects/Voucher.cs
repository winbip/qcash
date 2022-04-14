using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using sCommonLib.Exceptions;
using sCommonLib.SqlCommander;

namespace CustomObjects
{
    public class Voucher : ObjectBase
    {

        #region PrivateVariables
        private int pLedgerEntryId;
        private int pDebitAccountId;
        private int pCreditAccountId;
        private decimal pAmount;
        private DateTime pEntryDate;
        private string pNarration = string.Empty;
        private Int32 pVoucherId;
        private Int32 pVoucherTypeId;
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

        public int DebitAccountId
        {
            get { return pDebitAccountId; }
            set
            {
                if (!value.Equals(pDebitAccountId))
                {
                    pDebitAccountId = value;
                    PropertyHasChanged("DebitAccountId");
                }
            }
        }

        public int CreditAccountId
        {
            get { return pCreditAccountId; }
            set
            {
                if (!value.Equals(pCreditAccountId))
                {
                    pCreditAccountId = value;
                    PropertyHasChanged("CreditAccountId");
                }
            }
        }

        public decimal Amount
        {
            get { return pAmount; }
            set
            {
                if (!value.Equals(pAmount))
                {
                    pAmount = value;
                    PropertyHasChanged("Amount");
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

        public Int32 VoucherId
        {
            get { return pVoucherId; }
            set
            {
                if (!value.Equals(pVoucherId))
                {
                    pVoucherId = value;
                    PropertyHasChanged("VoucherId");
                }
            }
        }

        public int VoucherTypeId
        {
            get { return pVoucherTypeId; }
            set
            {
                if (!value.Equals(pVoucherTypeId))
                {
                    pVoucherTypeId = value;
                    PropertyHasChanged("VoucherTypeId");
                }
            }
        }

        #endregion

        #region Constructors
        public Voucher()
        {
        }

        public Voucher(string ConnectionString, Int32 VoucherType)
        {
            this.pConnectionString = ConnectionString;
            this.pVoucherTypeId = VoucherType;
            this.pEntryDate = DateTime.Today.Date;
            OleDbConnection Connection = new OleDbConnection(pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;

            try
            {
                Connection.Open();
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                this.pVoucherId = sqlFunction.CreateNewId("SELECT Max(VoucherID) AS MaxOfVoucherID FROM tblLedger GROUP BY VoucherTypeID HAVING VoucherTypeID=" + this.pVoucherTypeId + "");
                Connection.Close();
                sqlFunction.Dispose();
            }
            catch (Exception Ex) { throw Ex; }
        }
        #endregion

        #region Save Entity
        public static Voucher SaveEntity(Voucher voucher)
        {
            if (voucher.IsNew)
            {
                return Voucher.CreateEntity(voucher);
            }
            else
            {
                return Voucher.UpdateEntity(voucher);
            }
        }

        private static Voucher CreateEntity(Voucher voucher)
        {

            OleDbConnection Connection = new OleDbConnection(voucher.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            string sqlInsert = string.Empty;

            try
            {

                if (voucher.DebitAccountId==voucher.CreditAccountId)
                {
                    throw new ExceptionWithControl("", "", "Both Account Head can not be same.", "cmbDebitAccount");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);

                if (sqlFunction.SearchRecordsBasedOnNonAggregatedCount("Select VoucherId from tblLedger Where VoucherTypeId="+ voucher.pVoucherTypeId +" and VoucherId="+ voucher.pVoucherId +""))
                {
                    throw new ExceptionWithControl("", "", "Voucher No. already exists.", "txtVoucherId");
                }

                //start saving DrAccount information to the ledger book
                sqlInsert = "insert into tblLedger(AccountID, Particulars, DebitAmount, CreditAmount, EntryDate,Narration,VoucherTypeID,VoucherID) ";
                sqlInsert += " values(" + voucher.pDebitAccountId + "," + voucher.pCreditAccountId + "," + voucher.pAmount + ",0,#" + voucher.pEntryDate.ToString("dd MMM yyyy") + "#,'" + voucher.pNarration + "'," + voucher.pVoucherTypeId + "," + voucher.pVoucherId + ")";

                sqlFunction.InsertRecord(sqlInsert);

                //'start saving CrAccount information to the ledger book
                sqlInsert = "insert into tblLedger(AccountID, Particulars, DebitAmount, CreditAmount, EntryDate,Narration,VoucherTypeID,VoucherID) ";
                sqlInsert += " values(" + voucher.pCreditAccountId + "," + voucher.pDebitAccountId + ",0," + voucher.pAmount + ",#" + voucher.pEntryDate.ToString("dd MMM yyyy") + "#,'" + voucher.pNarration + "'," + voucher.pVoucherTypeId + "," + voucher.pVoucherId + ")";

                sqlFunction.InsertRecord(sqlInsert);

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                voucher.MarkOld();
                return voucher;
            }
            catch (ExceptionWithoutControl WithoutControlException) { if (transaction != null) { transaction.Rollback(); } throw WithoutControlException; }
            catch (ExceptionWithControl WithControlException) { if (transaction != null) { transaction.Rollback(); } throw WithControlException; }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
        }

        private static Voucher UpdateEntity(Voucher voucher)
        {
            OleDbConnection Connection = new OleDbConnection(voucher.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("", Connection);
            OleDbTransaction trans = null;
            try
            {
                string sqlUpdate = string.Empty;
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;

                //--> update dr side
                sqlUpdate = "Update tblLedger set AccountID=" + voucher.pDebitAccountId + ", Particulars=" + voucher.pCreditAccountId + ", DebitAmount=" + voucher.pAmount + ", CreditAmount=0, EntryDate=#" +  voucher.pEntryDate.ToString("dd MMM yyyy") + "#,Narration='" + voucher.pNarration + "' where VoucherTypeId=" + voucher.pVoucherTypeId + " and VoucherId=" + voucher.pVoucherId + " and CreditAmount=0";
                cmdUpdate.CommandText = sqlUpdate;
                cmdUpdate.ExecuteNonQuery();
                //<-- update dr side

                //--> update cr side
                sqlUpdate = "Update tblLedger set AccountID=" + voucher.pCreditAccountId + ", Particulars=" + voucher.pDebitAccountId + ", DebitAmount=0, CreditAmount=" + voucher.pAmount + ", EntryDate=#" + voucher.pEntryDate.ToString("dd MMM yyyy") + "#,Narration='" + voucher.pNarration + "' where VoucherTypeId=" + voucher.pVoucherTypeId + " and VoucherId=" + voucher.pVoucherId + " and DebitAmount=0";
                cmdUpdate.CommandText = sqlUpdate;
                cmdUpdate.ExecuteNonQuery();
                //<-- update cr side

                trans.Commit();
                Connection.Close();
                voucher.MarkClean();
                return voucher;
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

        public static Voucher FillEntity(OleDbDataReader Reader)
        {
            Voucher voucher = new Voucher();
            voucher.pDebitAccountId = (int)Reader["AccountId"];
            voucher.pCreditAccountId = (int)Reader["Particulars"];
            voucher.pAmount = (decimal)Reader["DebitAmount"];
            voucher.pEntryDate = (DateTime)Reader["EntryDate"];
            voucher.pNarration = Reader["Narration"].ToString();
            voucher.pVoucherId = (int)Reader["VoucherId"];
            voucher.pVoucherTypeId = (int)Reader["VoucherTypeId"];
            voucher.MarkOld();
            return voucher;
        }

        public static Voucher GetEntity(int voucherId, int voucherTypeId, string ConnectionString)
        {
            Voucher voucher = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "select AccountID,Particulars,DebitAmount,CreditAmount,EntryDate,Narration,VoucherId, VoucherTypeId from tblLedger where VoucherID=" + voucherId + " and VoucherTypeID=" + voucherTypeId + " order by LedgerEntryID asc";
                //in the upper line, LedgerEntryID is sorted as asc because in this voucher dr account has entered first, then cr account. so dr account will have smaller LegherEntryID

                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        voucher = FillEntity(Reader);
                        voucher.pConnectionString = ConnectionString;
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return voucher;
        }


        public static Voucher GetFirstEntity(int voucherTypeId, string ConnectionString)
        {
            Voucher voucher = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                OleDbCommand cmdCommand = new OleDbCommand();
                cmdCommand.Connection = Connection;
                cmdCommand.CommandText = "SELECT Min(VoucherID) AS MinOfVoucherID FROM tblLedger GROUP BY VoucherTypeID HAVING VoucherTypeID=" + voucherTypeId + "";

                object firstVoucher = cmdCommand.ExecuteScalar();
                if (firstVoucher != null)
                {
                    int voucherId = (int)firstVoucher;
                    voucher = Voucher.GetEntity(voucherId, voucherTypeId, ConnectionString);
                }
            }
            return voucher;
        }

        public static Voucher GetPreviousEntity(int CurrentVoucherId, int voucherTypeId, string ConnectionString)
        {
            Voucher voucher = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                OleDbCommand cmdCommand = new OleDbCommand();
                cmdCommand.Connection = Connection;
                cmdCommand.CommandText = "SELECT MAX(VoucherID) AS PrevVoucherID FROM tblLedger WHERE VoucherID <" + CurrentVoucherId + " AND VoucherTypeID=" + voucherTypeId + "";

                object firstVoucher = cmdCommand.ExecuteScalar();
                if (firstVoucher != DBNull.Value)
                {
                    int voucherId = (int)firstVoucher;
                    voucher = Voucher.GetEntity(voucherId, voucherTypeId, ConnectionString);
                }
            }
            return voucher;
        }

        public static Voucher GetNextEntity(int CurrentVoucherId, int voucherTypeId, string ConnectionString)
        {
            Voucher voucher = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                OleDbCommand cmdCommand = new OleDbCommand();
                cmdCommand.Connection = Connection;
                cmdCommand.CommandText = "SELECT MIN(VoucherID) AS NextVoucherID FROM tblLedger WHERE VoucherID>" + CurrentVoucherId + " AND VoucherTypeID=" + voucherTypeId + "";

                object firstVoucher = cmdCommand.ExecuteScalar();
                if (firstVoucher != DBNull.Value)
                {
                    int voucherId = (int)firstVoucher;
                    voucher = Voucher.GetEntity(voucherId, voucherTypeId, ConnectionString);
                }
            }
            return voucher;
        }

        public static Voucher GetLastEntity(int voucherTypeId, string ConnectionString)
        {
            Voucher voucher = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                OleDbCommand cmdCommand = new OleDbCommand();
                cmdCommand.Connection = Connection;
                cmdCommand.CommandText = "SELECT MAX(VoucherID) AS MaxOfVoucherID FROM tblLedger GROUP BY VoucherTypeID HAVING VoucherTypeID=" + voucherTypeId + "";

                object firstVoucher = cmdCommand.ExecuteScalar();
                if (firstVoucher != null)
                {
                    int voucherId = (int)firstVoucher;
                    voucher = Voucher.GetEntity(voucherId, voucherTypeId, ConnectionString);
                }
            }
            return voucher;
        }

        public static List<Voucher> GetEntityList(string ConnectionString)
        {
            List<Voucher> VoucherList = new List<Voucher>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  LedgerEntryId, AccountId, Particulars, DebitAmount, CreditAmount, EntryDate, Narration, VoucherId, VoucherTypeId FROM tblLedger ORDER BY ---";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        Voucher voucher = FillEntity(Reader);
                        voucher.pConnectionString = ConnectionString;
                        VoucherList.Add(voucher);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return VoucherList;
        }

        #endregion

        #region Delete Entity
        public void DeleteEntity()
        {
            using (OleDbConnection Connection = new OleDbConnection(pConnectionString))
            {
                Connection.Open();
                string sqlDelete = "DELETE *  FROM tblLedger WHERE VoucherTypeId="+ this.pVoucherTypeId +" and VoucherId="+ this.pVoucherId +"";
                OleDbCommand cmdDelete = new OleDbCommand(sqlDelete, Connection);
                cmdDelete.ExecuteNonQuery();
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

        public void SetDebitAccountId(Int32 debitAccountId)
        {
            this.pDebitAccountId = debitAccountId;
        }

        public void SetCreditAccountId(Int32 creditAccountId)
        {
            this.pCreditAccountId=creditAccountId;
        }

        public void SetVoucherId(Int32 voucherId)
        {
            this.pVoucherId = voucherId;
        }
        #endregion


    }
}