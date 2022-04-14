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
    public class SubCategoryNode : ObjectBase
    {

        #region PrivateVariables
        private Int32 pSubCategoryId;
        private String pSubCategoryName;
        private Int32 pParentId;
        private String pNodeTag;
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
        public SubCategoryNode()
        {
        }

        public SubCategoryNode(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion      

        #region Read Entity

        public static SubCategoryNode FillEntity(OleDbDataReader Reader)
        {
            SubCategoryNode SCH = new SubCategoryNode();
            SCH.pSubCategoryId = Convert.ToInt32(Reader["SubCategoryId"]);
            SCH.pSubCategoryName = Reader["SubCategoryName"].ToString();
            SCH.pParentId = Convert.ToInt32(Reader["ParentId"]);
            SCH.pNodeTag = Reader["NodeTag"].ToString();
            return SCH;
        }

        public static SubCategoryNode GetEntity(int subcategoryid, string ConnectionString)
        {
            SubCategoryNode SCH = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                SCH = SubCategoryNode.GetEntity(subcategoryid, Connection);
                SCH.pConnectionString = ConnectionString;
                Connection.Close();
            }
            return SCH;
        }

        public static SubCategoryNode GetEntity(int subcategoryid, OleDbConnection Connection)
        {
            SubCategoryNode SCH = null;
            string sqlSelect = "SELECT SubCategoryId, SubCategoryName, ParentId FROM tblSubCategory WHERE SubCategoryId=" + subcategoryid + "";
            using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
            {
                OleDbDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    SCH = FillEntity(Reader);
                }
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
            }
            return SCH;
        }

        public static List<SubCategoryNode> GetEntityList(string ConnectionString)
        {
            List<SubCategoryNode> SubCategoryNodeList = new List<SubCategoryNode>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  SubCategoryId, SubCategoryName, ParentId,NodeTag FROM tblSubCategory WHERE IsDeleted=false ORDER BY SubCategoryId ASC";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        SubCategoryNode SCH = FillEntity(Reader);
                        SCH.pConnectionString = ConnectionString;
                        SubCategoryNodeList.Add(SCH);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return SubCategoryNodeList;
        }

        public static List<SubCategoryNode> GetComboList(string ConnectionString)
        {
            List<SubCategoryNode> SubCategoryNodeList = new List<SubCategoryNode>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  SubCategoryId, SubCategoryName, ParentId,NodeTag FROM tblSubCategory WHERE IsDeleted=false ORDER BY SubCategoryName ASC";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        SubCategoryNode SCH = FillEntity(Reader);
                        SCH.pConnectionString = ConnectionString;
                        SubCategoryNodeList.Add(SCH);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return SubCategoryNodeList;
        }

        public static DataTable GetEntityTable(string ConnectionString)
        {
            DataTable SubCategoryNodeTable = new DataTable();
            string sqlSelect = "SELECT  SubCategoryId, SubCategoryName, ParentId FROM tblSubCategory ORDER BY ---";
            using (OleDbDataAdapter daData = new OleDbDataAdapter(sqlSelect, ConnectionString))
            {
                daData.Fill(SubCategoryNodeTable);
            }
            return SubCategoryNodeTable;
        }

        #endregion

        #region Delete Entity
        public static void DeleteEntity(SubCategoryNode SCH)
        {
            OleDbConnection Connection = new OleDbConnection(SCH.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                Access2003SqlCommander sqlFunction = new Access2003SqlCommander(cmdCommand);
                string sqlDelete = "DELETE SubCategoryId, SubCategoryName, ParentId FROM tblSubCategory WHERE SubCategoryId=" + SCH.pSubCategoryId + "";
                sqlFunction.DeleteRecord(sqlDelete);
                //NB- if this entity is Stock 'DecreaseType', nothnig needed. Otherwise multiply by -1 
                // RawItem.UpdateCurrentBalance(SCH.pRawItemId, SCH.pQuantityOriginal * -1, Connection, transaction);
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