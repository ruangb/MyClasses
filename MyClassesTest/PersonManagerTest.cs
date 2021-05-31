using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("Ruan")]
        public void DoEmployeeExistTest()
        {
            Supervisor super = new Supervisor();

            super.Employees = new List<Employee>();

            super.Employees.Add(new Employee() { FirstName = "Ruan", LastName = "Barros" });

            Assert.IsTrue(super.Employees.Count > 0);
        }
    }
}
