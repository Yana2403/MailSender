using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MailSender.lib.Data.EF
{
    public class MailSenderDBInitializer
    {
        private readonly MailSenderDB _db;

        public MailSenderDBInitializer(MailSenderDB db) => _db = db;

        public async Task InitializeAsync()
        {
            _db.Database.EnsureCreated();//проверка наличия базы данных
            //_db.Database.Migrate();

            await SeedAsync(_db.Mails).ConfigureAwait(false);
            await SeedAsync(_db.Servers);
            await SeedAsync(_db.Adressers);
            await SeedAsync(_db.Adressees);

            if (!await _db.MailingLists.AnyAsync())
            {
                _db.MailingLists.Add(
                    new MailingList
                    {
                        Name = "Mail list",
                        Adressees = await _db.Adressees.OrderBy(r => r.Id).Take(5).ToArrayAsync()
                    });
                await _db.SaveChangesAsync();
            }

            if (!await _db.SchedulerTasks.AnyAsync())
            {
                _db.SchedulerTasks.Add(new SchedulerTask
                {
                    Time = DateTime.Now.Add(TimeSpan.FromDays(10)),
                    Server = await _db.Servers.FirstOrDefaultAsync(),
                    Adressees = await _db.MailingLists.FirstOrDefaultAsync(),
                    Mail = await _db.Mails.FirstOrDefaultAsync(),
                    Adresser= await _db.Adressers.FirstOrDefaultAsync()
                });

                await _db.SaveChangesAsync();
            }
        }

        private async Task SeedAsync(DbSet<Mail> Mails)
        {
            if (await Mails.AnyAsync().ConfigureAwait(false)) return;

            for (var i = 0; i < 10; i++)
                Mails.Add(new Mail { Subject = $"Письмо {i}", Body = $"Текст письма {i}" });
            await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Server> Servers)
        {
            if (await Servers.AnyAsync()) return;

            for (var i = 0; i < 10; i++)
                Servers.Add(new Server { Name = $"Сервер {i}", Address = $"smtp.server{i}.ru", Login = "login", Password = "pass" });
            await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Adresser> Adressers)
        {
            if (await Adressers.AnyAsync()) return;

            for (var i = 0; i < 10; i++)
                Adressers.Add(new Adresser { Name = $"Отправитель {i}", Address = $"adresser{i}@server.ru" });
            await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Adressee> Adressees)
        {
            if (await Adressees.AnyAsync()) return;

            for (var i = 0; i < 10; i++)
                Adressees.Add(new Adressee { Name = $"Получатель {i}", Address = $"adressee{i}@server.ru" });
            await _db.SaveChangesAsync();
        }
    }
}
