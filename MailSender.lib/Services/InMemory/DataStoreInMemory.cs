﻿using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Entities.Base;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.InMemory
{
    public abstract class DataStoreInMemory <T> : IDataStore<T> where T : BaseEntity
    {
        private readonly List<T> _Items; //список объектов в памяти

        protected DataStoreInMemory(List<T> Items = null) => _Items = Items ?? new List<T>();

        public IEnumerable<T> GetAll() => _Items; 

        public T GetById(int id) => _Items.FirstOrDefault(item => item.Id == id);

        public int Create(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));//проверка на входе

            if (_Items.Contains(item)) return item.Id;
            item.Id = _Items.Count == 0
                ? 1
                : _Items.Max(r => r.Id) + 1;
            _Items.Add(item);
            return item.Id;
        }

        public abstract void Edit(int id, T item);

        public T Remove(int id)
        {
            var item = GetById(id);
            if (item != null)
                _Items.Remove(item);
            return item;
        }

        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение изменений в хранилище {0}.", typeof(T));
        }
    }
}
