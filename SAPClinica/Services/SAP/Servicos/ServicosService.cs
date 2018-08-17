using SAPClinica.Command;
using SAPClinica.Models.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Services.SAP
{
    public class ServicosService
    {
        #region Variaveis
        private CoViking aCoViking;
        public ServicosDTO aServicosDTO;
        public List<Especialidade> acoSubServicos;
        #endregion

        public ServicosService(CoViking prCoViking)
        {
            aCoViking = prCoViking;
            acoSubServicos = new List<Especialidade>();
        }

        public void FindAll()
        {
            EspecialidadeRepository lSubServicosRepository = new EspecialidadeRepository();
            acoSubServicos = lSubServicosRepository.getAll();
        }

        public void FindByServico(decimal prServico)
        {
            FindEspecialidade lFindSubServicos = new FindEspecialidade(aCoViking, prServico);
            lFindSubServicos.execute();
            aServicosDTO = lFindSubServicos.aServicosDTO;
        }
    }
}