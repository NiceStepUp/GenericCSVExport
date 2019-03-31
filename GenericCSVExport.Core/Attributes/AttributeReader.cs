using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.Attributes
{
    public class AttributeReader
    {
        /// <summary>
        /// Считывание значений атрибута свойств у CSVColumnName в классе Person
        /// Reading property attributes of CSVColumnName of Person class 
        /// </summary>
        /// <typeparam name="T">Тип класса для считывания атрибутов свойств</typeparam>
        /// <param name="properties">Свойства класса для считывания атрибута CSVColumnNameAttribute</param>
        /// <returns></returns>
        public static IEnumerable<string> GetCustomAttributes<T>(PropertyInfo[] properties)
        {
            var customAttributeNames = new List<string>();
            foreach (var prop in typeof(T).GetProperties())
            {
                var attrs = (CSVColumnNameAttribute[])prop.GetCustomAttributes
                    (typeof(CSVColumnNameAttribute), false);
                foreach (var attr in attrs)
                {
                    customAttributeNames.Add(attr.Name);
                }
            }
            return customAttributeNames;
        }
    }
}
