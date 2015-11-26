using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaisVoluntarios.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult cadastrovoluntario()
        {
            return View();
        }
        public ActionResult cadastroempresa()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
    }
}