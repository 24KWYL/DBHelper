using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
delegate string SelectWithCondition(Type type,string propertyname,object obj);



namespace DBHelper
{
   public class BasicDALImpl<T>:IBasicDAL<T>
    {
       protected object entityClass;
       protected string _tableName;
       protected string _connStr;

       public string ConnStr
       {
           get { return _connStr; }
           set { _connStr = value; }
       }
       protected EnumDatabaseType _dataBaseType;

       public EnumDatabaseType DataBaseType
       {
           get { return _dataBaseType; }
           set { _dataBaseType = value; }
       }

       public string TableName
       {
           get { return _tableName; }          
       }
       public BasicDALImpl()
       {          
        
         _tableName = typeof(T).Name;
         _connStr=ConfigurationManager.ConnectionStrings["CommonStr"].ToString();
         _dataBaseType = EnumDatabaseType.Oracle;

           
       }
       //insert into tbname(field1,field2,...) values(?,?) 
        public int Save(T t)
        {            
            PropertyInfo[] properties = typeof(T).GetProperties();
            //QueryParameter[] parameters = new QueryParameter[properties.Length];
            List<QueryParameter> parameterList = new List<QueryParameter>();
            
            StringBuilder fieldSB = new StringBuilder();
            StringBuilder valueSB = new StringBuilder();
            StringBuilder SqlSB = new StringBuilder();
            for (int i = 0; i < properties.Length; i++)
            {
                
                //parameters[i]=new QueryParameter(properties[i].Name,properties[i].GetValue(t,null));
                QueryParameter param = new QueryParameter(properties[i].Name, properties[i].GetValue(t, null));
                //在此判断值是否为空，为空则跳过
                if (IsValueBlank(param.Value))
                {
                    continue;
                }
                fieldSB.Append(properties[i].Name + ",");
                valueSB.Append("?,");
                parameterList.Add(param);
            }
            fieldSB.Remove(fieldSB.Length - 1, 1);
            valueSB.Remove(valueSB.Length-1,1);
            SqlSB.Append("insert into ");
            SqlSB.Append(_tableName);
            SqlSB.Append("(");
            SqlSB.Append(fieldSB);
            SqlSB.Append(") values(");
            SqlSB.Append(valueSB);
            SqlSB.Append(")");

            IDataAccess data = DataAccessFactory.CreateDataAccess(_dataBaseType, _connStr);
            return data.ExecuteNonQuery(SqlSB.ToString(), parameterList.ToArray());          
    
        }
        public int Update(T t,T tWhere)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            PropertyInfo[] propertie = typeof(T).GetProperties();
           // QueryParameter[] parameters = new QueryParameter[properties.Length];
            List<QueryParameter> parameterList = new List<QueryParameter>();
            //string WhereClause = "where ";
            //for (int i = 0; i < propertie.Length; i++)
            //{
            //    if (!IsValueBlank(propertie[i].GetValue(tWhere,null)))
            //    {
            //        string conditionStr = propertie[i].Name + "=" + propertie[i].GetValue(tWhere, null) + " and ";
            //        WhereClause = WhereClause + conditionStr;
            //        parameterList.Add(propertie[i]);
            //    }
            //}
            //   string updatefieldSB = WhereClause.Substring(0,WhereClause.Length-4);
            //StringBuilder fieldSB = new StringBuilder();
            //StringBuilder valueSB = new StringBuilder();
            StringBuilder SqlSB = new StringBuilder();
            SqlSB.Append("update ");
            SqlSB.Append(_tableName);
            SqlSB.Append(" set ");
            for (int i = 0; i < properties.Length; i++)
            {

                //parameters[i]=new QueryParameter(properties[i].Name,properties[i].GetValue(t,null));
                QueryParameter param = new QueryParameter(properties[i].Name, properties[i].GetValue(t, null));
                //在此判断值是否为空，为空则跳过
                if (IsValueBlank(param.Value))
                {
                    continue;
                }
                SqlSB.Append(properties[i].Name + "=");
                SqlSB.Append("?,");
                parameterList.Add(param);
            }
            SqlSB.Remove(SqlSB.Length-1,1);
            //fieldSB.Remove(fieldSB.Length - 1, 1);
            //valueSB.Remove(valueSB.Length - 1, 1);
            //SqlSB.Append("update ");
            //SqlSB.Append(_tableName);
            //SqlSB.Append(" set ");
            //SqlSB.Append(fieldSB);
            //SqlSB.Append(") values(");
            //SqlSB.Append(valueSB);
            //SqlSB.Append(")");
            string WhereClause = " where ";
            for (int i = 0; i < propertie.Length; i++)
            {
                QueryParameter param = new QueryParameter(properties[i].Name, properties[i].GetValue(tWhere, null));
                if (!IsValueBlank(param.Value))
                {
                    string conditionStr = propertie[i].Name + "= ? and ";
                    WhereClause = WhereClause + conditionStr;
                    parameterList.Add(param);
                }
            }
            string updatefieldSB = WhereClause.Substring(0, WhereClause.Length - 4);
            SqlSB.Append(updatefieldSB);

            IDataAccess data = DataAccessFactory.CreateDataAccess(_dataBaseType, _connStr);
            return data.ExecuteNonQuery(SqlSB.ToString(), parameterList.ToArray());          
    
        }
        public int Delete(T t)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            QueryParameter[] parameters = new QueryParameter[properties.Length];
            List<QueryParameter> qlist = new List<QueryParameter>();
            StringBuilder WhereClause = new StringBuilder();
            StringBuilder SqlSB = new StringBuilder();
            for (int i = 0; i < properties.Length; i++)
            {
               parameters[i] = new QueryParameter(properties[i].Name, properties[i].GetValue(t, null));
                //在此判断值是否为空，为空则跳过
                if (IsValueBlank(parameters[i].Value))
                {
                    continue;
                }
                qlist.Add(new QueryParameter(properties[i].Name, properties[i].GetValue(t, null)));
                WhereClause.Append(" and " + properties[i].Name + "=?");
            }
            SqlSB.Append("delete from ");
            SqlSB.Append(_tableName);
            SqlSB.Append(" where 1=1");
            SqlSB.Append(WhereClause);

