using SAPClinica.Controllers.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPClinica.Controllers.SAP.NossaEquipe
{
    public class NossaEquipeController : VikingsController
    {
        // GET: NossaEquipe
        public ActionResult Index()
        {
            return View("~/Views/SAP/NossaEquipe/NossaEquipe.cshtml");
        }
    }
}