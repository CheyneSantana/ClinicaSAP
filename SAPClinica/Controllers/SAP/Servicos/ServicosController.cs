using SAPClinica.Controllers.Application;
using SAPClinica.Models.SAP;
using SAPClinica.Models.SAP.Servico;
using SAPClinica.Services.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPClinica.Controllers.SAP
{
    public class ServicosController : VikingsController
    {
        // GET: Servicos
        public ActionResult Index()
        {
            if(Request.Browser.IsMobileDevice)
                return View("~/Views/SAP/Servicos/ServicosMobile.cshtml");

            return View("~/Views/SAP/Servicos/Servicos.cshtml");
        }

        public ActionResult Especialidades(decimal prServico)
        {
            return View("~/Views/SAP/Servicos/Especialidades.cshtml");
        }

        [HttpPost]
        public ActionResult getServicos()
        {
            ServicosRepository lServicosRepository = new ServicosRepository();
            List<Servicos> lServicos = lServicosRepository.getAllAtivo();
            if (aCoViking.withError())
                return Json(aCoViking.aErros);
            else
                return Json(lServicos);
        }

        [HttpPost]
        public ActionResult getEspecialidades(decimal prServico)
        {
            ServicosService lServicosService = new ServicosService(aCoViking);
            lServicosService.FindByServico(prServico);
            if (aCoViking.withError())
                return Json(aCoViking.aErros);
            else
                return Json(lServicosService.aServicosDTO);
        }
    }
}