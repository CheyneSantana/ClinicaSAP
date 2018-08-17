using SAPClinica.Command;
using SAPClinica.Models.SAP;
using SAPClinica.Models.SAP.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Services.SAP.PergunteEspecialista
{
    public class FindServicosPergunte
    {
        #region Veriaveis
        private CoViking aCoVikings;
        public List<ServicosDTO> acoServicosDTO;
        #endregion 
        public FindServicosPergunte(CoViking prCoVikings)
        {
            acoServicosDTO = new List<ServicosDTO>();
            aCoVikings = prCoVikings;
        }

        public void execute()
        {
            List<Servicos> lcoServicos = getServicos();
            foreach(Servicos lServico in lcoServicos)
            {
                ServicosDTO lServicosDTO = new ServicosDTO()
                {
                    SERVICOID = lServico.SERVICOID,
                    NOMESERVICO = lServico.NOMESERVICO,
                    ESPECIALIDADES = new List<EspecialidadesDTO>()
                };

                List<Especialidade> lcoEspecialidades = getEspecialidades(lServico.SERVICOID);
                foreach(Especialidade lEspecialidade in lcoEspecialidades)
                {
                    EspecialidadesDTO lEspecialidadesDTO = new EspecialidadesDTO()
                    {
                        ESPECIALIDADEID = lEspecialidade.ESPECIALIDADEID,
                        NOMEESPECIALIDADE = lEspecialidade.NOMEESPECIALIDADE
                    };

                    lServicosDTO.ESPECIALIDADES.Add(lEspecialidadesDTO);
                }

                acoServicosDTO.Add(lServicosDTO);
            }
        }

        #region Métodos
        private List<Servicos> getServicos()
        {
            ServicosRepository lServicosRepository = new ServicosRepository();
            List<Servicos> lResult = lServicosRepository.getAllAtivo();
            return lResult;
        }

        private List<Especialidade> getEspecialidades(decimal prServicoID)
        {
            EspecialidadeRepository lEspecialidadeRepository = new EspecialidadeRepository();
            List<Especialidade> lResult = lEspecialidadeRepository.getByServico(prServicoID);
            return lResult;
        }
        #endregion
    }
}