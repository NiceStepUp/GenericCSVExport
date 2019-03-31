using GenericCSVExport.Core.Services;
using GenericCSVExport.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace GenericCSVExport.Controllers.Api
{
    public class DepartmentController : ApiController
    {
        private IDepartmentService _depService;


        public DepartmentController(IDepartmentService depService)
        {
            _depService = depService;
        }


        [System.Web.Http.HttpGet]
        public HttpResponseMessage Download(int? id = null)
        {
            if ( !id.HasValue) 
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(new MemoryStream(_depService.ExportDepartmentsToCSV().Content));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = _depService.ExportDepartmentsToCSV().FileName };
            return result;
        }
    }
}