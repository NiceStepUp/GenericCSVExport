using FluentAssertions;
using GenericCSVExport.Core.Model;
using GenericCSVExport.Persistence.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestFixture]
    public class PersonRepositoryTests
    {
        private PersonRepository _personRepository;
        private Mock<DbSet<Person>> _mockPersons;

        
        [SetUp]
        public void TestInitialize()
        {
            _mockPersons = new Mock<DbSet<Person>>();
            // In addition, we need to mock a database context, however we imitate repository in this project, so we don't have a DB context
            // But if we have a real database, our code should look like the following code snippet:
            /*var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Persons).Returns(_mockNotifications.Object);            
            _repository = new PersonRepository(mockContext.Object);*/

            _personRepository = new PersonRepository();
        }


        [Test]
        public void GetPersons_WhenCalled_ShouldBeReturned()
        {
            var persons = _personRepository.GetPersons();
            persons.Should().NotBeEmpty();
        }
    }
}
