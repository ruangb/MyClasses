using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("Ruan")]
        public void AreCollectionEqualFailsBecauseNoComparerTest()
        {
            PersonManager mng = new PersonManager();

            List<Person> peopleExpected = new List<Person>(); 
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person { FirstName = "João", LastName = "Miranda" });
            peopleExpected.Add(new Person { FirstName = "Anderson", LastName = "Hernanes" });
            peopleExpected.Add(new Person { FirstName = "Daniel", LastName = "Alves" });

            peopleActual = mng.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("Ruan")]
        public void AreCollectionEqualWithComparerTest()
        {
            PersonManager mng = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person { FirstName = "João", LastName = "Miranda" });
            peopleExpected.Add(new Person { FirstName = "Anderson", LastName = "Hernanes" });
            peopleExpected.Add(new Person { FirstName = "Daniel", LastName = "Alves" });

            peopleActual = mng.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual, Comparer<Person>.Create((x, y) 
                => x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }

        [TestMethod]
        [Owner("Ruan")]
        public void AreCollectionEquivalentTest()
        {
            PersonManager mng = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mng.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("Ruan")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager mng = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mng.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }
    }
}
