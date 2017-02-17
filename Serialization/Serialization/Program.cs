using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{

    public class Person
    {
        public string name;
        public int age;

        public Person ()
        {
        }
        public Person (string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return name + ", " + age + " years old";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person("Almaz", 18);
            //mySerialize(person);
            Person person = myDeserialize();
            Console.WriteLine(person);
            Console.ReadKey();
        }

        static Person myDeserialize()
        {
            BinaryFormatter xs = new BinaryFormatter();
            FileStream fs = new FileStream(
                "data.txt", FileMode.Open, FileAccess.Read);
            Person person = (Person)xs.Deserialize(fs);
            fs.Close();
            return person;
        }

        static void mySerialize(Person person)
        {
            BinaryFormatter xs = new BinaryFormatter();
            FileStream fs = new FileStream(
                "data.txt", FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                xs.Serialize(fs, person);
            } catch (Exception e)
            {
                Console.WriteLine("Error while serializing: " + e);
            }
            fs.Close();
        }
    }
}
