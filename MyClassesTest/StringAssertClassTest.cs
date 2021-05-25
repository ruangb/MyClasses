using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        public void ConstainsTest()
        {
            string str1 = "Luciano Neves";
            string str2 = "Luciano";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex regex = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("teste lower case true", regex);
        }

        [TestMethod]
        public void IsNotAllLowerCaseTest()
        {
            Regex regex = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Teste lower case false", regex);
        }
    }
}
