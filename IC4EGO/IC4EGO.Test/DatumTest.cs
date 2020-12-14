using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC4EGO.Test
{
    public class DatumTest
    {
        [
            Test,
            TestCase("2020.02.02",true),
            TestCase("Március",false),
            TestCase("3",false)
        ]
        public void TestCheckDate(string datumstring, bool expected)
        {
            //Arrange
            Datum datum = new Datum();
            //Act
            var actual = datum.CheckDate(datumstring);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
