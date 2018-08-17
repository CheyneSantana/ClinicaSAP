using SAPClinica.Command;
using SAPClinica.Models.SAP.PergunteEspecialista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace SAPClinica.Services.SAP.PergunteEspecialista
{
    public class EnviarEmail
    {
        #region Variáveis
        private CoViking aCoViking;
        private EnvioDTO aEnvioDTO;
        private string emailClinica = string.Empty;
        private string emailEnvio = string.Empty;
        #endregion

        public EnviarEmail(CoViking prCoViking, EnvioDTO prEnvioDTO)
        {
            aCoViking = prCoViking;
            aEnvioDTO = prEnvioDTO;
            emailClinica = "atendimento@clinicasap.com.br";
            emailEnvio = "pergunte@clinicasap.com.br";
        }

        public void execute()
        {
            validarDados();
            if (!aCoViking.withError())
            {
                send();
            }
        }

        #region Métodos
        public void validarDados()
        {
            if (string.IsNullOrEmpty(aEnvioDTO.NomePaciente))
                aCoViking.addErro("Necessário incluir o nome do Paciente");
            if (string.IsNullOrEmpty(aEnvioDTO.Telefone))
                aCoViking.addErro("Necessário incluir o número do telefone");
            if (string.IsNullOrEmpty(aEnvioDTO.Texto))
                aCoViking.addErro("Necessário incluir a dúvida");
            if (string.IsNullOrEmpty(aEnvioDTO.Email))
                aCoViking.addErro("Necessário incluir o email");
        }

        public void send()
        {
            MailMessage mail = new MailMessage(emailEnvio, emailClinica);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.clinicasap.com.br";
            mail.Subject = "Pergunte ao Especialista";
            mail.Body = formatText();
            client.Send(mail);
        }

        public string formatText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nome do Paciente: " + aEnvioDTO.NomePaciente);
            sb.AppendLine("Email: " + aEnvioDTO.Email);
            sb.AppendLine("Data Nascimento: " + aEnvioDTO.DataNascimento);
            sb.AppendLine("Telefone: " + aEnvioDTO.Telefone);
            sb.AppendLine("Especialidade: " + aEnvioDTO.NomeEspecialidade);
            sb.AppendLine("Pergunta: " + aEnvioDTO.Texto);

            return sb.ToString();
        }
        #endregion
    }
}