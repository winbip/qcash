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
    public class AccountType : ObjectBase
    {

        #region PrivateVariables
        private Int32 pAccountTypeId;
        private String pAccountTypeName;
        private string pConnectionString;
        #endregion

        #region PublicProperties
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

        public String AccountTypeName
        {
            get { return pAccountTypeName; }
            set
            {
                if (!value.Equals(pAccountTypeName))
                {
                    pAccountTypeName = value;
                    PropertyHasChanged("AccountTypeName");
                }
            }
        }

        #endregion

        #region Constructors
        public AccountType()
        {
        }

        public AccountType(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static AccountType SaveEntity(AccountType AT)
        {
            if (AT.IsNew)
            {
                return AccountType.CreateEntity(AT);
            }
            else
            {
                return AccountType.UpdateEntity(AT);
            }
        }

        private static AccountType CreateEntity(AccountType AT)
        {
            OleDbConnection Connection = new OleDbConnection(AT.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                AT.pAccountTypeId = sqlFunction.CreateNewId("tblAccountType", "AccountTypeId");
                sqlFunction.InsertRecord("INSERT INTO tblAccountType(AccountTypeId, AccountTypeName) VALUES(" + AT.pAccountTypeId + ",'" + AT.pAccountTypeName + "' )");

                //NB- If this Entity is Stock 'DecreaseType', then multiply by -1, otherwise nothing is needed.
                //RawItem.UpdateCurrentBalance(AT.pRawItemId, AT.pQuantity, Connection, transaction);

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                //AT.pQuantityOriginal = AT.pQuantity;
                AT.MarkOld();
                return AT;
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

        private static AccountType UpdateEntity(AccountType AT)
        {
            OleDbConnection Connection = new OleDbConnection(AT.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                sqlFunction.UpdateRecord("UPDATE tblAccountType SET AccountTypeName='" + AT.pAccountTypeName + "'  WHERE AccountTypeId=" + AT.pAccountTypeId + "");

                //NB- If this Entity is Stock 'DecreaseType'
                //then DifferenceOfQuantity =  AT.pQuantityOriginal-AT.pQuantity
                //Otherwise 
                //DifferenceOfQuantity =  AT.pQuantity-AT.pQuantityOriginal

                //if (!AT.pQuantity.Equals(AT.pQuantityOriginal))
                // {
                //decimal DifferenceOfQuantity = AT.pQuantity - AT.pQuantityOriginal;
                //RawItem.UpdateCurrentBalance(AT.pRawItemDetails.RawItemId, DifferenceOfQuantity, Connection, transaction);
                //}

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                //AT.pQuantityOriginal = AT.pQuantity;
                AT.MarkClean();
                return AT;
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

        public static AccountType FillEntity(OleDbDataReader Reader)
        {
            AccountType AT = new AccountType();
            AT.pAccountTypeId = Convert.ToInt32(Reader["AccountTypeId"]);
            AT.pAccountTypeName = Reader["AccountTypeName"].ToString();
           // AT.MarkOld();
            return AT;
        }

        public static AccountType GetEntity(int accounttypeid, string ConnectionString)
        {
            AccountType AT = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                AT = AccountType.GetEntity(accounttypeid, Connection);
                AT.pConnectionString = ConnectionString;
                Connection.Close();
            }
            return AT;
        }

        public static AccountType GetEntity(int accounttypeid, OleDbConnection Connection)
        {
            AccountType AT = null;
            string sqlSelect = "SELECT AccountTypeId, AccountTypeName FROM tblAccountType WHERE AccountTypeId=" + accounttypeid + "";
            using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
            {
                OleDbDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    AT = FillEntity(Reader);
                }
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
            }
            return AT;
        }

        public static List<AccountType> GetEntityList(string ConnectionString)
        {
            List<AccountType> AccountTypeList = new List<AccountType>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  AccountTypeId, AccountTypeName FROM tblAccountType ORDER BY ";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AccountType AT = FillEntity(Reader);
                        AT.pConnectionString = ConnectionString;
                        AccountTypeList.Add(AT);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AccountTypeList;
        }

        public static BindingList<AccountType> GetComboList(string ConnectionString)
        {
            BindingList<AccountType> AccountTypeList = new BindingList<AccountType>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  AccountTypeId, AccountTypeName FROM tblAccountType Where AccountTypeId<>0 ORDER BY AccountTypeId asc";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AccountType AT = FillEntity(Reader);
                        AT.pConnectionString = ConnectionString;
                        AccountTypeList.Add(AT);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AccountTypeList;
        }

        public static DataTable GetEntityTable(string ConnectionString)
        {
            DataTable AccountTypeTable = new DataTable();
            string sqlSelect = "SELECT  AccountTypeId, AccountTypeName FROM tblAccountType ORDER BY ---";
            using (OleDbDataAdapter daData = new OleDbDataAdapter(sqlSelect, ConnectionString))
            {
                daData.Fill(AccountTypeTable);
            }
            return AccountTypeTable;
        }

        #endregion

        #region Delete Entity
        public static void DeleteEntity(AccountType AT)
        {
            OleDbConnection Connection = new OleDbConnection(AT.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                string sqlDelete = "DELETE AccountTypeId, AccountTypeName FROM tblAccountType WHERE AccountTypeId=" + AT.pAccountTypeId + "";
                sqlFunction.DeleteRecord(sqlDelete);
                //NB- if this entity is Stock 'DecreaseType', nothnig needed. Otherwise multiply by -1 
                // RawItem.UpdateCurrentBalance(AT.pRawItemId, AT.pQuantityOriginal * -1, Connection, transaction);
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

        #endregion

    }
}