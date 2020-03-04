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
    public class AdresseesStoreEF : StoreEF<Adressee>, IAdresseesStore
    {
        public AdresseesStoreEF(MailSenderDB db) : base(db) { } //передача контекста дальше
        public override void Edit(int id, Adressee item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Id = item.Id;
            db_item.Name = item.Name;
            db_item.Address = item.Address;
        }
    }

}
