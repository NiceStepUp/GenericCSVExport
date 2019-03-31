using GenericCSVExport.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.ViewModel
{
    public class DepartmentViewModel
    {
        public int IdDepartment { get; set; }


        public string DepartmentName { get; set; }


        public IEnumerable<Bureau> Bureaus { get; set; }
    }
}
