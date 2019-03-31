using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.Export
{
    public interface ICSVExport
    {
        byte[] WriteCSV<T>(IEnumerable<T> objectlist, IEnumerable<string> columnNames = null);
    }
}
