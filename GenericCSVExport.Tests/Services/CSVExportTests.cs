using GenericCSVExport.Common.Export;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Tests.Services
{
    [TestFixture]
    public class CSVExportTests
    {
        private CSVExport _csvExport;

        [SetUp]
        public void SetUp()
        {
            _csvExport = new CSVExport();
        }


        [Test]
        public void WriteCSV_WhenCalled_ReturnsAnBytesArray()
        {
            var person = new { Name = "Jon", Phones = new[] { "555-555-5555", "888-888-8888" } };
            var someList = new[] { 1 }.Select(i => person).ToList();

            var result = _csvExport.WriteCSV(someList);

            Assert.That(new byte[0].Count(), Is.LessThan(result.Count()));
        }
    }
}
