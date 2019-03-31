using GenericCSVExport.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.Model
{
    public class Person
    {
        public Person(int idPerson, string firstName, string lastName, int idDep, int idBureau)
        {
            IdPerson = idPerson;
            FirstName = firstName;
            LastName = lastName;
            IdDepartment = idDep;
            IdBureau = idBureau;
        }

        [CSVColumnName("IdPerson")]
        public int IdPerson { get; }


        [CSVColumnName("Имя")]
        public string FirstName { get; }


        [CSVColumnName("Фамилия")]
        public string LastName { get; }


        [CSVColumnName("Id отдела/цеха")]
        public int IdDepartment { get; }


        [CSVColumnName("Id бюро")]
        public int IdBureau { get; }
    }
}
