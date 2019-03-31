using FluentAssertions;
using GenericCSVExport.Core.Model;
using GenericCSVExport.Persistence.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Tests.Persistence
{
    public class DepartmentRepositoryTests
    {
        private DepartmentRepository _departmentRepository;
        private Mock<DbSet<Department>> _mockDepartments;


        [SetUp]
        public void TestInitialize()
        {
            _mockDepartments = new Mock<DbSet<Department>>();
            // In addition, we need to mock a database context, however we imitate repository in this project, so we don't have a DB context
            // But if we have a real database, our code should look like the following code snippet:
            /*var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Departments).Returns(_mockNotifications.Object);            
            _repository = new DepartmentRepository(mockContext.Object);*/

            _departmentRepository = new DepartmentRepository();
        }


        [Test]
        public void GetPersons_WhenCalled_ShouldBeReturned()
        {
            var departments = _departmentRepository.GetDepartments();
            departments.Should().NotBeEmpty();
        }
    }
}
