using GenericCSVExport.Common.Export;
using GenericCSVExport.Common.Globals;
using GenericCSVExport.Core;
using GenericCSVExport.Core.Attributes;
using GenericCSVExport.Core.DTO.CommonDTO;
using GenericCSVExport.Core.Export;
using GenericCSVExport.Core.Model;
using GenericCSVExport.Core.Services;
using GenericCSVExport.Core.ViewModel;
using GenericCSVExport.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork _unitOfWork;
        private ICSVExport _csvExport;

        public DepartmentService(IUnitOfWork unitOfWork, ICSVExport csvExport)
        {
            _unitOfWork = unitOfWork;
            _csvExport = csvExport;
        }

        public IEnumerable<DepartmentViewModel> GetDepartments()
        {
            var deps = _unitOfWork.Departments.GetDepartments()
                .Select(d => new DepartmentViewModel
                {
                    IdDepartment = d.IdDepartment,
                    Bureaus = d.Bureaus,
                    DepartmentName = d.Name
                });
            return deps;
        }

        public FileDTO ExportDepartmentsToCSV()
        {
            var deps = _unitOfWork.Departments.GetDepartments()
                .Select(d => new {
                    IdDepartment = d.IdDepartment,
                    DepartmentName = d.Name,
                    Bureaus = string.Join(", "
                                           , d.Bureaus.Select(b => b.Name))
                });

            PropertyInfo[] properties = typeof(Department).GetProperties();
            var columnNames = AttributeReader.GetCustomAttributes<Department>(properties);

            var dto = new FileDTO()
            {
                FileName = $"Departments {DateTime.Now}.csv",
                MediaTypeHeaderValue = Globals.MEDIA_TYPE_HEADER_VALUE,                
                Content = _csvExport.WriteCSV(deps, columnNames)
            };

            return dto;
        }
    }
}
