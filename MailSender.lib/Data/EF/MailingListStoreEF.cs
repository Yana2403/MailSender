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
   public class MailingListStoreEF : StoreEF<MailingList>, IMailingListsStore
    {
        public MailingListStoreEF(MailSenderDB db) : base(db) { } //передача контекста дальше

        public override void Edit(int id, MailingList item) //редактирование данных письма
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Adressees = item.Adressees;
            db_item.Name = item.Name;
            db_item.Id = item.Id;
        }
    }
}
