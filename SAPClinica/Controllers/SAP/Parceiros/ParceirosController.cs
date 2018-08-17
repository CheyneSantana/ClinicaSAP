using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPClinica.Controllers.SAP.Parceiros
{
    public class ParceirosController : Controller
    {
        // GET: Parceiros
        public ActionResult Index()
        {
            return View("~/Views/SAP/Parceiros/Parceiros.cshtml");
        }
    }
}