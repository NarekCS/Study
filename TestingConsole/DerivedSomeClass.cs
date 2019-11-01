using System;
using System.Collections.Generic;
using System.Text;
using Testing;

namespace TestingConsole
{
    public class DerivedSomeClass : SomeClass, IDisposable, IComparable<DerivedSomeClass>, IInterface
    {
        public int CompareTo(DerivedSomeClass other)
        {
            throw new NotImplementedException();
        }
        public override void Dispose()
        {
            Console.WriteLine("derived");
        }
        public override void SomeMethod()
        {
            //((IInterface)this).SomeMethod();
            Console.WriteLine("override derived");
        }
        //void IInterface.SomeMethod()
        //{
        //    Console.WriteLine("explicit derived");
        //}
        int IComparable<DerivedSomeClass>.CompareTo(DerivedSomeClass other)
        {
            throw new NotImplementedException();
        }
    }
}
