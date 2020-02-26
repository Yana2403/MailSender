using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using System.Linq;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class MailSenderService : IMailSenderService
    {
        public IMailSender GetSender(Server Server) => new MailSender(Server); //создание нового и передача сервера
    }
    public  class MailSender : IMailSender
    {
        private readonly Server _Server;

        public MailSender(Server Server)
        {
            _Server = Server;
        }

        public void Send(Mail Mail, Adresser From, Adressee To)
        {
            using (var message = new MailMessage(new MailAddress(From.Address, From.Name), new MailAddress(To.Address, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var login = new NetworkCredential(_Server.Login, _Server.Password);
                using (var client = new SmtpClient(_Server.Address, _Server.Port) { EnableSsl = _Server.UseSSL, Credentials = login })
                    client.Send(message);
            }
        }
        public void Send(Mail Message,Adresser From, IEnumerable<Adressee> To)
        {
            foreach (var adressee in To)
                Send(Message, From, adressee);
        }

        public void SendParallel(Mail Message, Adresser From, IEnumerable<Adressee> To)
        {
            foreach (var adressee in To)
                ThreadPool.QueueUserWorkItem(_ => Send(Message, From, adressee));
        }
        public async Task SendAsync(Mail Mail, Adresser From, Adressee To) //отправка одного сообщения асинхронно
        {
            using (var message = new MailMessage(new MailAddress(From.Address, From.Name), new MailAddress(To.Address, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var login = new NetworkCredential(_Server.Login, _Server.Password);
                using (var client = new SmtpClient(_Server.Address, _Server.Port) { EnableSsl = _Server.UseSSL, Credentials = login })
                    //client.Send(message);
                    await client.SendMailAsync(message).ConfigureAwait(false);
            }
        }

        /*public async Task SendAsync(Mail Message, Adresser From, IEnumerable<Adressee> To) //отправка сразу нескольким параллельной обработкой
        {
            await Task.WhenAll(To.Select(to => SendAsync(Message, From, to))).ConfigureAwait(false);
        }*/

        public async Task SendAsync(Mail Message, Adresser From, IEnumerable<Adressee> To, CancellationToken Cancel = default) //2 вариат рассылки последовательной обработкой
        {
            foreach (var recipient in To)
            {
                Cancel.ThrowIfCancellationRequested();
                await SendAsync(Message, From, recipient).ConfigureAwait(false);
            }
        }
    }
}

