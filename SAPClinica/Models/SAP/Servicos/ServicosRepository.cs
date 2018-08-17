using SAPClinica.Command;
using SAPClinica.Models.SAP.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP
{
    public class ServicosRepository : VikingsRepository<Servicos>
    {
        public ServicosRepository()
        {
        }

        public List<Servicos> getAllAtivo()
        {
            var linq = from serv in context.Servicoss
                       where serv.ATIVO == (int)CoViking.KDLogical.KDSim
                       select serv;

            return linq.ToList();
        }
    }
}