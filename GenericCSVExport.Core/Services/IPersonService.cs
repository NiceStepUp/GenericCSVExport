using GenericCSVExport.Core.DTO.CommonDTO;
using GenericCSVExport.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.Services
{
    public interface IPersonService
    {
        IEnumerable<PersonViewModel> GetPersons();

        FileDTO ExportPersonsToCSV();
    }
}
