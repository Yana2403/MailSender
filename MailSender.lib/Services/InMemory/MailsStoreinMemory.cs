using MailSender.lib.Entities;
using MailSender.lib.Services.InMemory;
using System.Linq;

namespace MailSender.lib.Services.Interfaces
{
    public class MailsStoreinMemory : DataStoreInMemory<Mail>, IMailsStore
    {
        public MailsStoreinMemory() : base(Enumerable.Range(1, 10).Select(i => new Mail { Id = i, Subject = $"Message {i}", Body = $"Message body {i}" }).ToList())
        {

        }
        public override void Edit(int id, Mail mail)
        {
            var db_mail = GetById(id);
            if (db_mail is null) return;

            db_mail.Subject = mail.Subject;
            db_mail.Body = mail.Body;
        }

    }
}
