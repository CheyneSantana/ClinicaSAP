using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP.Praja
{
    public class PrajaDTO
    {
        public string NOME { get; set; }
        public DateTime DTNASCIMENTO { get; set; }
        public string ENDERECO { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string PERGUNTA { get; set; }
        public string IMAGEM { get; set; }
    }
}