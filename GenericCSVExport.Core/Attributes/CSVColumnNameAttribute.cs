using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class CSVColumnNameAttribute : Attribute
    {
        public CSVColumnNameAttribute(string name)
        {
            Name = name;
        }


        public string Name { get; }
    }
}
