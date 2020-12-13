using IC4EGO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Test
{
    public class UCTestFix
    {
        [
            Test,
            TestCase("2020.01.01",true),
            TestCase("március",false),
            TestCase("4",false),
        ]
        public void TestCheckDate(string bedatum, bool expected)
        {
            foUC uc = new foUC();

            var actual = uc.CheckDate(bedatum);

            Assert.AreEqual(expected, actual);
        }
    }
}
