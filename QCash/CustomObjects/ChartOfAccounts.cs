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
    public class ChartOfAccounts : ObjectBase
    {

        #region PrivateVariables
        private String pAccountName;
        private Int32 pAccountCode;
        private String pSubCategoryName;
        private String pAccountTypeName;
        private string pConnectionString;
        #endregion

        #region PublicProperties
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

        public String AccountCode
        {
            get
            {
                String accountCode = (pAccountCode == 0) ? String.Empty : pAccountCode.ToString();
                return accountCode; 
            }

        }

        public String SubCategoryName
        {
            get { return pSubCategoryName; }
            set
            {
                if (!value.Equals(pSubCategoryName))
                {
                    pSubCategoryName = value;
                    PropertyHasChanged("SubCategoryName");
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
        public ChartOfAccounts()
        {
        }

        public ChartOfAccounts(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        

        #region Read Entity

        public static ChartOfAccounts FillEntity(OleDbDataReader Reader)
        {
            ChartOfAccounts COA = new ChartOfAccounts();
            COA.pAccountName = Reader["AccountName"].ToString();
            COA.pAccountCode = Convert.ToInt32(Reader["AccountCode"]);
            COA.pSubCategoryName = Reader["SubCategoryName"].ToString();
            COA.pAccountTypeName = Reader["AccountTypeName"].ToString();
            COA.MarkOld();
            return COA;
        }

        public static List<ChartOfAccounts> GetEntityList(string ConnectionString)
        {
            List<ChartOfAccounts> ChartOfAccountsList = new List<ChartOfAccounts>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  AccountName, AccountCode, SubCategoryName, AccountTypeName FROM qryChartOfAccounts";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        ChartOfAccounts COA = FillEntity(Reader);
                        COA.pConnectionString = ConnectionString;
                        ChartOfAccountsList.Add(COA);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return ChartOfAccountsList;
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