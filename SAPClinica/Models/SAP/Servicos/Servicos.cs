using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP.Servico
{
    [Table("servico")]
    public class Servicos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SERVICOID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string NOMESERVICO { get; set; }
        [Required]
        public int ATIVO { get; set; }
    }
}