using MailSender.lib.Data;
using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities.Base;
using MailSender.lib.Services.InMemory;

namespace MailSender.lib.Services.Interfaces
{
    public class AdresseeStoreinMemory : DataStoreInMemory<Adressee>, IAdresseesStore
    {
        public AdresseeStoreinMemory():base(TestData.Adressees) { }
        public override void Edit(int id, Adressee adressee)
        {
            var db_adressee = GetById(id);
            if (db_adressee is null) return;

            db_adressee.Name = adressee.Name;       // Притворяемся, что мы работаем не с объектами в памяти, а с объектам в БД
            db_adressee.Address = adressee.Address;
        }

    }
}
