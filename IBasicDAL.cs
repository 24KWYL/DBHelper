using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DBHelper
{
   public interface IBasicDAL<T>
    {
       int Save(T t);
       int Delete(T t);
       DataTable FindAll(T t);
       DataTable FindByEqual(T t);
       DataTable FindByBetween(T t);

    }
}
