using MailSender.lib.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MailSender.lib.Services
{
    public class DebugMailSender
    {
        private Server _Server;

        public DebugMailSender(Server Server)
        {
            _Server = Server;
        }

        public void Send(Mail Mail, Adresser From, Adressee To)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]\r\n{5}:{6}",
                From.Address, To.Address, _Server.Address, _Server.Port, _Server.UseSSL ? "SSL" : "no SSL",
               Mail.Subject, Mail.Body);
        }
        public void Send(Mail Message, Adresser From, IEnumerable<Adressee> To)
        {
            foreach (var adressee in To)
                Send(Message, From, adressee);
        }

        public void SendParallel(Mail Message, Adresser From, IEnumerable<Adressee> To)
        {
            foreach (var adressee in To)
                ThreadPool.QueueUserWorkItem(_ => Send(Message, From, adressee));
        }
    }
}

