using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DBHelper
{
    public class QueryParameter
    {
       public QueryParameter(string name, object value)
       {
           
           this._name = name;
           this._value = value;
       }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private object _value;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

 
        private ParameterDirection _direction = ParameterDirection.Input;

        public ParameterDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
    }
}
