using MailSender.lib.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    public class SchedulerTask : BaseEntity
    {
        //время выполнения задания
        public DateTime Time { get; set; }
        //от кого
        public Adresser Adresser { get; set; }
        //кому
        public MailingList Adressees { get; set; }
        //сервер
        public Server Server { get; set; }
        //письмо
        public Mail Mail { get; set; }
        //вложения письма
       // public ICollection Attachments { get; set; } = new List<MailAttachment>();
    }
}
