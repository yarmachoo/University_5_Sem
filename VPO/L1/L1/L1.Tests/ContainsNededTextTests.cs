using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1.Tests
{
    [TestClass]
    public class ContainsNededTextTests
    {
        [TestMethod]
        public void TestMethod()
        {
            string str = Task1.Func();

            Assert.IsTrue(str.Contains("Hello world!\nAndhiagain!\n"));
        }
    }
}
