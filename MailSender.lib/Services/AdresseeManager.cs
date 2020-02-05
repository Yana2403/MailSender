using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
   public  class AdresseeManager
    {
        private AdresseeStoreinMemory _Store;
        public AdresseeManager(AdresseeStoreinMemory Store)
        {
            _Store = Store;
        }


        public IEnumerable<Adressee> GetAll()
        {
            return _Store.Get();
        }
        public void Add (Adressee NewAdressee)
        {

        }
        //Edit adressee
        //Delete adressee
    }
}
