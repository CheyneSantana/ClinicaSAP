using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SAPClinica.Command
{
    public class CoViking : ICoViking
    {
        public List<MessageErro> aErros;
        public CoViking()
        {
            aErros = new List<MessageErro>();
        }

        [DebuggerStepThrough]
        public void addErro(string prErro)
        {
            this.aErros.Add(new MessageErro { aErro = prErro });
        }

        [DebuggerStepThrough]
        public bool withError()
        {
            bool lResult = false;

            if (this.aErros.Count > 0)
                lResult = true;

            return lResult;
        }


        public enum KDLogical
        {
            KDNao = 0,
            KDSim = 1
        }
    }
}