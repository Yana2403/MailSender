using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    public interface IAdresseeStore
    {
        IEnumerable<Adressee> GetAll();
        Adressee GetById(int id);
        int Create(Adressee adressee);

        void Edit(int id, Adressee adressee);
        Adressee Remove(int id);
        void SaveChanges();
    }
}
