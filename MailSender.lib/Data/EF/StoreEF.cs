using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MailSender.lib.Data.EF;
using MailSender.lib.Entities.Base;
using MailSender.lib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MailSender.lib.Services.EF
{
    public abstract class StoreEF<T> : IDataStore<T> where T : BaseEntity
    {
        private readonly MailSenderDB _db;
        private readonly DbSet<T> _Set;

        protected StoreEF(MailSenderDB db) //сохранение контекста базы данных
        {
            _db = db;
            _Set = db.Set<T>(); //получение доступа к таблице
        }

        public IEnumerable<T> GetAll() => _Set.AsEnumerable();

        //public T GetById(int id) => _Set.FirstOrDefault(entity => entity.Id == id); //вариант 1
        public T GetById(int id) => _Set.Find(id); //вариант 2

        public int Create(T item) //добавляет элемент в таблицу и возвращает идентификатор
        {
            _Set.Add(item);
            return item.Id;
        }

        public abstract void Edit(int id, T item);

        public T Remove(int id)
        {
            var db_item = GetById(id);
            if (db_item != null)
                _db.Entry(db_item).State = EntityState.Deleted;

            return db_item;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
