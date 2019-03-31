using GenericCSVExport.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
    }
}
