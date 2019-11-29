using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exam70_486.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Localization;
using System.Threading;
using System.Security.Principal;
using System.Web.Security;
using Microsoft.AspNetCore.Authorization;

namespace Exam70_486.Controllers
{
    //[ResultFilter]
   [Authorize]
    public class HomeController : Controller
    {        
        private readonly ILogger<HomeController> _logger;
        //IViewEngine

        public HomeController(ILogger<HomeController> logger)
        {
            //IControllerFactory
            _logger = logger; //RoleEntryPoint
        }
       // [MiddlewareFilter(typeof(String))]
        public IActionResult Index()
        {
            // var w = WindowsIdentity;
            //MembershipProvider
            Thread.CurrentPrincipal = User;
            var v = HttpContext.User;
            return View();
        }
      
        public ActionResult Privacy()
        {
            //ProviderBase
            RoleProvider
            return new EmptyResult();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
