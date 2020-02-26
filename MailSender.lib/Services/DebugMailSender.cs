using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{

    public class DebugMailSenderService : IMailSenderService //отладочный сервис
    {
        public IMailSender GetSender(Server Server) => new DebugMailSender(Server);
    }
    public class DebugMailSender : IMailSender
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

        public Task SendAsync(Mail Mail, Adresser From, Adressee To)
        {
            Send(Mail, From, To);
            return Task.CompletedTask;
        }

        public Task SendAsync(Mail Message, Adresser From, IEnumerable<Adressee> To, CancellationToken Cancel = default)
        {
            Send(Message, From, To);
            return Task.CompletedTask;

        }

        public void SendParallel(Mail Message, Adresser From, IEnumerable<Adressee> To)
        {
            foreach (var adressee in To)
                ThreadPool.QueueUserWorkItem(_ => Send(Message, From, adressee));
        }
    }
}

