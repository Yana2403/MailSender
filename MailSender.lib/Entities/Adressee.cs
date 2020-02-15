using MailSender.lib.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    public class Adressee : RersonEntity, IDataErrorInfo
    {
        

        public override string Name
        {
            get => base.Name;
            set
            {
                if (value == "Улендеева321")
                    throw new ArgumentException("Улендеева321 нам не подходит", nameof(value));
                base.Name = value;
            }
        }
        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    default: return null;

                    case nameof(Name):
                        var name = Name;
                        if (name is null) return "Пустая ссылка на имя";
                        if (name.Length < 2) return  "Имя должно быть длиннее двух символов";
                        if (name.Length > 30) return "Длина имени должна быть не больше 30 символов";

                        return null;
                }
            }
        }
        string IDataErrorInfo.Error => null;
    }
}
