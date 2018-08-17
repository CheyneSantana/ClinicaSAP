using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP
{
    public class ServicosDTO
    {
        public decimal SERVICOID { get; set; }
        public string NOMESERVICO { get; set; }
        public List<EspecialidadesDTO> ESPECIALIDADES { get; set; }
    }

    public class EspecialidadesDTO
    {
        public decimal ESPECIALIDADEID { get; set; }
        public string NOMEESPECIALIDADE { get; set; }
        public List<MedicosDTO> MEDICOS { get; set; }
    }

    public class MedicosDTO
    {
        public decimal MEDICOID { get; set; }
        public string NOMEMEDICO { get; set; }
        public string NRODOCUMENTO { get; set; }
        public string NOMEDOCUMENTO { get; set; }
    }
}