using Loja_Virtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Loja_Virtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            //vai enviar a mensagem.
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("felipe.braghittoni1999@gmail.com", "");
            smtp.EnableSsl = true;


            string corpoMsg = string.Format("<h2>Contato - Loja Prazer</h2>" +
                "<b>Nome: </b> {0} <br />" +
                "<b>E-Mail: </b> {1} <br />" +
                "<b>Texto: </b> {2} <br />" +
                "E-mail enviado automaticamente do site Loja Prazer.",
                contato.Nome,
                contato.Email,
                contato.Texto);

            //mailmessage -> controi a msg


            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("felipe.braghittoni1999@gmail.com");
            mensagem.To.Add("cabraldesousaluana@gmail.com");
            mensagem.Subject = "Contato - Loja Prazer - E-mail: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;


            //envia a msg
            smtp.Send(mensagem);
        }
    }
}
