using System;

namespace PersonIO
{
    [Serializable]
    public class PersonXML
    {
        string firstName;
        string lastName;
        DateTime dtBirth = new DateTime(1800, 1, 1);

        public PersonXML(string fn, string ln, DateTime bd)
        {
            firstName = fn;
            lastName = ln;
            dtBirth = bd;
        }

        public override string ToString()
        {
            return " FirstName :" + firstName + " LastName :" + lastName + " BirthDay:" + dtBirth;
        }

        public PersonXML()
        {
            Console.WriteLine("Inside default constructor");
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime BirthDate
        {
            get { return dtBirth; }
            set { dtBirth = value; }
        }
    }
}