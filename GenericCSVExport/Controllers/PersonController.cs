using GenericCSVExport.Core.Services;
using GenericCSVExport.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericCSVExport.Controllers
{
    public class PersonController : BaseController
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: Person
        public ActionResult Index()
        {
            var persons = _personService.GetPersons();
            return View(persons);
        }
    }
}