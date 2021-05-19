using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests

        [TestMethod]
        [Owner("Ruan")]
        public void AreEqualTest()
        {
            string str1 = "Rodrigo";
            string str2 = "rodrigo";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Ruan")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Rodrigo";
            string str2 = "rodrigo";

            Assert.AreEqual(str1, str2, false);
        }

        #endregion
    }
}
