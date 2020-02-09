using MailSender.lib.Entities;
using MailSender.lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server {Id=0, Name = "Яндекс", Address = " smtp.yandex.ru", Port = 587, Login = "UserLogin", Password = "Password".Encode(3)},
            new Server {Id=1, Name = "Mail.ru", Address = " smtp.mail.ru", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
            new Server {Id=2, Name = "GMail", Address = " smtp.gmail.com", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
        };

        public static List<Adresser> Adressers { get; } = new List<Adresser>
        {
            new Adresser {Id=0, Name = "Улендеева Яна", Address = "ulendeeva.yana2013@yandex.ru" },
            new Adresser{ Id=1,Name = "Соболева Юлия", Address = "sobolevai63@mail.ru" },
            new Adresser {Id=2, Name = "Группа ИЭУ", Address = "ieu7151@yandex.ru" },
        };

        public static List<Adressee> Adressees { get; } = new List<Adressee>
        {
            new Adressee {Id=0, Name = "Улендеева Яна", Address = "ulendeeva.yana2013@yandex.ru" },
            new Adressee{Id=1,Name = "Соболева Юлия", Address = "sobolevai63@mail.ru" },
            new Adressee {Id=2, Name = "Группа ИЭУ", Address = "ieu7151@yandex.ru" },
        };
    }
}
