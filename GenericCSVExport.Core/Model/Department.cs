using GenericCSVExport.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.Model
{
    public class Department
    {
        public Department(int idDepartment, string name, IEnumerable<Bureau> bureaus)
        {
            IdDepartment = idDepartment;
            Name = name;
            Bureaus = new ReadOnlyCollection<Bureau>(bureaus.ToList());
        }


        [CSVColumnName("IdDepartment")]
        public int IdDepartment { get; }


        [CSVColumnName("Отдел")]
        public string Name { get; }


        [CSVColumnName("Бюро")]
        public IReadOnlyCollection<Bureau> Bureaus { get; }
    }
}
