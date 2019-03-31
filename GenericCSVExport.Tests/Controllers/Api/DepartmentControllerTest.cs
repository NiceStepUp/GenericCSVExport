using GenericCSVExport.Controllers.Api;
using GenericCSVExport.Core.Repositories;
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
    public class DepartmentControllerTest
    {
        private Mock<IDepartmentService> _departmentService;
        private DepartmentController _departmentController;


        [SetUp]
        public void SetUp()
        {
            _departmentService = new Mock<IDepartmentService>();

            _departmentService.Setup(de => de.ExportDepartmentsToCSV())
                .Returns(new Core.DTO.CommonDTO.FileDTO
                {
                    Content = new byte[0],
                    FileName = "Mocked file",
                    MediaTypeHeaderValue = "application/octet-stream"
                });

            _departmentController = new DepartmentController(_departmentService.Object);
        }


        [Test]
        public void Download_WhenCalled_ReturnsNotFound()
        {
            var result = _departmentController.Download(null);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
        }


        [Test]
        public void Download_WhenCalled_ReturnsOk()
        {
            var result = _departmentController.Download(1);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
