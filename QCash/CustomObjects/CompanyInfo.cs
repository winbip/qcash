using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;

namespace CustomObjects
{
    public class CompanyInfo : ObjectBase
    {

        #region PrivateVariables
        private int pCompanyId;
        private string pCompanyName;
        private string pAddressLineOne;
        private string pAddressLineTwo;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public int CompanyId
        {
            get { return pCompanyId; }
            set
            {
                if (!value.Equals(pCompanyId))
                {
                    pCompanyId = value;
                    PropertyHasChanged("CompanyId");
                }
            }
        }

        public string CompanyName
        {
            get { return pCompanyName; }
            set
            {
                if (!value.Equals(pCompanyName))
                {
                    pCompanyName = value;
                    PropertyHasChanged("CompanyName");
                }
            }
        }

        public string AddressLineOne
        {
            get { return pAddressLineOne; }
            set
            {
                if (!value.Equals(pAddressLineOne))
                {
                    pAddressLineOne = value;
                    PropertyHasChanged("AddressLineOne");
                }
            }
        }

        public string AddressLineTwo
        {
            get { return pAddressLineTwo; }
            set
            {
                if (!value.Equals(pAddressLineTwo))
                {
                    pAddressLineTwo = value;
                    PropertyHasChanged("AddressLineTwo");
                }
            }
        }

        #endregion

        #region Constructors
        public CompanyInfo()
        {
        }

        public CompanyInfo(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region PrivateMethods

        private static CompanyInfo CreateEntity(CompanyInfo companyinfo)
        {
            companyinfo.CompanyId = 1;
            OleDbConnection Connection = new OleDbConnection(companyinfo.pConnectionString);
            OleDbCommand cmdInsert = new OleDbCommand("INSERT INTO tblCompanyInfo(CompanyId, CompanyName, AddressLineOne, AddressLineTwo) VALUES(" + companyinfo.pCompanyId + ",'" + companyinfo.pCompanyName + "','" + companyinfo.pAddressLineOne + "','" + companyinfo.pAddressLineTwo + "' )", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdInsert.Transaction = trans;
                cmdInsert.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                companyinfo.MarkOld();
                return companyinfo;
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

        private static CompanyInfo UpdateEntity(CompanyInfo companyinfo)
        {
            OleDbConnection Connection = new OleDbConnection(companyinfo.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblCompanyInfo SET CompanyName='" + companyinfo.pCompanyName + "', AddressLineOne='" + companyinfo.pAddressLineOne + "', AddressLineTwo='" + companyinfo.pAddressLineTwo + "'  WHERE CompanyId=" + companyinfo.pCompanyId + "", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;
                cmdUpdate.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                companyinfo.MarkClean();
                return companyinfo;
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

        #region PublicMethods

        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        public static CompanyInfo SaveEntity(CompanyInfo companyinfo)
        {
            if (companyinfo.IsNew)
            {
                return CompanyInfo.CreateEntity(companyinfo);
            }
            else
            {
                return CompanyInfo.UpdateEntity(companyinfo);
            }
        }

        public static CompanyInfo FillEntity(OleDbDataReader Reader)
        {
            CompanyInfo companyinfo = new CompanyInfo();
            companyinfo.CompanyId = (int)Reader["CompanyId"];
            companyinfo.CompanyName = Reader["CompanyName"].ToString();
            companyinfo.AddressLineOne = Reader["AddressLineOne"].ToString();
            companyinfo.AddressLineTwo = Reader["AddressLineTwo"].ToString();
            companyinfo.MarkOld();
            return companyinfo;
        }

        public static CompanyInfo GetEntity(int CompanyId, string ConnectionString)
        {
            CompanyInfo companyinfo = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT CompanyId, CompanyName, AddressLineOne, AddressLineTwo FROM tblCompanyInfo WHERE CompanyId=" + CompanyId + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        companyinfo = FillEntity(Reader);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return companyinfo;
        }

        public static List<CompanyInfo> GetEntityList(string ConnectionString)
        {
            List<CompanyInfo> CompanyInfoList = new List<CompanyInfo>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  CompanyId, CompanyName, AddressLineOne, AddressLineTwo FROM tblCompanyInfo ORDER BY ---";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        CompanyInfo companyinfo = FillEntity(Reader);
                        CompanyInfoList.Add(companyinfo);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return CompanyInfoList;
        }

        public void DeleteEntity()
        {
            using (OleDbConnection Connection = new OleDbConnection(pConnectionString))
            {
                Connection.Open();
                string sqlDelete = "DELETE CompanyId, CompanyName, AddressLineOne, AddressLineTwo FROM tblCompanyInfo WHERE CompanyId=" + this.pCompanyId + "";
                OleDbCommand cmdDelete = new OleDbCommand(sqlDelete, Connection);
                Connection.Close();
            }
        }

        public override string ToString()
        {
            return ".......";
        }

        #endregion
    }
}
