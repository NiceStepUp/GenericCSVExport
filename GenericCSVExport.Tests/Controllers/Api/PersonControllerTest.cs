using GenericCSVExport.Controllers.Api;
using GenericCSVExport.Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Tests.Controllers.Api
{
    [TestFixture]
    public class PersonControllerTest
    {
        private PersonController _personController;
        private Mock<IPersonService> _personService;


        [SetUp]
        public void SetUp()
        {
            _personService = new Mock<IPersonService>();            
            _personService.Setup(ps => ps.ExportPersonsToCSV())
                .Returns(new Core.DTO.CommonDTO.FileDTO
                {
                    Content = new byte[0],
                    FileName = "Mocked file",
                    MediaTypeHeaderValue = "application/octet-stream"
                });

            _personController = new PersonController(_personService.Object);
        }


        [Test]
        public void Download_WhenCalled_ReturnsNotFound()
        {
            var result = _personController.Download(null);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }


        [Test]
        public void Download_WhenCalled_ReturnsOk()
        {
            var result = _personController.Download(1);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
