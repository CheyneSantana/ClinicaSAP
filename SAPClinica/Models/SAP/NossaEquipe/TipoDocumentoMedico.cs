using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP.NossaEquipe
{
    [Table("tipodocumentomedico")]
    public class TipoDocumentoMedico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TIPODOCUMENTOMEDICOID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string NOMEDOCUMENTOMEDICO { get; set; }
    }
}