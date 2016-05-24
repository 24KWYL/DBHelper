using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DBHelper
{
   public class SqlServerDAL:IDataAccess
    {
        private string _connStr;
        public  SqlServerDAL(string connStr)
        {
            _connStr = connStr;
        }

        public int ExecuteNonQuery( System.Data.CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(cmdType, cmdText,null);
        }
        public int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(CommandType.Text, cmdText);
        }
        public int ExecuteNonQuery(string cmdText, params QueryParameter[] commandParameters)
        {
            return ExecuteNonQuery(CommandType.Text, cmdText,commandParameters);
        }
        public int ExecuteNonQuery(System.Data.CommandType cmdType, string cmdText, params QueryParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();              
                return val;
            }
        }

        public System.Data.DataTable GetTable(string cmdText, params QueryParameter[] para)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd,conn, null,CommandType.Text, cmdText, para);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
                
            }

        }

        public System.Data.DataTable GetTable(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                DbDataAdapter Adpt = new SqlDataAdapter(cmdText, conn);
                DataTable dt = new DataTable();
                Adpt.Fill(dt);
                return dt;
            }
        }

        public System.Data.DataSet GetDataSet(string cmdText, string TableName)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                //创建SqlDataAdapter对象以及DataSet
                DbDataAdapter Adpt = new SqlDataAdapter(cmdText, conn);
                DataSet ds = new DataSet();
                try
                {
                    //填充ds
                    Adpt.Fill(ds, TableName);
                    //返回ds
                    return ds;
                }
                catch
                {
                    //关闭连接，抛出异常
                    conn.Close();
                    throw;
                }
            }
        }
        public System.Data.DataSet GetDataSet(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                //创建SqlDataAdapter对象以及DataSet
                DbDataAdapter Adpt = new SqlDataAdapter(cmdText, conn);
                DataSet ds = new DataSet();
                try
                {
                    //填充ds
                    Adpt.Fill(ds);
                    //返回ds
                    return ds;
                }
                catch
                {
                    //关闭连接，抛出异常
                    conn.Close();
                    throw;
                }
            }
        }
        public DbDataReader ExecuteReader(string cmdText)
        {
            SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    cmd.Connection = conn;
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {

                    throw ex;

                }
          
          
        }

            /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">QueryParameters to use in the command</param>
        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, params QueryParameter[] cmdParms) {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null) {
                foreach (QueryParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        int IDataAccess.ExecuteNonQuery(CommandType cmdType, string cmdText)
        {
            throw new NotImplementedException();
        }

        int IDataAccess.ExecuteNonQuery(string cmdText)
        {
            throw new NotImplementedException();
        }

        int IDataAccess.ExecuteNonQuery(CommandType cmdType, string cmdText, params QueryParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        int IDataAccess.ExecuteNonQuery(string cmdText, params QueryParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        DataTable IDataAccess.GetTable(string cmdText, params QueryParameter[] para)
        {
            throw new NotImplementedException();
        }

        DataTable IDataAccess.GetTable(string cmdText)
        {
            throw new NotImplementedException();
        }

        DataSet IDataAccess.GetDataSet(string cmdText, string TableName)
        {
            throw new NotImplementedException();
        }

        DataSet IDataAccess.GetDataSet(string cmdText)
        {
            throw new NotImplementedException();
        }

        DbDataReader IDataAccess.ExecuteReader(string cmdText)
        {
            throw new NotImplementedException();
        }

        int IDataAccess.UpdateBatchCommand(List<string> commandStringList)
        {
            throw new NotImplementedException();
        }
    }
}
