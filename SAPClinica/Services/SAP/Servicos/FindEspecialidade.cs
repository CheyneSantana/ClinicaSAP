using SAPClinica.Command;
using SAPClinica.Models.SAP;
using SAPClinica.Models.SAP.Servico;
using SAPClinica.Models.SAP.NossaEquipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Services.SAP
{
    public class FindEspecialidade
    {
        #region Variavéis
        private CoViking aCoViking;
        private List<Especialidade> acoEspecialidades;
        public ServicosDTO aServicosDTO;
        private decimal aServicoID;
        private Servicos aServicos;
        #endregion

        #region Repositorios
        private EspecialidadeRepository aEspecialidadeRepository = null;
        private ServicosRepository aServicosRepository = null;
        private TipoDocumentoMedicoRepository aTipoDocumentoMedicoRepository = null;
        #endregion

        public FindEspecialidade(CoViking prCoViking, decimal prServico)
        {
            aCoViking = prCoViking;
            aServicoID = prServico;
            aEspecialidadeRepository = new EspecialidadeRepository();
            aServicosRepository = new ServicosRepository();
            aTipoDocumentoMedicoRepository = new TipoDocumentoMedicoRepository();

        }

        public void execute()
        {
            if (aServicoID != 0)
            {
                getServico();
                getSubservicos();
                montarDTO();
            }
            else
                aCoViking.addErro("Selecione um serviço");
        }

        private void getServico()
        {
            aServicos = aServicosRepository.getID(aServicoID);
        }

        private void getSubservicos()
        {
            acoEspecialidades = aEspecialidadeRepository.getByServico(aServicoID);

        }

        private List<MedicosDTO> getMedicos(decimal prSubServicoID)
        {
            List<MedicosDTO> lcoMedicosDTO = new List<MedicosDTO>();
            MedicosDTO lDTO;
            MedicosRepository lMedicosRepository = new MedicosRepository();
            List<Medicos> lcoMedicos = lMedicosRepository.getByEspecialidade(prSubServicoID);

            foreach(Medicos lMedicos in lcoMedicos)
            {
                lDTO = new MedicosDTO()
                {
                    MEDICOID = lMedicos.MEDICOID,
                    NOMEMEDICO = lMedicos.FIRST_NAME + " " + lMedicos.LAST_NAME,
                    NRODOCUMENTO = lMedicos.NRODOCUMENTO,
                    NOMEDOCUMENTO = this.getNomeDocumento(lMedicos.TIPODOCUMENTOMEDICOID)
                };

                lcoMedicosDTO.Add(lDTO);
            }

            return lcoMedicosDTO;
        }

        private string getNomeDocumento(int prTipoDocumentoMedicoID)
        {
            string lResult = string.Empty;

            TipoDocumentoMedico lTipoDocumentoMedico = aTipoDocumentoMedicoRepository.getID(prTipoDocumentoMedicoID);
            if (lTipoDocumentoMedico != null)
                lResult = lTipoDocumentoMedico.NOMEDOCUMENTOMEDICO;

            return lResult;
        }

        private void montarDTO()
        {
            EspecialidadesDTO lEspecialidadesDTO;
            aServicosDTO = new ServicosDTO()
            {
                SERVICOID = aServicos.SERVICOID,
                NOMESERVICO = aServicos.NOMESERVICO,
                ESPECIALIDADES = new List<EspecialidadesDTO>()
            };

            foreach(Especialidade lEspecialidade in acoEspecialidades)
            {
                lEspecialidadesDTO = new EspecialidadesDTO();
                lEspecialidadesDTO.ESPECIALIDADEID = lEspecialidade.ESPECIALIDADEID;
                lEspecialidadesDTO.NOMEESPECIALIDADE = lEspecialidade.NOMEESPECIALIDADE;
                lEspecialidadesDTO.MEDICOS = getMedicos(lEspecialidade.ESPECIALIDADEID);

                aServicosDTO.ESPECIALIDADES.Add(lEspecialidadesDTO);
            }
        }
    }
}