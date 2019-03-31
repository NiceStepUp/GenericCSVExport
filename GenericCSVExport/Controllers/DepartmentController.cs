using GenericCSVExport.Core.Services;
using GenericCSVExport.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericCSVExport.Controllers
{
    public class DepartmentController : BaseController
    {
        private IDepartmentService _depService;

        public DepartmentController(IDepartmentService depService)
        {
            _depService = depService;
        }

        // GET: Department
        public ActionResult Index()
        {
            return View(_depService.GetDepartments());
        }
    }
}