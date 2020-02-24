using MailSender.lib.Data.EF;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.EF
{
    public class AdresseeStoreEF : IAdresseesStore
    {
        private readonly MailSenderDB _db;

        public AdresseeStoreEF(MailSenderDB db) => _db = db;
        public int Create(Adressee item)
        {
            _db.Adressees.Add(item);
            SaveChanges();
            return item.Id;
        }

        public void Edit(int id, Adressee item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);
            db_item.Name = item.Name;
            db_item.Address = item.Address;
            SaveChanges();
        }

        public IEnumerable<Adressee> GetAll() => _db.Adressees.AsEnumerable();


        public Adressee GetById(int id) => _db.Adressees.FirstOrDefault(r => r.Id == id);

        public Adressee Remove(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return null;
            //_db.Adresses.Remove(db_item);
            _db.Entry(db_item).State = EntityState.Deleted;
            SaveChanges();
            return db_item;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
