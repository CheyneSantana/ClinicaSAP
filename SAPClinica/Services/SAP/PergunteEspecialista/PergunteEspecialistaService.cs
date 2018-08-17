using SAPClinica.Command;
using SAPClinica.Models.SAP;
using SAPClinica.Models.SAP.PergunteEspecialista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Services.SAP.PergunteEspecialista
{
    public class PergunteEspecialistaService
    {
        private CoViking aCoViking;
        public List<ServicosDTO> acoServicosDTO;

        public PergunteEspecialistaService(CoViking prCoViking)
        {
            aCoViking = prCoViking;
        }

        public void FindAllEspecialidades()
        {
            FindServicosPergunte lFindServicosPergunte = new FindServicosPergunte(aCoViking);
            lFindServicosPergunte.execute();
            acoServicosDTO = lFindServicosPergunte.acoServicosDTO;
        }

        public void SendMail(EnvioDTO prEnvioDTO)
        {
            EnviarEmail lEnviarEmail = new EnviarEmail(aCoViking, prEnvioDTO);
            lEnviarEmail.execute();
        }
    }
}