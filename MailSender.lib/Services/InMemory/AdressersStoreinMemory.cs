using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.InMemory;

namespace MailSender.lib.Services.Interfaces
{
    public class AdressersStoreinMemory : DataStoreInMemory<Adresser>, IAdressersStore
    {
        public AdressersStoreinMemory() : base(TestData.Adressers) { }
        public override void Edit(int id, Adresser adresser)
        {
            var db_adresser = GetById(id);
            if (db_adresser is null) return;

            db_adresser.Name = adresser.Name;      
            db_adresser.Address = adresser.Address;
        }

    }
}
