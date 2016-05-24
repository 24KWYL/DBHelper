using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DBHelper
{
    #region 数据库类型
    /// <summary>
    /// Enumerate database type
    /// </summary>
    public enum EnumDatabaseType
    {
        /// <summary>
        /// Database type not defined.
        /// </summary>
        None,
        /// <summary>
        /// Database type defined as Access
        /// </summary>
        Access=0,
        /// <summary>
        /// Database type defined as OMR
        /// </summary>
        SqlServer = 1,

        /// <summary>
        /// Database type defined as Oracle
        /// </summary>
        Oracle = 2,

        /// <summary>
        /// Database type defined as DBF
        /// </summary>
        Odbc = 3,

        /// <summary>
        /// 
        /// </summary>
        Oledb = 4

    }
    #endregion

   public class DataAccessFactory
    {
  

        public static IDataAccess CreateDataAccess(EnumDatabaseType dbType,string connStr)
        {        
 
            switch (dbType)
            {
                case EnumDatabaseType.SqlServer: return new SqlServerDAL(connStr);
                case EnumDatabaseType.Oracle: return new OracleDAL(connStr);
                case EnumDatabaseType.Access: return new AccessDAL(connStr);
                default:
                    throw new Exception("不支持的类型！");
            }
        }
    }
}
