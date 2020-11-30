using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace logintemplates.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}