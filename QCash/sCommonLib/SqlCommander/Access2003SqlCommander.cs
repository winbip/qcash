using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace sCommonLib.SqlCommander
{
    public class Access2003SqlCommander : IDisposable
    {

        #region Private Variables
        private OleDbCommand cmdCommand;
        #endregion

        #region Constructors
        public Access2003SqlCommander(OleDbCommand CommandObject)
        {
            cmdCommand = CommandObject;
        }
        #endregion

        #region Search

        /// <summary>
        /// It will search for a single string value,
        /// by using "WHERE..." or "GROUP BY... HAVING.." clause,
        /// returns true if found. Otherwise return false.
        /// i.e. Search whether a LogInName already exists.
        /// </summary>
        /// <param name="SqlString"></param>
        /// <returns>Return true if found, otherwise return false</returns>
        public bool SearchString(string SqlQueryString)
        {
            cmdCommand.CommandText = SqlQueryString;
            object SearchResult = cmdCommand.ExecuteScalar();
            if (SearchResult == null)
            {
                return false; //Not found
            }
            else
            {
                return true; //Found
            }
        }

        /// <summary>
        /// It will search by using single/multiple criteria (any data type),
        /// by "WHERE..." or "GROUP BY... HAVING.." clause,
        /// and return single value (Object type) if found,
        /// ohterwise return null
        /// </summary>
        /// <param name="SqlQueryString"></param>
        /// <returns></returns>
        public Object Search(string SqlQueryString)
        {
            cmdCommand.CommandText = SqlQueryString;
            object SearchResult = cmdCommand.ExecuteScalar();
            return SearchResult;
        }

        public bool SearchRecordsBasedOnAggregatedCount(string SqlQueryString)
        {
            cmdCommand.CommandText = SqlQueryString;
            object SearchResult = cmdCommand.ExecuteScalar();
            if (SearchResult == null)
            {
                return false; //Not found
            }
            else
            {
                return true; //Found
            }
        }

        public bool SearchRecordsBasedOnNonAggregatedCount(string SqlQueryString)
        {
            cmdCommand.CommandText = SqlQueryString;
            Object SearchResult = cmdCommand.ExecuteScalar();
            if (Convert.ToInt32(SearchResult) == 0)
            {
                return false; //Not found
            }
            else
            {
                return true; //Found
            }
        }

        #endregion

        #region Insert, Update, Delete
        /// <summary>
        /// This method will perform "ExecuteNonQuery" with the supplied SQL string.
        /// Command object already supplied while instantiated this object.
        /// </summary>
        /// <param name="SqlString">string parameter</param>
        public void InsertRecord(string SqlString)
        {
            cmdCommand.CommandText = SqlString;
            cmdCommand.ExecuteNonQuery();
        }

        public void UpdateRecord(string SqlString)
        {
            cmdCommand.CommandText = SqlString;
            cmdCommand.ExecuteNonQuery();
        }

        public void DeleteRecord(string SqlString)
        {
            cmdCommand.CommandText = SqlString;
            cmdCommand.ExecuteNonQuery();
        }

        #endregion

        #region Primary Key
        
        public Int32 CreateNewId(string SqlQueryString)
        {
            try
            {
                cmdCommand.CommandText = SqlQueryString;

                object objLastId = cmdCommand.ExecuteScalar();

                //If database does not have any row, ExecuteScalar() will return DBNull.Value.
                if (objLastId == DBNull.Value || objLastId == null)
                {
                    //Set Id=1
                    return 1;
                }
                else
                {
                    //IncreamentId by 1
                    Int32 intLastId = (Int32)objLastId;
                    return ++intLastId;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        /// <summary>
        /// It will create new Id and then return.
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public int CreateNewId(string TableName, string ColumnName)
        {
            string sqlLastId = "select Max(" + ColumnName + ") as LastId from " + TableName + "";
            cmdCommand.CommandText = sqlLastId;
            object objLastId = cmdCommand.ExecuteScalar();

            //If database does not have any row, ExecuteScalar() will return DBNull.Value.
            if (objLastId == DBNull.Value)
            {
                //Set ID=1
                return 1;
            }
            else
            {
                //IncreamentId by 1
                int intLastId = (int)objLastId;
                return ++intLastId;
            }

        }

        public static int CreateNewId(string TableName, string ColumnName, string ConnectionString)
        {
            try
            {
                using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
                {
                    string sqlLastId = "select Max(" + ColumnName + ") as LastId from " + TableName + "";
                    OleDbCommand cmdLastId = new OleDbCommand(sqlLastId, Connection);
                    Connection.Open();
                    object objLastId = cmdLastId.ExecuteScalar();
                    Connection.Close();

                    //If database does not have any row, ExecuteScalar() will return DBNull.Value.
                    if (objLastId == DBNull.Value)
                    {
                        //Set Id=1
                        return 1;
                    }
                    else
                    {
                        //IncreamentId by 1
                        int intLastId = (int)objLastId;
                        return ++intLastId;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public static int CreateNewId(string TableName, string ColumnName, OleDbConnection Connection, OleDbTransaction transaction)
        {
            try
            {
                string sqlLastId = "select Max(" + ColumnName + ") as LastId from " + TableName + "";
                OleDbCommand cmdLastId = new OleDbCommand(sqlLastId, Connection);
                cmdLastId.Transaction = transaction;
                object objLastId = cmdLastId.ExecuteScalar();

                //If database does not have any row, ExecuteScalar() will return DBNull.Value.
                if (objLastId == DBNull.Value)
                {
                    //Set Id=1
                    return 1;
                }
                else
                {
                    //IncreamentId by 1
                    int intLastId = (int)objLastId;
                    return ++intLastId;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }



        /// <summary>
        /// This method will perform "ExecuteScalar" with the supplied SQL string.
        /// Command object already supplied while instantiated this object.
        /// </summary>
        /// <param name="SqlString">Sql String</param>
        /// <returns>int value</returns>
        public Int32 GetLastPrimaryKeyValue(string SqlString)
        {
            cmdCommand.CommandText = SqlString;
            object objLastValue = cmdCommand.ExecuteScalar();
            return (Int32)objLastValue;
        }
        #endregion

        #region Return Value (Int, Decimal, etc)
        /// <summary>
        /// It will search and return Decimal Type value.
        /// </summary>
        /// <param name="SqlString"></param>
        /// <returns></returns>
        public Decimal GetDecimalValue(string SqlString)
        {
            cmdCommand.CommandText = SqlString;
            object objLastValue = cmdCommand.ExecuteScalar();
            return Convert.ToDecimal(objLastValue);
        }
        #endregion

        #region iDisposable_mthods

        private bool disposed = false;

        public void Dispose()
        {
            // Call our helper method.
            //Specifying "true" signifies that
            // the object user triggered the cleanup.
            CleanUp(true);

            // Now suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            // Be sure we have not already been disposed!
            if (!this.disposed)
            {
                // If disposing equals true, dispose all
                // managed resources.
                if (disposing)
                {
                    // Dispose managed resources.
                }
                // Clean up unmanaged resources here.
            }
            disposed = true;
        }

        ~Access2003SqlCommander()
        {
            CleanUp(false);
        }

        #endregion
    }
}
