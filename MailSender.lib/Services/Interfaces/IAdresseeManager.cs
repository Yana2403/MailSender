using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    public interface IAdresseeManager
    {
        IEnumerable<Adressee> GetAll();
        void Add(Adressee NewAdressee);
        void Edit(Adressee NewAdressee);
        void SaveChanges();
    }
}
