using System;
using System.Runtime.Serialization;

namespace PersonIO
{
    [Serializable]
    public class Person : ISerializable
    {
        string firstName;
        string lastName;
        DateTime dtBirth = new DateTime(1800, 1, 1);

        public Person(string fn, string ln, DateTime bd)
        {
            firstName = fn;
            lastName = ln;
            dtBirth = bd;
        }

        public override string ToString()
        {
            return " FirstName :" + firstName + " LastName :" + lastName + " BirthDay:" + dtBirth;
        }

        // Implements ISerializable interface.
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AltFirstName", "Katia");
            info.AddValue("AltLastName", "XXX");
        }

        // Add a constructor to enable a deserialization.
        public Person(SerializationInfo info, StreamingContext context)
        {
            firstName = info.GetString("AltFirstName");
            lastName = info.GetString("AltFirstName");
        }
    }
}