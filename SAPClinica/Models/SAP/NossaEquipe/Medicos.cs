using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP.NossaEquipe
{
    [Table("medico")]
    public class Medicos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MEDICOID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FIRST_NAME { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LAST_NAME { get; set; }
        [Required]
        public int ESPECIALIDADEID { get; set; }
        [Required]
        public string NRODOCUMENTO { get; set; }
        [Required]
        public int TIPODOCUMENTOMEDICOID { get; set; }
        [Required]
        public int ATIVO { get; set; }
    }
}