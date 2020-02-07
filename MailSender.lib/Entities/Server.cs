using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    public class Server
    {
        /// <summary>Почтовый сервер</summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; } = true;

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
