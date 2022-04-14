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
    public class AccountHead : ObjectBase
    {

        #region PrivateVariables
        private Int32 pAccountId;
        private Int32 pAccountCode;
        private String pAccountName;
        private Int32 pAccountTypeId;
        private Int32 pSubCategoryId;
        private Boolean pIsCashBookDefault;
        private Boolean pIsDeleted;
        private Boolean pIsSystemDefined;
        private String pNodeTag;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public Int32 AccountId
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

        public Int32 AccountCode
        {
            get { return pAccountCode; }
            set
            {
                if (!value.Equals(pAccountCode))
                {
                    pAccountCode = value;
                    PropertyHasChanged("AccountCode");
                }
            }
        }

        public String AccountName
        {
            get { return pAccountName; }
            set
            {
                if (!value.Equals(pAccountName))
                {
                    pAccountName = value;
                    PropertyHasChanged("AccountName");
                }
            }
        }

        public Int32 AccountTypeId
        {
            get { return pAccountTypeId; }
            set
            {
                if (!value.Equals(pAccountTypeId))
                {
                    pAccountTypeId = value;
                    PropertyHasChanged("AccountTypeId");
                }
            }
        }

        public Int32 SubCategoryId
        {
            get { return pSubCategoryId; }
            set
            {
                if (!value.Equals(pSubCategoryId))
                {
                    pSubCategoryId = value;
                    PropertyHasChanged("SubCategoryId");
                }
            }
        }

        public Boolean IsCashBookDefault
        {
            get { return pIsCashBookDefault; }
            set
            {
                if (!value.Equals(pIsCashBookDefault))
                {
                    pIsCashBookDefault = value;
                    PropertyHasChanged("IsCashBookDefault");
                }
            }
        }

        public Boolean IsAccountHeadDeleted
        {
            get { return pIsDeleted; }
            set
            {
                if (!value.Equals(pIsDeleted))
                {
                    pIsDeleted = value;
                    PropertyHasChanged("IsAccountHeadDeleted");
                }
            }
        }

        public Boolean IsSystemDefined
        {
            get { return pIsSystemDefined; }
            set
            {
                if (!value.Equals(pIsSystemDefined))
                {
                    pIsSystemDefined = value;
                    PropertyHasChanged("IsSystemDefined");
                }
            }
        }

        public String NodeTag
        {
            get { return pNodeTag; }
            set
            {
                if (!value.Equals(pNodeTag))
                {
                    pNodeTag = value;
                    PropertyHasChanged("NodeTag");
                }
            }
        }

        #endregion

        #region Constructors
        public AccountHead()
        {

        }

        public AccountHead(string ConnectionString)
        {
            pConnectionString = ConnectionString;
            OleDbConnection Connection = new OleDbConnection(pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
           // OleDbTransaction transaction = null;

            try
            {
                Connection.Open();
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                this. pAccountCode = sqlFunction.GetLastPrimaryKeyValue("Select Max(AccountCode) as MaxId From tblAccountHead Where IsDeleted=False");
                this.pAccountCode++;
                this.pAccountCode = (this.pAccountCode == 1) ? 101 : this.pAccountCode;
                Connection.Close();
                sqlFunction.Dispose();
            }
            catch (Exception Ex){throw Ex;}

            this.pIsCashBookDefault = false;
            this.pIsDeleted = false;
            this.pIsSystemDefined = false;
            this.pNodeTag = "UserDefinedAccountHead";
        }
        #endregion

        #region Save Entity
        public static AccountHead SaveEntity(AccountHead AH)
        {
            if (AH.IsNew)
            {
                return AccountHead.CreateEntity(AH);
            }
            else
            {
                return AccountHead.UpdateEntity(AH);
            }
        }

        private static AccountHead CreateEntity(AccountHead AH)
        {
            OleDbConnection Connection = new OleDbConnection(AH.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                if (String.IsNullOrEmpty(AH.pAccountName))
                {
                    throw new ExceptionWithControl("", "", "Enter Account Name.", "txtAccountName");
                }
                if (AH.pAccountName.Length>50)
                {
                    throw new ExceptionWithControl("", "", "Account Name can not be more than 50 characters.", "txtAccountName");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);

                //NB- If user left AccountCode empty, it was transformed into zero(0) in UI form.
                if (AH.pAccountCode>0)
                {
                    if (sqlFunction.SearchRecordsBasedOnNonAggregatedCount("Select Count(AccountCode) from tblAccountHead Where AccountCode="+ AH.pAccountCode +" and IsDeleted=False"))
                    {
                        throw new ExceptionWithControl("", "", "Account Code already exists.", "txtAccountCode");
                    }
                }

                if (sqlFunction.SearchString("Select AccountName from tblAccountHead WHERE AccountName='"+ AH.pAccountName +"' AND IsDeleted=False"))
                {
                    throw new ExceptionWithControl("", "", "Account Name already exists.", "txtAccountName");
                }

                AH.pAccountId = sqlFunction.CreateNewId("tblAccountHead", "AccountId");
                //NB- Empty AccountCode has been handled (Set to 0) in UI form (frmAccountDetails).
                sqlFunction.InsertRecord("INSERT INTO tblAccountHead(AccountId, AccountCode, AccountName, AccountTypeId, SubCategoryId, IsCashBookDefault, IsDeleted, IsSystemDefined, NodeTag) VALUES(" + AH.pAccountId + "," + AH.pAccountCode + ",'" + AH.pAccountName + "'," + AH.pAccountTypeId + "," + AH.pSubCategoryId + "," + AH.pIsCashBookDefault + "," + AH.pIsDeleted + "," + AH.pIsSystemDefined + ",'" + AH.pNodeTag + "' )");

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                //AH.pQuantityOriginal = AH.pQuantity;
                AH.MarkOld();
                return AH;
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

        private static AccountHead UpdateEntity(AccountHead AH)
        {
            OleDbConnection Connection = new OleDbConnection(AH.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                if (String.IsNullOrEmpty(AH.pAccountName))
                {
                    throw new ExceptionWithControl("", "", "Enter Account Name.", "txtAccountName");
                }
                if (AH.pAccountName.Length > 50)
                {
                    throw new ExceptionWithControl("", "", "Account Name can not be more than 50 characters.", "txtAccountName");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);


                //NB- If user left AccountCode empty, it was transformed into zero(0) in UI form.
                if (AH.pAccountCode > 0)
                {
                    if (sqlFunction.SearchRecordsBasedOnNonAggregatedCount("Select Count(AccountCode) from tblAccountHead Where AccountCode=" + AH.pAccountCode + " and IsDeleted=False AND AccountId<>"+ AH.pAccountId +""))
                    {
                        throw new ExceptionWithControl("", "", "Account Code already exists.", "txtAccountCode");
                    }
                }

                if (sqlFunction.SearchString("Select AccountName from tblAccountHead WHERE AccountName='" + AH.pAccountName + "' AND AccountId<>" + AH.pAccountId + " AND IsDeleted=False"))
                {
                    throw new ExceptionWithControl("", "", "Account Name already exists.", "txtAccountName");
                }

                sqlFunction.UpdateRecord("UPDATE tblAccountHead SET AccountCode=" + AH.pAccountCode + ", AccountName='" + AH.pAccountName + "', AccountTypeId=" + AH.pAccountTypeId + ", SubCategoryId=" + AH.pSubCategoryId + ", IsCashBookDefault=" + AH.pIsCashBookDefault + ", IsDeleted=" + AH.pIsDeleted + ", IsSystemDefined=" + AH.pIsSystemDefined + ", NodeTag='" + AH.pNodeTag + "'  WHERE AccountId=" + AH.pAccountId + "");

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                AH.MarkClean();
                return AH;
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

        #endregion

        #region Read Entity

        public static AccountHead FillEntity(OleDbDataReader Reader)
        {
            AccountHead AH = new AccountHead();
            AH.pAccountId = Convert.ToInt32(Reader["AccountId"]);
            AH.pAccountCode = Convert.ToInt32(Reader["AccountCode"]);
            AH.pAccountName = Reader["AccountName"].ToString();
            AH.pAccountTypeId = Convert.ToInt32(Reader["AccountTypeId"]);
            AH.pSubCategoryId = Convert.ToInt32(Reader["SubCategoryId"]);
            AH.pIsCashBookDefault = Convert.ToBoolean(Reader["IsCashBookDefault"]);
            AH.pIsDeleted = Convert.ToBoolean(Reader["IsDeleted"]);
            AH.pIsSystemDefined = Convert.ToBoolean(Reader["IsSystemDefined"]);
            AH.pNodeTag = Reader["NodeTag"].ToString();
            AH.MarkOld();
            return AH;
        }

        public static AccountHead GetEntity(int accountid, string ConnectionString)
        {
            AccountHead AH = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                AH = AccountHead.GetEntity(accountid, Connection);
                AH.pConnectionString = ConnectionString;
                Connection.Close();
            }
            return AH;
        }

        public static AccountHead GetEntity(int accountid, OleDbConnection Connection)
        {
            AccountHead AH = null;
            string sqlSelect = "SELECT AccountId, AccountCode, AccountName, AccountTypeId, SubCategoryId, IsCashBookDefault, IsDeleted, IsSystemDefined, NodeTag FROM tblAccountHead WHERE AccountId=" + accountid + "";
            using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
            {
                OleDbDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    AH = FillEntity(Reader);
                }
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
            }
            return AH;
        }

        public static List<AccountHead> GetEntityList(string ConnectionString)
        {
            List<AccountHead> AccountHeadList = new List<AccountHead>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  AccountId, AccountCode, AccountName, AccountTypeId, SubCategoryId, IsCashBookDefault, IsDeleted, IsSystemDefined, NodeTag FROM tblAccountHead ORDER BY ";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AccountHead AH = FillEntity(Reader);
                        AH.pConnectionString = ConnectionString;
                        AccountHeadList.Add(AH);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AccountHeadList;
        }

        public static List<AccountHead> GetComboList(string ConnectionString)
        {
            List<AccountHead> AccountHeadList = new List<AccountHead>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  AccountId, AccountCode, AccountName, AccountTypeId, SubCategoryId, IsCashBookDefault, IsDeleted, IsSystemDefined, NodeTag FROM tblAccountHead ORDER BY ";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AccountHead AH = FillEntity(Reader);
                        AH.pConnectionString = ConnectionString;
                        AccountHeadList.Add(AH);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AccountHeadList;
        }

        public static DataTable GetEntityTable(string ConnectionString)
        {
            DataTable AccountHeadTable = new DataTable();
            string sqlSelect = "SELECT  AccountId, AccountCode, AccountName, AccountTypeId, SubCategoryId, IsCashBookDefault, IsDeleted, IsSystemDefined, NodeTag FROM tblAccountHead ORDER BY ---";
            using (OleDbDataAdapter daData = new OleDbDataAdapter(sqlSelect, ConnectionString))
            {
                daData.Fill(AccountHeadTable);
            }
            return AccountHeadTable;
        }

        #endregion

        #region Delete Entity
        public static void DeleteEntity(AccountHead AH)
        {
            OleDbConnection Connection = new OleDbConnection(AH.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);

                if (sqlFunction.SearchRecordsBasedOnAggregatedCount("Select Count(LedgerEntryId) as TotalLedger from tblLedger Group By AccountId Having AccountId="+ AH.pAccountId +""))
                {
                    throw new ExceptionWithControl("", "", "This Account Head can not be deleted.", "txtAccountName");
                }

                string sqlDelete = "Update tblAccountHead Set IsDeleted=True WHERE AccountId=" + AH.pAccountId + "";
                sqlFunction.DeleteRecord(sqlDelete);

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
            }
            catch (ExceptionWithoutControl WithoutControlException) { if (transaction != null) { transaction.Rollback(); } throw WithoutControlException; }
            catch (ExceptionWithControl WithControlException) { if (transaction != null) { transaction.Rollback(); } throw WithControlException; }
            catch (Exception ex) { if (transaction != null) { transaction.Rollback(); } throw ex; }
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

        public static Boolean IsCashBookAccountDefined(String ConnectionString)
        {
            Boolean Defined=false;
            OleDbConnection Connection = new OleDbConnection(ConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            // OleDbTransaction transaction = null;

            try
            {
                Connection.Open();
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                Defined = sqlFunction.SearchRecordsBasedOnNonAggregatedCount("Select Count(AccountId) as TotalCount from tblAccountHead where IsCashBookDefault=True");
                Connection.Close();
                sqlFunction.Dispose();
            }
            catch (Exception Ex) { throw Ex; }

            return Defined;
        }

        public static Object GetCashBookAccountId(String ConnectionString)
        {
            
            OleDbConnection Connection = new OleDbConnection(ConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
           

            try
            {
                Connection.Open();
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                Object result=sqlFunction.Search ("Select AccountId from tblAccountHead where IsCashBookDefault=True");
                Connection.Close();
                sqlFunction.Dispose();
                return result;
            }
            catch (Exception Ex) { throw Ex; }

           
        }

        #endregion

    }
}