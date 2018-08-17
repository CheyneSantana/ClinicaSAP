using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPClinica.Models.SAP.PergunteEspecialista
{
    public class EnvioDTO
    {
        public string NomePaciente { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Texto { get; set; }
        public decimal EspecialidadeId { get; set; }
        public string NomeEspecialidade { get; set; }
    }
}