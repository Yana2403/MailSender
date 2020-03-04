using MailSender.lib.Entities;
using MailSender.lib.Services.EF;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.EF
{
    class SchedulerTaskStoreEF : StoreEF<SchedulerTask>, ISchedulerTasksStore
    {
        public SchedulerTaskStoreEF(MailSenderDB db) : base(db) { } //передача контекста дальше
        public override void Edit(int id, SchedulerTask item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Id = item.Id;
            db_item.Mail = item.Mail;
            db_item.Adressees = item.Adressees;
            db_item.Adresser = item.Adresser;
            db_item.Server = item.Server;
            db_item.Time = item.Time;
        }
    }
}
