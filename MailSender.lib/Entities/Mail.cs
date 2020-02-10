using MailSender.lib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    public class Mail : BaseEntity
    {
        //тема письма
        public string Subject { get; set; }
        //тело письма
        public string Body { get; set; }
    }
}
