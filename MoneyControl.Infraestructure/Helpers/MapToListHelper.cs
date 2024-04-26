using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Infraestructure.Helpers
{
    public static class MapToListHelper
    {
        public static List<T> MapToList<T>(IDataReader dataReader)
        {
            var list = new List<T>();
            var obj2 = Activator.CreateInstance<T>();
            var properties = obj2.GetType().GetProperties();
            while (dataReader.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in properties)
                {
                    if (object.Equals(dataReader[prop.Name], DBNull.Value)) continue;
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    var safeValue = Convert.ChangeType(dataReader[prop.Name], type);
                    prop.SetValue(obj, safeValue, null);
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
