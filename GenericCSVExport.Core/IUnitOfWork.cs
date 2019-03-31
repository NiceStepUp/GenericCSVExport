using GenericCSVExport.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }
        IDepartmentRepository Departments { get; }
    }
}
