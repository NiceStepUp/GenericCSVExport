using GenericCSVExport.Core;
using GenericCSVExport.Core.Repositories;
using GenericCSVExport.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPersonRepository Persons { get; private set; }

        public IDepartmentRepository Departments { get; private set; }


        public UnitOfWork()
        {
            Persons = new PersonRepository();
            Departments = new DepartmentRepository();
        }


        /// <summary>
        /// There will be an ORM Context which will save changes. E.g.: _context.SaveChanges();
        /// </summary>
        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
