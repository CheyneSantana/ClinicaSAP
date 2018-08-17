using SAPClinica.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP.NossaEquipe
{
    public class MedicosRepository : VikingsRepository<Medicos>
    {
        public MedicosRepository()
        {
        }

        public List<Medicos> getByEspecialidade(decimal prEspecialidadeID)
        {
            var linq = from med in context.Medicoss
                       where med.ESPECIALIDADEID == prEspecialidadeID
                       select med;

            return linq.ToList();
        }
    }
}