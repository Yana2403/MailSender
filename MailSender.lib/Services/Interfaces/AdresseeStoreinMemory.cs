using MailSender.lib.Data;
using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    public class AdresseeStoreinMemory:IAdresseeStore
    {
        public IEnumerable<Adressee> Get() => TestData.Adressees;
        public void Edit(int id, Adressee adressee)
        {
            //Так как это хранилище данных в памяти, то ничего не делаем
        }
        public void SaveChanges()
        {
            //Так как это хранилище данных в памяти, то ничего не делаем

        }
    }
}
