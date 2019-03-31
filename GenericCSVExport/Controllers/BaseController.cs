using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericCSVExport.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Обработка исключений без смены URL. This is a best practise
        /// Exception Handling without changing URL path
        /// </summary>
        /// <param name="filterContext">Context of HandleErrorAttribute</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
            filterContext.ExceptionHandled = true;
        }
    }
}