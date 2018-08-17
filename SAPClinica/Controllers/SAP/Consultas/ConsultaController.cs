using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPClinica.Controllers.SAP.Consultas
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {
            return View("~/Views/SAP/Consultas/Consultas.cshtml");
        }
    }
}