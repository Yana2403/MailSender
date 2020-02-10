using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class TestEncoderTests //должен быть публичный и не абстрактный
    {
        [TestMethod]
        public void Encode_ABC_to_BCD_with_key_1() //описание сценария тесты
        {
            //A-A-A = Arange(Подготовка данных) -Act(получаем актуальный результат)- Assert -3 этапа
            const string str = "ABC"; //то, что есть
            const int key = 1;
            const string expected_str = "BCD"; //ожидаемое
            var actual_str = TextEncoder.Encode(str, key);

            Assert.AreEqual(expected_str, actual_str); //утверждаем, что значение 1 = значению 2
        }
    }
}
