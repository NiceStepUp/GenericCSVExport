using GenericCSVExport.Common.Export;
using GenericCSVExport.Common.Globals;
using GenericCSVExport.Core;
using GenericCSVExport.Core.Attributes;
using GenericCSVExport.Core.DTO;
using GenericCSVExport.Core.DTO.CommonDTO;
using GenericCSVExport.Core.Export;
using GenericCSVExport.Core.Model;
using GenericCSVExport.Core.Services;
using GenericCSVExport.Core.ViewModel;
using GenericCSVExport.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Service.Services
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork _unitOfWork;
        private ICSVExport _csvExport;


        public PersonService(IUnitOfWork unitOfWork, ICSVExport csvExport)
        {
            _unitOfWork = unitOfWork;
            _csvExport = csvExport;
        }

        public FileDTO ExportPersonsToCSV()
        {
            var persons = _unitOfWork.Persons.GetPersons();
            var deps = _unitOfWork.Departments.GetDepartments();
            var personDeps = from person in persons
                             join dep in deps on person.IdDepartment equals dep.IdDepartment
                             select new 
                             {
                                   FirstName = person.FirstName
                                 , LastName = person.LastName
                                 , DepartmentName = dep.Name
                                 , BureauName = dep.Bureaus
                                                .Where(b => b.IdBureau == person.IdBureau)
                                                .FirstOrDefault().Name
                             };


            PropertyInfo[] properties = typeof(PersonViewModel).GetProperties();
            var columnNames = AttributeReader.GetCustomAttributes<PersonViewModel>(properties);

            var dto = new FileDTO()
            {
                FileName = $"Persons {DateTime.Now}.csv",
                MediaTypeHeaderValue = Globals.MEDIA_TYPE_HEADER_VALUE,
                Content = _csvExport.WriteCSV(personDeps, columnNames)
            };

            return dto;
        }


        public IEnumerable<PersonViewModel> GetPersons()
        {
            var persons = _unitOfWork.Persons.GetPersons()
                .Select(p => new PersonViewModel
                {
                    IdPerson = p.IdPerson,
                    FirstName = p.FirstName,
                    LastName = p.LastName
                });
            return persons;
        }
    }
}
