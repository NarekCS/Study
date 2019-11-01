using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestingConsole;

namespace Testing
{
    public class SomeClass : IDisposable, IInterface
    {
        public Action<int> GetAction() => M;
      static void M(int x)
        {

        }
        public virtual void Dispose()
        {
            Console.WriteLine("Based");
        }

        void Method()
        {
            //TestingConsole.Object o = new TestingConsole.Object();
            //o.MyProperty = "ok";
        }
        public virtual void SomeMethod()
        {
            Console.WriteLine("virtual base");
        }
        void IInterface.SomeMethod()
        {
            Console.WriteLine("explicit base");
        }

        public void NewMethod()
        {
            throw new NotImplementedException();
        }
    }
}
