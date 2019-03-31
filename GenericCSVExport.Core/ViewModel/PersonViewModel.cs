using GenericCSVExport.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.ViewModel
{
    public class PersonViewModel
    {

        public int IdPerson { get; set; }

        [CSVColumnName("Имя")]
        public string FirstName { get; set; }

        [CSVColumnName("Фамилия")]
        public string LastName { get; set; }

        [CSVColumnName("Отдел")]
        public string DepartmentName { get; set; }

        [CSVColumnName("Бюро")]
        public string BureauName { get; set; }
    }
}
