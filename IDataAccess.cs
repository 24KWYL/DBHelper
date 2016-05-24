using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.Common;

namespace DBHelper
{
   public interface IDataAccess
    {
        int ExecuteNonQuery(CommandType cmdType, string cmdText);
        int ExecuteNonQuery(string cmdText);
        int ExecuteNonQuery(CommandType cmdType, string cmdText, params QueryParameter[] commandParameters);
        int ExecuteNonQuery(string cmdText, params QueryParameter[] commandParameters);
        DataTable GetTable(string cmdText, params QueryParameter[] para);//返回查询结果表格
        DataTable GetTable(string cmdText);//返回查询结果表格
        DataSet GetDataSet( string cmdText, string TableName);
        DataSet GetDataSet(string cmdText);
        DbDataReader ExecuteReader(string cmdText);
        int UpdateBatchCommand(List<string> commandStringList);
       
    }
}
