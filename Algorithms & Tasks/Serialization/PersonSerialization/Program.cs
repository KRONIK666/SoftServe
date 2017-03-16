using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace PersonIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Person st1 = new Person("Iryna", "Kovalska", new DateTime(1983, 5, 17));
            Console.WriteLine(st1);

            // Binary
            BinaryFormatter bFormatter = new BinaryFormatter();
            string bname = "person.dat";
            Serialization(st1, bFormatter, bname);

            // Soap
            SoapFormatter sFormatter = new SoapFormatter();
            string sname = "person.soap";
            Serialization(st1, sFormatter, sname);

            // XML
            PersonXML st2 = new PersonXML("Danylo", "Koval", new DateTime(1980, 12, 11));
            Console.WriteLine(st2);
            XMLSerialization(st2);

            // XML PersonFile serialization
            PersonXML st01 = new PersonXML("Danylo", "Koval", new DateTime(1980, 12, 11));
            PersonXML st02 = new PersonXML("Fronia", "Kos", new DateTime(1983, 2, 14));
            PersonXML st03 = new PersonXML("Sviatek", "Los", new DateTime(1984, 1, 1));

            PersonFile pf = new PersonFile();
            pf.Persons.Add(st01);
            pf.Persons.Add(st02);
            pf.Persons.Add(st03);

            foreach (PersonXML p in pf.Persons)
            {
                Console.WriteLine(p);
            }

            XmlSerializer xmlPersons = new XmlSerializer(typeof(PersonFile));
            Stream serialStream = new FileStream("personlist.xml", FileMode.Create);

            xmlPersons.Serialize(serialStream, pf);
            serialStream.Close();
            Console.Read();
        }

        static void Serialization(Person st1, IFormatter formatter, string streamName)
        {
            // Binary or Soap serialization
            Stream serialStream = new FileStream(streamName, FileMode.Create);
            formatter.Serialize(serialStream, st1);
            serialStream.Close();

            // Binary or Soap deserialization
            Console.WriteLine("Alternative name:");
            serialStream = new FileStream(streamName, FileMode.Open);
            Person st2 = (Person)formatter.Deserialize(serialStream);
            Console.WriteLine(st2);
        }

        static void XMLSerialization(PersonXML st1)
        {
            // XML serialization
            Type t = typeof(PersonXML);
            XmlSerializer xmlser = new XmlSerializer(t);

            Stream serialStream = new FileStream("person.xml", FileMode.Create);
            xmlser.Serialize(serialStream, st1);
            serialStream.Close();

            // XML deserialization
            serialStream = new FileStream("person.xml", FileMode.Open);
            object o = xmlser.Deserialize(serialStream);
            PersonXML st2 = o as PersonXML;
            serialStream.Close();
            Console.WriteLine(st2);
        }
    }
}