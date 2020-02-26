using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
   public interface IMailSender
    {
        void Send(Mail Mail, Adresser From, Adressee To);

        void Send(Mail Message, Adresser From, IEnumerable<Adressee> To);

        Task SendAsync(Mail Mail, Adresser From, Adressee To);

        Task SendAsync(Mail Message, Adresser From, IEnumerable<Adressee> To, CancellationToken Cancel = default);
    }
}
