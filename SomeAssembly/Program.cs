using System;
using System.Globalization;
using System.Text;
using TestingConsole;

namespace SomeAssembly
{
    class SomeClass : IInterface
    {
        public void NewMethod()
        {
            throw new NotImplementedException();
        }

        public void SomeMethod()
        {
            Console.WriteLine("Ok");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char cat = '\u0121';
            Console.OutputEncoding = Encoding.UTF8;
            char c = 'y';
            unchecked { byte b = (byte)'ճ'; Console.WriteLine(b); }
            Console.WriteLine('y' == 121);
            Convert.ToBoolean('y');
           
        }
    }
}
