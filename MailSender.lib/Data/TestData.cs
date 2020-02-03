using MailSender.lib.Entities;
using MailSender.lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server { Name = "Яндекс", Adress = " smtp.yandex.ru", Port = 587, Login = "UserLogin", Password = "Password".Encode(3)},
            new Server { Name = "Mail.ru", Adress = " smtp.mail.ru", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
            new Server { Name = "GMail", Adress = " smtp.gmail.com", Port = 587, Login = "UserLogin", Password = "Password".Encode(3) },
        };

        public static List<Adresser> Adressers { get; } = new List<Adresser>
        {
            new Adresser { Name = "Улендеева Яна", Address = "ulendeeva.yana2013@yandex.ru" },
            new Adresser{ Name = "Соболева Юлия", Address = "sobolevai63@mail.ru" },
            new Adresser { Name = "Группа ИЭУ", Address = "ieu7151@yandex.ru" },
        };

        public static List<Adressee> Adressees { get; } = new List<Adressee>
        {
            new Adressee { Name = "Улендеева Яна", Address = "ulendeeva.yana2013@yandex.ru" },
            new Adressee{Name = "Соболева Юлия", Address = "sobolevai63@mail.ru" },
            new Adressee { Name = "Группа ИЭУ", Address = "ieu7151@yandex.ru" },
        };
    }
}
