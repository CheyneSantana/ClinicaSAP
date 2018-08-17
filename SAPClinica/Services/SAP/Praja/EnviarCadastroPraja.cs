using SAPClinica.Command;
using SAPClinica.Models.SAP.Praja;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace SAPClinica.Services.SAP.Praja
{
    public class EnviarCadastroPraja : CoViking
    {
        #region Variables
        private PrajaDTO aPrajaDTO;
        private CoViking aCoViking;
        private string emailClinica = string.Empty;
        private string emailEnvio = string.Empty;
        private Attachment aAttachment;
        #endregion

        public EnviarCadastroPraja(CoViking prCoViking, PrajaDTO prPrajaDTO)
        {
            aCoViking = prCoViking;
            aPrajaDTO = prPrajaDTO;
            emailClinica = "atendimento@clinicasap.com.br";
            emailEnvio = "pergunte@clinicasap.com.br";
        }

        #region Methods
        private void validarDados()
        {
            if (aPrajaDTO == null)
                aCoViking.addErro("PrajaDTO nulo");
            else
            {
                if (string.IsNullOrEmpty(aPrajaDTO.NOME))
                    aCoViking.addErro("");

                if (string.IsNullOrEmpty(aPrajaDTO.ENDERECO))
                    aCoViking.addErro("Por favor informar o endereço!");

                if (string.IsNullOrEmpty(aPrajaDTO.EMAIL))
                    aCoViking.addErro("Necessário informar um email!");

                if (string.IsNullOrEmpty(aPrajaDTO.TELEFONE))
                    aCoViking.addErro("Por favor informar o telefone!");

                if (string.IsNullOrEmpty(aPrajaDTO.PERGUNTA))
                    aCoViking.addErro("Por favor informar por que quer mudar seu estilo de vida!");

                if (string.IsNullOrEmpty(aPrajaDTO.IMAGEM))
                    aCoViking.addErro("Por favor incluir uma imagem de corpo inteiro!");
            }
        }

        private void send()
        {
            MailMessage mail = new MailMessage(emailEnvio, emailClinica);
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.clinicasap.com.br";
            mail.Subject = "Cadastro programa Pra já";
            mail.Body = formatText();
            mail.Attachments.Add(aAttachment);
            client.Send(mail);
        }

        private string formatText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("O cliente a seguir realizou o cadastro no programa Pra já");
            sb.AppendLine("Nome: " + aPrajaDTO.NOME);
            sb.AppendLine("Data de Nascimento: " + aPrajaDTO.DTNASCIMENTO.ToString());
            sb.AppendLine("Endereço: " + aPrajaDTO.ENDERECO);
            sb.AppendLine("Email: " + aPrajaDTO.EMAIL);
            sb.AppendLine("Telefone: " + aPrajaDTO.TELEFONE);
            sb.AppendLine("Motivo: ");
            sb.AppendLine(aPrajaDTO.PERGUNTA);

            return sb.ToString();
        }

        private Attachment getAttachments()
        {
            string lTipoImagem = string.Empty;

            if (aPrajaDTO.IMAGEM.Contains("data:image/png;base64"))
            {
                aPrajaDTO.IMAGEM = aPrajaDTO.IMAGEM.Replace("data:image/png;base64,", "");
                lTipoImagem = ".png";
            }

            if (aPrajaDTO.IMAGEM.Contains("data:image/jpeg;base64"))
            {
                aPrajaDTO.IMAGEM = aPrajaDTO.IMAGEM.Replace("data:image/jpeg;base64,", "");
                lTipoImagem = ".jpeg";
            }

            byte[] bytes = Convert.FromBase64String(aPrajaDTO.IMAGEM);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            string lTempPath = Path.GetTempPath();

            Bitmap b = new Bitmap(image);
            if (File.Exists(lTempPath + aPrajaDTO.NOME  + lTipoImagem))
                File.Delete(lTempPath + aPrajaDTO.NOME + lTipoImagem);

            b.Save(lTempPath + aPrajaDTO.NOME + lTipoImagem);

            aAttachment = new Attachment(lTempPath + aPrajaDTO.NOME + lTipoImagem);

            return aAttachment;
        }
        #endregion

        public void enviar()
        {
            this.validarDados();

            if (!aCoViking.withError())
            {
                this.getAttachments();
                this.send();
            }
        }
    }
}