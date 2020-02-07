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
        IEnumerable<Adressee> Get();
        void Edit(int id, Adressee adressee);
        void SaveChanges();
    }
}
