using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
   public  class AdresseeManager : IAdresseeManager
    {
        private IAdresseeStore _Store;
        public AdresseeManager(IAdresseeStore Store)
        {
            _Store = Store;
        }


        public IEnumerable<Adressee> GetAll()
        {
            return _Store.GetAll();
        }
        public void Add (Adressee NewAdressee)
        {

        }
        public void Edit(Adressee adressee)
        {
            _Store.Edit(adressee.Id, adressee);
        }
        //Delete adressee
        public void SaveChanges()
        {
            _Store.SaveChanges();
        }
    }
}
