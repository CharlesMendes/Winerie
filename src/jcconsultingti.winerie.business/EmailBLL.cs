using jcconsultingti.winerie.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.business
{
    public class EmailBLL
    {
        public void EnviarEmail(Email obj)
        {
            try
            {
                using (var message = new MailMessage(obj.de, obj.para))
                {
                    message.Subject = obj.assunto;
                    message.Body = obj.mensagem;

                    using (SmtpClient client = obj.clientSmtp)
                    {
                        client.Send(message);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EnviarEmailTeste()
        {
            //Configuração de email
            Email email = new Email(
                "contato@charlesmendes.com",
                "charles.mendes@novum.com.br",
                "Teste winerie",
                "winerie Test at " + DateTime.Now,
                new SmtpClient
                {
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("contato@charlesmendes.com", "SENHA")
                });

            this.EnviarEmail(email);
        }
    }
}
