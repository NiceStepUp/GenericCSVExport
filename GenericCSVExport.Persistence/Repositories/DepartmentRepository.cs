using GenericCSVExport.Core.Model;
using GenericCSVExport.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public IEnumerable<Department> GetDepartments()
        {
            var departments = new List<Department>();
            for (int depIndex = 1; depIndex <= 10; depIndex++)
            {
                departments.Add(new Department(depIndex
                    , $"Department {depIndex}"
                    , new List<Bureau> {  new Bureau(depIndex, $"Bureau {depIndex}", depIndex)
                                        , new Bureau(depIndex + 1, $"Bureau {depIndex + 1}", depIndex + 1)
                                        , new Bureau(depIndex + 1, $"Bureau {depIndex + 2}", depIndex + 2)
                    }));
            }
            return departments;
        }
    }
}
