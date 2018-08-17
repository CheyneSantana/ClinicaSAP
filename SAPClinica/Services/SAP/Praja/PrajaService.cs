using SAPClinica.Command;
using SAPClinica.Models.SAP.Praja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Services.SAP.Praja
{
    public class PrajaService : CoViking
    {
        private CoViking aCoViking;
        public PrajaService(CoViking prCoViking)
        {
            aCoViking = prCoViking;
        }

        public void enviarCadastro(PrajaDTO prPrajaDTO)
        {
            EnviarCadastroPraja lEnviarCadastroPraja = new EnviarCadastroPraja(aCoViking, prPrajaDTO);
            lEnviarCadastroPraja.enviar();
        }
    }
}