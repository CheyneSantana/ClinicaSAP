using SAPClinica.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP
{
    public class EspecialidadeRepository : VikingsRepository<Especialidade>
    {
        public EspecialidadeRepository()
        {
        }

        public List<Especialidade> getByServico(decimal prServicoID)
        {
            var linq = from ss in context.SubServicoss
                       where ss.SERVICOID == prServicoID
                       && ss.ATIVO == (int)CoViking.KDLogical.KDSim
                       select ss;

            return linq.ToList();
        }
    }
}