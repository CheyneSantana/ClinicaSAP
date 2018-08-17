using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP
{
    [Table("especialidade")]
    public class Especialidade
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ESPECIALIDADEID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string NOMEESPECIALIDADE { get; set; }
        [Required]
        public int SERVICOID { get; set; }
        [Required]
        public int ATIVO { get; set; }
    }
}