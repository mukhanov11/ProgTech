using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("We are in try");
                FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate);
                Console.WriteLine("After creating filestream");
            }
            catch (Exception e)
            {
                Console.WriteLine("Some error: " + e);
            }
            Console.WriteLine("We are here");
            Console.ReadKey();
        }
    }
}