            IDataAccess data = DataAccessFactory.CreateDataAccess(_dataBaseType, _connStr);
            QueryParameter[] Listparameters = (QueryParameter[])qlist.ToArray();
            return data.ExecuteNonQuery(SqlSB.ToString(), Listparameters);          
            throw new NotImplementedException();
        }
        private Boolean IsValueBlank(object value)
        {
            if (null == value)
            {
                return true;
            }
            else if (value.GetType() == typeof(string))
            {
                return false;
            }
            else if (value.GetType() == typeof(DateTime) && Convert.ToDateTime(value).Year == 1)
            {
                return true;
            }
            else if (value.GetType() == typeof(Double) && Convert.ToDouble(value) < 0)
            {
                return true;
            }
            else if (value.GetType() == typeof(float) && float.Parse(value.ToString()) < 0)
            {
                return true;
            }
            return false;
        }

        public System.Data.DataTable FindAll(T t)
        {
            return BaseFind(t,FindHaveNoCondition);
        }
        public System.Data.DataTable FindListbyField(string item,T t)
        {
            List<QueryParameter> qlist = new List<QueryParameter>();
            string tableName=typeof(T).Name;
            string SqlSB = "select distinct " + item + " from " + tableName;
            QueryParameter[] parameters = (QueryParameter[])qlist.ToArray();
            IDataAccess data = DataAccessFactory.CreateDataAccess(_dataBaseType, _connStr);
            return data.GetTable(SqlSB.ToString(), parameters);
        }
        //public System.Data.DataTable FindbyField(string field,string item, T t)
        //{
        //    List<QueryParameter> qlist = new List<QueryParameter>();
        //    string tableName = typeof(T).Name;
        //    string SqlSB = "select distinct " + item + " from " + tableName+" where jh='"+field+"'";
        //    QueryParameter[] parameters = (QueryParameter[])qlist.ToArray();
        //    IDataAccess data = DataAccessFactory.CreateDataAccess(_dataBaseType, _connStr);
        //    return data.GetTable(SqlSB.ToString(), parameters);
        //}
       /// <summary>
       /// 定义通用查询
       /// </summary>
       /// <param name="t"></param>
       /// <param name="getConditionStr"></param>
       /// <returns></returns>
        private System.Data.DataTable BaseFind(T t, SelectWithCondition getConditionStr)
       {
           List<QueryParameter> qlist = new List<QueryParameter>();
           string tableName = typeof(T).Name;
           PropertyInfo[] properties = typeof(T).GetProperties();
           
           StringBuilder SqlSB = new StringBuilder();
           StringBuilder fieldSB = new StringBuilder();
           String selectfieldSB = "";

           for (int i = 0; i < properties.Length; i++)
           {
               fieldSB.Append(properties[i].Name + ",");
               object obj = properties[i].GetValue(t, null);
               string conditionStr = getConditionStr(properties[i].PropertyType, properties[i].Name, obj);
               if (!String.IsNullOrWhiteSpace(conditionStr))
               {
                   qlist.Add(new QueryParameter(properties[i].Name,obj));
               }
               selectfieldSB = selectfieldSB + conditionStr;
           }

           fieldSB.Remove(fieldSB.Length - 1, 1);

           SqlSB.Append("select ");
           SqlSB.Append(fieldSB);
           SqlSB.Append(" from ");
           SqlSB.Append(tableName);
           SqlSB.Append(" where 1=1 ");
           if (!String.IsNullOrWhiteSpace(selectfieldSB))
           {
              selectfieldSB=selectfieldSB.TrimEnd(',');
               SqlSB.Append(selectfieldSB);
           }
           QueryParameter[] parameters = (QueryParameter[])qlist.ToArray();
           IDataAccess data = DataAccessFactory.CreateDataAccess(_dataBaseType, _connStr);
           return data.GetTable(SqlSB.ToString(), parameters);
            

       }
        private string FindHaveNoCondition(Type type, string propertyname, object obj)
        {
            return "";
 
        }
        private string FindHaveEqualCondition(Type type,string propertyname,object obj)
        {
            StringBuilder selectfieldSB = new StringBuilder();
            string fieldTypeStr = type.ToString().ToLower();
            
            if (fieldTypeStr.Equals("system.string"))
            {
                if (null == obj)
                {
                    return "";
                   
                }
            }
            else if (fieldTypeStr.Equals("system.datetime"))
            {
                if (Convert.ToDateTime(obj).Year==1)
                {
                    return "";

                }
            }
            else
            {
                if (obj.ToString() == "0")
                {
                    return "";

                }
                else if (Convert.ToDouble(obj) < 0.0)
                {
                    return "";
                }
            }
            selectfieldSB.Append(" and ");
            selectfieldSB.Append(propertyname);
            selectfieldSB.Append("=? ");
            return selectfieldSB.ToString();
 
        }
       //select field1,field2,... from tbName where field='value' and ...
        public System.Data.DataTable FindByEqual(T t)
        {
            return BaseFind(t, FindHaveEqualCondition); 

        }       
        public System.Data.DataTable FindByBetween(T t)
        {
            throw new NotImplementedException();
        }
    }
}
