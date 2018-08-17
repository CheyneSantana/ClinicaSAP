using SAPClinica.Controllers.Application;
using SAPClinica.Models.SAP.PergunteEspecialista;
using SAPClinica.Services.SAP.PergunteEspecialista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPClinica.Controllers.SAP.PergunteEspecialista
{
    public class PergunteEspecialistaController : VikingsController
    {
        // GET: PergunteEspecialista
        public ActionResult Index()
        {
            return View("~/Views/SAP/PergunteEspecialista/PergunteAoEspecialista.cshtml");
        }

        [HttpPost]
        public ActionResult findAllEspecialidades()
        {
            PergunteEspecialistaService lPergunteEspecialistaService = new PergunteEspecialistaService(aCoViking);
            lPergunteEspecialistaService.FindAllEspecialidades();

            if (aCoViking.withError())
                return Json(aCoViking.aErros);
            else
                return Json(lPergunteEspecialistaService.acoServicosDTO);
        }

        [HttpPost]
        public ActionResult EnviarPergunta(EnvioDTO prEnvioDTO)
        {
            PergunteEspecialistaService lPergunteEspecialistaService = new PergunteEspecialistaService(aCoViking);
            lPergunteEspecialistaService.SendMail(prEnvioDTO);

            if (aCoViking.withError())
                return Json(aCoViking.aErros);
            else
                return Json("");
        }
    }
}