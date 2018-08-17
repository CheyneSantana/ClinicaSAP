using SAPClinica.Models.SAP.NossaEquipe;
using SAPClinica.Models.SAP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SAPClinica.Models.SAP.Servico;

namespace SAPClinica.Command
{
    public class VikingsContext : DbContext
    {
        #region DbSets
        public DbSet<Especialidade> SubServicoss { get; set; }
        public DbSet<Servicos> Servicoss { get; set; }
        public DbSet<Medicos> Medicoss { get; set; }
        public DbSet<TipoDocumentoMedico> TipoDocumentoMedicos { get; set; }
        #endregion

        public VikingsContext()
            : base("name=VikingsConnection")
        {
        }
    }
}