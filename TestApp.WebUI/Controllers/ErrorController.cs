using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TestApp.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            IExceptionHandlerPathFeature exceptionDetails 
                = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            Exception exception = exceptionDetails?.Error;

            ViewBag.Path = exceptionDetails.Path;

            return View("Error", exception);
        }
    }
}
