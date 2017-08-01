using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deepend_Test.Web.Controllers
{
    public class ChequeDetailController : Controller
    {
        // GET: ChequeDetail
        public ActionResult Index()
        {
            ViewBag.chequeId = Request.QueryString["chequeId"];

            return View();
        }
    }
}