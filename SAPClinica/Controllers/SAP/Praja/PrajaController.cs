using SAPClinica.Controllers.Application;
using SAPClinica.Models.SAP.Praja;
using SAPClinica.Services.SAP.Praja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SAPClinica.Controllers.SAP
{
    public class PrajaController : VikingsController
    {
        // GET: Praja
        public ActionResult Index()
        {
            return View("~/Views/SAP/Praja/Praja.cshtml");
        }
        
        public ActionResult Cadastrar(PrajaDTO prPrajaDTO)
        {
            PrajaService lPrajaService = new PrajaService(aCoViking);
            lPrajaService.enviarCadastro(prPrajaDTO);

            return Json(aCoViking.aErros);
        }
    }
}