using GenericCSVExport.Core.Services;
using GenericCSVExport.Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;

namespace GenericCSVExport.Controllers.Api
{
    public class PersonController : ApiController
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [System.Web.Http.HttpGet]
        public HttpResponseMessage Download(int? id = null)
        {
            if ( !id.HasValue)
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent( new MemoryStream(_personService.ExportPersonsToCSV().Content));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = _personService.ExportPersonsToCSV().FileName };
            return result;
        }
    }
}
