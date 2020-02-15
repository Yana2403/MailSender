using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Infastractures.Services.Interfaces
{
   public interface IAdresserEditor
    {
        void Edit(Adresser adresser);
    }
}
