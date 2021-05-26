using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        public void AreCollectionEqualFailsBecauseNoComparerTest()
        {
            PersonManager mng = new PersonManager();

            List<Person> peopleExpected = new List<Person>(); 
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person { FirstName = "João", LastName = "Miranda" });
            peopleExpected.Add(new Person { FirstName = "Anderson", LastName = "Hernanes" });
            peopleExpected.Add(new Person { FirstName = "Daniel", LastName = "Alves" });

            peopleActual = peopleExpected;

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }
    }
}
