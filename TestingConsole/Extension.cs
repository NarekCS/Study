using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestingConsole
{
    public static class Extension
    {
       public static IEnumerable<T> Where<T>(this IEnumerable<T> TSource, Func<T, bool> predicate)
        {
            foreach (var item in TSource)
            {
                if(predicate(item))
                yield return item;
            }
        }       
    } 
}
