using System;
using System.Collections.Generic;

namespace PersonIO
{
    public class PersonFile
    {
        DateTime dtCreation = DateTime.Now;
        List<PersonXML> persons = new List<PersonXML>();

        public DateTime CreatingDate
        {
            get { return dtCreation; }
            set { dtCreation = value; }
        }

        public List<PersonXML> Persons
        {
            get { return persons; }
            set { persons = value; }
        }
    }
}