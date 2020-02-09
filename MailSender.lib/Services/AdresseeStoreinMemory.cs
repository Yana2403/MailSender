using MailSender.lib.Data;
using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    public class AdresseeStoreinMemory : IAdresseeStore
    {
        public void Edit(int id, Adressee adressee)
        {
            var db_adressee = GetById(id);
            if (db_adressee is null) return;

            db_adressee.Name = adressee.Name;       // Притворяемся, что мы работаем не с объектами в памяти, а с объектам в БД
            db_adressee.Address = adressee.Address;
        }
        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение изменений в системе получателей писем.");
            //Так как это хранилище данных в памяти, то ничего не делаем

        }

        public IEnumerable<Adressee> GetAll() => TestData.Adressees;

        public Adressee GetById(int id) => TestData.Adressees.FirstOrDefault(r => r.Id == id);

        public int Create(Adressee adressee)
        {
            if (TestData.Adressees.Contains(adressee)) return adressee.Id;
            adressee.Id = TestData.Adressees.Count == 0
                ? 1
                : TestData.Adressees.Max(r => r.Id) + 1; //Если нет id то присваеваем 1, если есть то +1
            TestData.Adressees.Add(adressee);
            return adressee.Id;
        }

        public Adressee Remove(int id)
        {
            var db_adressee = GetById(id);
            if (db_adressee != null)
                TestData.Adressees.Remove(db_adressee);
            return db_adressee; 
        }
    }
}
