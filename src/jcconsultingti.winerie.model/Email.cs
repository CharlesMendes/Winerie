using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model
{
    public class Email
    {
        public Email()
        {

        }

        public Email(string _de, string _para, string _assunto, string _mensagem)
        {
            de = _de;
            para = _para;
            assunto = _assunto;
            mensagem = _mensagem;
        }

        public Email(string _de, string _para, string _assunto, string _mensagem, SmtpClient _clientSmtp)
        {
            de = _de;
            para = _para;
            assunto = _assunto;
            mensagem = _mensagem;
            clientSmtp = _clientSmtp;
        }

        public string de { get; set; }
        public string para { get; set; }
        public string assunto { get; set; }
        public string mensagem { get; set; }

        #region configuracao

        public SmtpClient clientSmtp { get; set; }

        #endregion
    }
}
