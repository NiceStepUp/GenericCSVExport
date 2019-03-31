using GenericCSVExport.Core.Model;
using GenericCSVExport.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetPersons()
        {
            var persons = new List<Person>();
            for (int personIndex = 1; personIndex <= 10; personIndex++)
            {
                persons.Add(
                    new Person(
                      personIndex
                    , $"FirstName {personIndex}"
                    , $"LastName {personIndex}"
                    , personIndex
                    , personIndex)
                    );
            }
            return persons;
        }
    }
}
