﻿using MailSender.lib.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
   public class Adresser : RersonEntity
    {
        public override string ToString() => $"{Name}:{Address}";
    }
}
