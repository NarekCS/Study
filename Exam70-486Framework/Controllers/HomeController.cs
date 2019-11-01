using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Exam70_486Framework.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration =120, VaryByParam ="Name", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index()
        {
            HttpContext.Response.WriteSubstitution(HttpContext => string.Empty);
            return View();
        }

        [ChildActionOnly]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration =60)]
        public ActionResult Contact()
        {
            //HttpContext.AcceptWebSocketRequest(s => s.WebSocket.ReceiveAsync()
            ViewBag.Message = "Your contact page.";
            //WebSocket
            return View();
        }
    }
}