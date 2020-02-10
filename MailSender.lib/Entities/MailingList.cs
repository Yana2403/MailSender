using MailSender.lib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    public class MailingList : NamedEntity
    {
       //список получателей
        public IEnumerable<Adressee> Adressees { get; set; } = new List<Adressee>();

        //задания для планировщика
      
    }
}
