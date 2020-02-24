using MailSender.lib.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.EF
{
    public class MailSenderDB: DbContext
    {
        public DbSet<Mail> Mails { get; set; }

        public DbSet<Adresser> Senders { get; set; }

        public DbSet<Adressee> Recipients { get; set; }

        public DbSet<Server> Servers { get; set; }

        public DbSet<MailingList> MailingLists { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public MailSenderDB(DbContextOptions<MailSenderDB> opt) : base(opt) { }
    }
}
