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
    public class AccountNode : ObjectBase
    {

        #region PrivateVariables
        private Int32 pAccountId;
        private Int32 pAccountCode;
        private String pAccountName;
        private Int32 pSubCategoryId;
        private String pNodeTag;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public Int32 AccountId
        {
            get { return pAccountId; }
            set
            {
                pAccountId = value;
            }
        }

        public Int32 AccountCode
        {
            get { return pAccountCode; }
            set
            {
                pAccountCode = value;
            }
        }

        public String AccountName
        {
            get { return pAccountName; }
            set
            {
                pAccountName = value;
            }
        }

        public String AccountNameWithCode
        {
            get 
            {
                String accounName = (pAccountCode == 0) ? pAccountName : pAccountName + " (" + pAccountCode.ToString() + ")";

                return accounName;
            }
        }

        public Int32 SubCategoryId
        {
            get { return pSubCategoryId; }
            set
            {
                pSubCategoryId = value;
            }
        }

        public String NodeTag
        {
            get { return pNodeTag; }
            set
            {
                pNodeTag = value;
            }
        }

        #endregion

        #region Constructors
        public AccountNode()
        {
        }

        public AccountNode(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        

        #region Read Entity

        public static AccountNode FillEntity(OleDbDataReader Reader)
        {
            AccountNode AN = new AccountNode();
            AN.pAccountId = Convert.ToInt32(Reader["AccountId"]);
            AN.pAccountCode = Convert.ToInt32(Reader["AccountCode"]);
            AN.pAccountName = Reader["AccountName"].ToString();
            AN.pSubCategoryId = Convert.ToInt32(Reader["SubCategoryId"]);
            AN.pNodeTag = Reader["NodeTag"].ToString();
            return AN;
        }

        public static AccountNode GetEntity(int accountid, string ConnectionString)
        {
            AccountNode AN = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                AN = AccountNode.GetEntity(accountid, Connection);
                AN.pConnectionString = ConnectionString;
                Connection.Close();
            }
            return AN;
        }

        public static AccountNode GetEntity(int accountid, OleDbConnection Connection)
        {
            AccountNode AN = null;
            string sqlSelect = "SELECT AccountId, AccountCode, AccountName, SubCategoryId, NodeTag FROM tblAccountHead WHERE AccountId=" + accountid + "";
            using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
            {
                OleDbDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    AN = FillEntity(Reader);
                }
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
            }
            return AN;
        }

        public static List<AccountNode> GetEntityList(string ConnectionString)
        {
            List<AccountNode> AccountNodeList = new List<AccountNode>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                //Account>5000 has been set in order to avoid conflict between AccountId and SubCategoryId in TreeView.
                //SubCategoryId starts from 1. AccountId starts from 5000.
                string sqlSelect = "SELECT  AccountId, AccountCode, AccountName, SubCategoryId, NodeTag FROM tblAccountHead WHERE AccountId>5000 AND IsDeleted=False  ORDER BY SubCategoryId ASC";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AccountNode AN = FillEntity(Reader);
                        AN.pConnectionString = ConnectionString;
                        AccountNodeList.Add(AN);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AccountNodeList;
        }

        public static List<AccountNode> GetComboList(string ConnectionString)
        {
            List<AccountNode> AccountNodeList = new List<AccountNode>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  AccountId, AccountCode, AccountName, SubCategoryId, NodeTag FROM tblAccountHead ORDER BY ";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        AccountNode AN = FillEntity(Reader);
                        AN.pConnectionString = ConnectionString;
                        AccountNodeList.Add(AN);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return AccountNodeList;
        }

        public static DataTable GetEntityTable(string ConnectionString)
        {
            DataTable AccountNodeTable = new DataTable();
            string sqlSelect = "SELECT  AccountId, AccountCode, AccountName, SubCategoryId, NodeTag FROM tblAccountHead ORDER BY ---";
            using (OleDbDataAdapter daData = new OleDbDataAdapter(sqlSelect, ConnectionString))
            {
                daData.Fill(AccountNodeTable);
            }
            return AccountNodeTable;
        }

        #endregion

        #region Delete Entity
        public static void DeleteEntity(AccountNode AN)
        {
            OleDbConnection Connection = new OleDbConnection(AN.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                string sqlDelete = "DELETE AccountId, AccountCode, AccountName, SubCategoryId, NodeTag FROM tblAccountHead WHERE AccountId=" + AN.pAccountId + "";
                sqlFunction.DeleteRecord(sqlDelete);
                //NB- if this entity is Stock 'DecreaseType', nothnig needed. Otherwise multiply by -1 
                // RawItem.UpdateCurrentBalance(AN.pRawItemId, AN.pQuantityOriginal * -1, Connection, transaction);
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