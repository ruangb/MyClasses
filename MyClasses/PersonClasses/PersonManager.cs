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

    }
}
