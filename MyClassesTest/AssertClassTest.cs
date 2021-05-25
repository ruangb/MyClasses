using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests

        [TestMethod]
        [Owner("Ruan")]
        public void AreEqualTest()
        {
            string str1 = "Rodrigo";
            string str2 = "Rodrigo";

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

        #region AreSame/AreNotSame Tests

        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        #endregion

        #region IsIstanceOfType Test

        [TestMethod]
        [Owner("Ruan")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mng = new PersonManager();

            Person per = mng.CreatePerson("Reinaldo", "Silva", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Ruan")]
        public void IsNullTest()
        {
            PersonManager mng = new PersonManager();

            Person per = mng.CreatePerson("", "Silva", true);

            Assert.IsNull(per);
        }

        #endregion
    }
}
