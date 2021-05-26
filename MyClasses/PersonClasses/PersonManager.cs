using System;
using System.Collections.Generic;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string firstName, string lastName, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(firstName))
            {
                if (isSupervisor)
                    ret = new Supervisor();
                else
                    ret = new Employee();

                ret.FirstName = firstName;
                ret.LastName = lastName;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person { FirstName = "João", LastName = "Miranda" });
            people.Add(new Person { FirstName = "Anderson", LastName = "Hernanes" });
            people.Add(new Person { FirstName = "Daniel", LastName = "Alves" });

            return people;
        }
    }
}
