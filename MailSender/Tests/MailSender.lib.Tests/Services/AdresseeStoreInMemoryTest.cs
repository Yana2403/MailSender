using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Services
{
   public class AdresseeStoreInMemoryTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))] //указание ожидаемого исключения - 1 вариант
        public void Create_throw_ArgumentNullException_if_items_is_null() 
        {
            var store = new AdresseeStoreinMemory();

            store.Create(null);
        }

        [TestMethod] //2 вариант - без указания исключения
        public void Create_throw_ArgumentNullException_if_items_is_null2() 
        {
            var store = new AdresseeStoreinMemory();

            Assert.ThrowsException<ArgumentNullException>(() => store.Create(null));
        }
    }
}
