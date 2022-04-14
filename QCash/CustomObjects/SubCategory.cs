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
    public class SubCategory : ObjectBase
    {

        #region PrivateVariables
        private Int32 pSubCategoryId; // this value is used to hold "TreeNode.Name" property
        private String pSubCategoryName; //this value is used to hold "TreeNode.Text" property
        private Int32 pParentId;
        private Boolean pIsDeleted; //default value is "false" has been set in constructor
        private Boolean pIsSystemDefined;  //default value is "false" has been set in constructor
        private String pNodeTag; // this value is used to hold "TreeNode.Tag" property.  default value is "UserDefinedSubCategoryType" has been set in constructor
        private string pConnectionString;
        #endregion

        #region PublicProperties
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

        public Int32 ParentId
        {
            get { return pParentId; }
            set
            {
                if (!value.Equals(pParentId))
                {
                    pParentId = value;
                    PropertyHasChanged("ParentId");
                }
            }
        }

        public Boolean IsSubCategoryDeleted
        {
            get { return pIsDeleted; }
            set
            {
                if (!value.Equals(pIsDeleted))
                {
                    pIsDeleted = value;
                    PropertyHasChanged("IsSubCategoryDeleted");
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
        public SubCategory()
        {
            this.pIsDeleted = false;
            this.pIsSystemDefined = false;
            this.pNodeTag = "UserDefinedSubCategoryType";
        }

        public SubCategory(string ConnectionString)
        {
            pConnectionString = ConnectionString;
            this.pIsDeleted = false;
            this.pIsSystemDefined = false;
            this.pNodeTag = "UserDefinedSubCategoryType";
        }
        #endregion

        #region Save Entity
        public static SubCategory SaveEntity(SubCategory SC)
        {
            if (SC.IsNew)
            {
                return SubCategory.CreateEntity(SC);
            }
            else
            {
                return SubCategory.UpdateEntity(SC);
            }
        }

        private static SubCategory CreateEntity(SubCategory SC)
        {
            OleDbConnection Connection = new OleDbConnection(SC.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {

                if (String.IsNullOrEmpty(SC.pSubCategoryName))
                {
                    throw new ExceptionWithControl("", "", "Enter Sub-Category Name.", "txtSubCategoryName");
                }

                if (SC.pSubCategoryName.Length>50)
                {
                    throw new ExceptionWithControl("", "", "Maximum lenght is 50 characters.", "txtSubCategoryName");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);

                if (sqlFunction.SearchString("Select SubCategoryName from tblSubCategory Where SubCategoryName='"+ SC.pSubCategoryName +"' AND ParentId="+ SC.pParentId +" AND IsDeleted=false"))
                {
                     throw new ExceptionWithControl("", "", "This Sub Category already exists.", "txtSubCategoryName");
                }


                SC.pSubCategoryId = sqlFunction.CreateNewId("tblSubCategory", "SubCategoryId");
                sqlFunction.InsertRecord("INSERT INTO tblSubCategory(SubCategoryId, SubCategoryName, ParentId, IsDeleted, IsSystemDefined, NodeTag) VALUES(" + SC.pSubCategoryId + ",'" + SC.pSubCategoryName + "'," + SC.pParentId + "," + SC.pIsDeleted + "," + SC.pIsSystemDefined + ",'" + SC.pNodeTag + "' )");

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                SC.MarkOld();
                return SC;
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

        private static SubCategory UpdateEntity(SubCategory SC)
        {
            OleDbConnection Connection = new OleDbConnection(SC.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                sqlFunction.UpdateRecord("UPDATE tblSubCategory SET SubCategoryName='" + SC.pSubCategoryName + "'  WHERE SubCategoryId=" + SC.pSubCategoryId + "");

                transaction.Commit();
                Connection.Close();
                sqlFunction.Dispose();
                SC.MarkClean();
                return SC;
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

        public static SubCategory FillEntity(OleDbDataReader Reader)
        {
            SubCategory SC = new SubCategory();
            SC.pSubCategoryId = Convert.ToInt32(Reader["SubCategoryId"]);
            SC.pSubCategoryName = Reader["SubCategoryName"].ToString();
            SC.pParentId = Convert.ToInt32(Reader["ParentId"]);
            SC.pIsDeleted = Convert.ToBoolean(Reader["IsDeleted"]);
            SC.pIsSystemDefined = Convert.ToBoolean(Reader["IsSystemDefined"]);
            SC.pNodeTag = Reader["NodeTag"].ToString();
            SC.MarkOld();
            return SC;
        }

        public static SubCategory GetEntity(int subcategoryid, string ConnectionString)
        {
            SubCategory SC = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                SC = SubCategory.GetEntity(subcategoryid, Connection);
                SC.pConnectionString = ConnectionString;
                Connection.Close();
            }
            return SC;
        }

        public static SubCategory GetEntity(int subcategoryid, OleDbConnection Connection)
        {
            SubCategory SC = null;
            string sqlSelect = "SELECT SubCategoryId, SubCategoryName, ParentId, IsDeleted, IsSystemDefined, NodeTag FROM tblSubCategory WHERE SubCategoryId=" + subcategoryid + "";
            using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
            {
                OleDbDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    SC = FillEntity(Reader);
                }
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
            }
            return SC;
        }

        public static List<SubCategory> GetEntityList(string ConnectionString)
        {
            List<SubCategory> SubCategoryList = new List<SubCategory>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  SubCategoryId, SubCategoryName, ParentId, IsDeleted, IsSystemDefined, NodeTag FROM tblSubCategory ORDER BY ";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        SubCategory SC = FillEntity(Reader);
                        SC.pConnectionString = ConnectionString;
                        SubCategoryList.Add(SC);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return SubCategoryList;
        }

        public static List<SubCategory> GetComboList(string ConnectionString)
        {
            List<SubCategory> SubCategoryList = new List<SubCategory>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  SubCategoryId, SubCategoryName, ParentId, IsDeleted, IsSystemDefined, NodeTag FROM tblSubCategory ORDER BY ";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        SubCategory SC = FillEntity(Reader);
                        SC.pConnectionString = ConnectionString;
                        SubCategoryList.Add(SC);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return SubCategoryList;
        }

        public static DataTable GetEntityTable(string ConnectionString)
        {
            DataTable SubCategoryTable = new DataTable();
            string sqlSelect = "SELECT  SubCategoryId, SubCategoryName, ParentId, IsDeleted, IsSystemDefined, NodeTag FROM tblSubCategory ORDER BY ---";
            using (OleDbDataAdapter daData = new OleDbDataAdapter(sqlSelect, ConnectionString))
            {
                daData.Fill(SubCategoryTable);
            }
            return SubCategoryTable;
        }

        #endregion

        #region Delete Entity
        public static void DeleteEntity(SubCategory SC)
        {
            OleDbConnection Connection = new OleDbConnection(SC.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);



                if (sqlFunction.SearchRecordsBasedOnNonAggregatedCount("SELECT Count(SubCategoryId) AS TotalCount FROM tblSubCategory WHERE ParentId=" + SC.pSubCategoryId + " AND IsDeleted=False"))
                {
                    throw new ExceptionWithControl("", "", "It contains child categories. You can not delete it.", "txtSubCategoryName");
                }

                if (sqlFunction.SearchRecordsBasedOnNonAggregatedCount("SELECT Count(AccountId) AS TotalCount FROM tblAccount WHERE SubCategoryId=" + SC.pSubCategoryId + " AND IsDeleted=False"))
                {
                    throw new ExceptionWithControl("", "", "It contains account heads. You can not delete it.", "txtSubCategoryName");
                }

                SC.pIsDeleted = true;
                string sqlDelete = "UPDATE tblSubCategory SET IsDeleted=" + SC.pIsDeleted + "  WHERE SubCategoryId=" + SC.pSubCategoryId + "";

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

        #endregion

    }
}