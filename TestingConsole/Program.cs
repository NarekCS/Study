using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Text;
using System.IO;
using System.Dynamic;
using Newtonsoft.Json;
using DateTimeList = System.Collections.Generic.List<System.DateTime>;
using System.Linq;
using Testing;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Diagnostics.Contracts;
using System.Runtime;
using System.IO.Ports;
using Microsoft.Win32.SafeHandles;
using System.Numerics;
using System.Security.Policy;
using Samples;
using System.Threading.Tasks;
using System.Net.Http;

[assembly: InternalsVisibleTo("mscorelib")]
namespace TestingConsole
{
    interface ITrtt
    {
        interface IYgui
        {
            static int Age { get; set; }
            //int Some { get; set; }
        }
        class A
        {
            public static int Something { get; set; }
        }
        int Name { get; set; }
    }
    public class SomeClass : ITrtt
    {
        public int Name { get => ITrtt.IYgui.Age; set => _ = ITrtt.A.Something; }
    }
    class SClass : ITrtt.IYgui
    {
        public SClass()
        {

        }
        // public int Some { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    abstract class D
    {
        string s;
    }
    class Some
    {
        Timer t;
        public Some()
        {
            t = new Timer(TimerCallback, null, 0, 1000);
        }
        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Force a garbage collection to occur for this demo.   
            GC.Collect();
        }
        public void Start()
        {

        }
    }
    struct Employer
    {
        public int Age;
    }
    class Human
    {
        public static int Age = 10;
        static Human()
        {
            Console.WriteLine("Human: " + Age.ToString());
        }
    }
    class Person : Human
    {
        public string SomeString { get; set; }
        readonly int s;
        public static int something;
        static Person()
        {
            Age = 90;
            Console.WriteLine("Person: " + Age.ToString());
        }
        public Employer Employer;
        public int Id;
        public void Method()
        {
            Age = 90;
            throw new DivideByZeroException();
            // Console.WriteLine(Id);
        }
        public Person(int x)
        {
            Age = 99;
            Id = x;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            return ((Person)obj).Id == Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    internal interface IChangeBoxedPoint
    {
        void Change(Int32 x, Int32 y);
    }
    struct Structure : IChangeBoxedPoint
    {
        static Structure()
        {

        }
        public int x;
        public int y;
        public int MyProperty;
        public Structure(int x, int y)
        {
            this.x = x;
            this.y = y;
            MyProperty = 10;
        }
        public override string ToString()
        {
            return x.ToString() + ", " + y.ToString();
        }
        public void Change(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    //unsafe struct CharArray
    //{
    //    public fixed Char Characters[20];
    //}
    class Att : Attribute
    {
        public Att()
        {

        }
        public Att(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public object Person { get; set; }
    }
    enum Roles
    {
        Admin,
        Manager
    }
    partial class Program
    {
        private static void ComparingAGenericTypeVariableWithNull<T>(T obj) { if (obj == null) { /* Never executes for a value type */ } }
        public static Dictionary<long, (int id, bool isVerified)> dict = new Dictionary<long, (int id, bool isVerified)>();
        public int Name { get; set; }
        partial void someMeth(string s);
        static Person Change(Person p)
        {
            Object o = new Object();
            p.Id = 90;
            return p;
        }
        static int MethodInt()
        {
            try
            {
                return 9;
                throw new Exception("error");
            }
            finally
            {
                Console.WriteLine("ok");
            }
        }
        static void M()
        {
            byte b = 90;
            b = (byte)(b + 1000);
            Console.WriteLine(b);
        }
        static List<int> GetMax(List<int> list)
        {
            int one = 0;
            int two = 0;
            int three = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > three)
                {
                    if (list[i] > two)
                    {
                        if (list[i] > one)
                        {
                            three = two;
                            two = one;
                            one = list[i];
                        }
                        else
                        {
                            three = two;
                            two = list[i];
                        }
                    }
                    else
                        three = list[i];
                }
            }
            return new List<int> { one, two, three };
        }
        static int Method(double x, string s = "s", Structure st = default(Structure), int y = 90, params string[] str)
        {

            switch (x)
            {
                default:
                    Console.WriteLine("hello");
                    break;
                case 1:
                    return 56;
                case 2:
                    return 50;
            }
            return 0;
        }
        internal sealed class SomeType { public Int32 m_val; }
        private static object GetAnObject(Object o) { o = new String('X', 100); return o; }
        static void Out(out string s) => s = "Hello !";
        static (int age, string name) VT() => (8, "Jacob");
        private static void Swap<T>(ref T o1, ref T o2) { T temp = o1; o1 = o2; o2 = temp; }
        //private unsafe static void DisplaySecureString(SecureString ss)
        //{
        //    Char* pc = null; try
        //    {
        //        pc = (Char*)Marshal.SecureStringToCoTaskMemUnicode(ss);

        //        for (Int32 index = 0; pc[index] != 0; index++)
        //            Console.Write(pc[index]);
        //    }
        //    finally
        //    {

        //        if (pc != null) Marshal.ZeroFreeCoTaskMemUnicode((IntPtr)pc);
        //    }
        //}
        static String SomeMethod(Stream s) => "";
        delegate TResult Del<T, TResult>(T s);
        static void MethodAction(Action<int> action) => action(3);
        static bool Contains(string name) => name.Contains('a');
        static int rec(int a)
        {
            RuntimeHelpers.EnsureSufficientExecutionStack();
            return a * rec(a);
        }
        unsafe public static void Go()
        {
            for (Int32 x = 0; x < 10000; x++) new Object();
            IntPtr originalMemoryAddress;
            Byte[] bytes = new Byte[1000];
            fixed (Byte* pbytes = bytes)
            {
                originalMemoryAddress = (IntPtr)pbytes;

            }
            GC.Collect();

            fixed (Byte* pbytes = bytes)
            {
                Console.WriteLine("The Byte[] did{0} move during the GC", (originalMemoryAddress == (IntPtr)pbytes) ? " not" : null);
            }
            new Thread(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine(bytes.Length);
            }
            ).Start();
        }
        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Force a garbage collection to occur for this demo.   
            //GC.Collect();
        }
        // [HandleProcessCorruptedStateExceptions]
        // [SecurityCritical]
        public static int NumOffices(char[][] grid)
        {
            int result = 0;
            List<Tuple<int, int, int>> list = new List<Tuple<int, int, int>>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    int count = 0;
                    if (grid[i][j] == '1')
                    {
                        count++;
                    }
                    else
                    {
                        if (count != 0)
                        {
                            list.Add(Tuple.Create(i, j - count, count));
                            count = 0;
                        }
                    }
                    if (j == grid[0].Length - 1 && count != 0)
                    {
                        list.Add(Tuple.Create(i, j - count, count));
                    }
                }
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                //if(list[i+1].Item1-list[i].Item1 && 
            }
            // place your code here

            return result;
        }


        public static int MinimumConcat(string initial, string goal)
        {
            // Place your code here
            int c = 0;
            int k = initial.IndexOf(goal[0]);
            for (int i = 1; i < goal.Length; i++)
            {


                if (initial.IndexOf(goal[i], k) < k)
                {
                    c++;

                }

                k = initial.IndexOf(goal[i]);
                if (k == -1)
                {
                    return k;
                }

            }
            return c + 1;
        }

        //int m = initial.Length;
        //int n = goal.Length;
        //if (m == 0)
        //    return 1;
        //if (n == 0)
        //    return 0;

        //// If last characters of two strings 
        //// are matching 
        //if (initial[m - 1] == str2[n - 1])
        //    return isSubSequence(initial, str2,
        //                            m - 1, n - 1);

        //// If last characters are not matching 
        //return isSubSequence(initial, initial, m, n - 1);





        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
            



        static void Main(string[] args)
        {
            string key = "$%RFVHDE&dege6wef&^6dfegf)&8:'!@";
            string test = "Hello world";

            Console.WriteLine(EncryptString(key, test));
            Console.WriteLine(DecryptString(key, EncryptString(key, test)));

           /* DateTime dateTime = DateTime.Now;
            DateTime old = DateTime.Now.AddMinutes(-48);
            var dif = dateTime - old;
            Console.WriteLine(dif);
            Console.WriteLine(dif.TotalHours);*/
            //int t = MinimumConcat("kabkcdk", "abcbcabccdak");
            //Console.WriteLine(t);
            //SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
            //Task.Run(async () =>
            //{
            //    await semaphoreSlim.WaitAsync();
            //    Console.WriteLine("semaphore is taken from task 1");
            //    await Task.Delay(10000);
            //    semaphoreSlim.Release();
            //    Console.WriteLine("semaphore released from task 1");
            //});
            //Thread.Sleep(1000);
            //semaphoreSlim.WaitAsync();
            //Console.WriteLine("semaphore is taken from task 2");
            //semaphoreSlim.Release();
            //Console.WriteLine("semaphore released from task 2");

            //Console.ReadLine();
            //Dictionary<int, string> pairs = new Dictionary<int, string>();
            //pairs.Add(2010, "bmw");
            //pairs.Add(2012, "mers");
            //pairs.Add(2019, "toyota");

            //foreach (var item in pairs.Keys)
            //{
            //    Console.WriteLine(pairs[item]);
            //}

            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            //HttpClient client = new HttpClient();

            //StringContent content = new StringContent("{\"jsonrpc\": \"2.0\",\"method\":\"company\",\"id\": 32123,\"params\": {\"merchant\": \"20537807697644\",\"cashier\": 14999,\"token\": \"76AADD784FF1979A27FCD23EF7837C06\",\"place\": null}}");
            //var result = client.PostAsync("http://alpha-profile.cl.world/api/jsonrpc/v1", content).Result;
            //if (result.IsSuccessStatusCode)
            //{

            //}
            //int i = args.Length;
            //Contract.Requires(args.Length > 0);
            //TextWriterTraceListener textWriterTraceListener = new TextWriterTraceListener(Console.Out);
            //Trace.Listeners.Add(textWriterTraceListener);
            //Trace.WriteLine("sgsh");

            //Task.FromResult(0);
            //NewMEF newMEF = new NewMEF();
            //newMEF.Send("hdhhhgh");

            //AppDomainSetup
            //PermissionSet permissionSet = new PermissionSet(null);
            //Evidence evidence = new Evidence();
            //AppDomain.CreateDomain("");
            //string s = Console.ReadLine();
            //Console.WriteLine(Calculate(s));
            //Go();
            //BigInteger b = new BigInteger(decimal.MaxValue);
            //BigInteger b2 = new BigInteger(decimal.MaxValue);
            //var b3 = b * b2*b2*b2;
            //Console.WriteLine(b3);
            //ConditionalWeakTable<TKey,TValue>
            //WeakReference<T>
            //Person p = new Person(90);
            //GCHandle h = GCHandle.Alloc(p);
            //Console.WriteLine(ReferenceEquals(p, h.Target));
            //GCHandle
            //HandleCollector
            //SafeHandle
            //CriticalHandleZeroOrMinusOneIsInvalid
            //Console.WriteLine(GC.GetTotalMemory(false));

            //Console.WriteLine(GCSettings.IsServerGC);
            //GC.Collect();
            //GC.RegisterForFullGCNotification(99, 99);
            //GC.WaitForFullGCApproach();
            //GC.Collect();
            //GC.WaitForFullGCComplete();
            //GC.CancelFullGCNotification();
            //Console.WriteLine("ok");
            //object s = new Some();
            //s.ToString();
            //Console.ReadLine();

            //Timer t = new Timer(TimerCallback, null, 0, 2000);
            //string s = null;
            //while (true)
            //{
            //    Thread.Sleep(50);
            //    s += "tdudtyuy";
            //}


            #region First20Chapters

            //Contract.Requires(true);

            //RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(Console.WriteLine, (o, b) => Console.WriteLine(), "");
            //Dictionary<string, string> dict = new Dictionary<string, string>();
            //string f = dict[""] ;
            //Person p = new Person(5);
            //try
            //{
            //    rec(90);
            //    //typeof(Person).GetMethod("Method").Invoke(p, null);
            //    // dynamic d = new Person(5);
            //    // d.Method();
            //}
            //catch (InsufficientExecutionStackException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("finally");
            //}

            //string fullName = "Narek Avanesyan".ToLower();
            //string referralLink = (fullName.Substring(0, 1) + fullName.Substring(fullName.IndexOf(' ') + 1)).Replace(" ", string.Empty);
            //Console.WriteLine(referralLink);
            //string number = "navanesyan".Substring(referralLink.Length);
            //int.TryParse(number, out int n);
            //referralLink = referralLink + (n + 1).ToString();
            //Console.WriteLine(referralLink);
            //Person p = new Person(8);
            //Human h = new Person(8);
            //Console.WriteLine(h.Equals(p));
            //int? x = null;
            //x.GetType();
            //Array.ForEach(typeof(int?).GetProperties(), Console.WriteLine);
            //int? x = null;
            //int s = x ?? 89;
            //Console.WriteLine(s);
            //int? x = null;
            //int y = x ?? 90;
            //int z = x.GetValueOrDefault(90);
            //Console.WriteLine($"{y}--{z}");
            //Func<object> f = () => GetAnObject(null) != null ? GetAnObject(null) : new object();
            //decimal? a = 5;
            //int? b = null;
            //if (a == b)            
            //    Console.WriteLine("ok");

            //int? y = new int?();
            //int x = y.GetValueOrDefault();
            //Console.WriteLine(long.MaxValue);

            //IList<CustomAttributeData> list = CustomAttributeData.GetCustomAttributes(typeof(Program));
            //Type t = list[0].NamedArguments[0].TypedValue.ArgumentType;
            //int i = 0;
            //int y = 10;                                   

            //Console.WriteLine(i += ++i);
            //Console.WriteLine(i += ++i);
            //Console.WriteLine(i += ++i);
            //Console.WriteLine(i += ++i);

            //Console.WriteLine(y += y++);
            //Console.WriteLine(y += y++);
            //Console.WriteLine(y += y++);
            //Console.WriteLine(y += y++);

            //int a = (i += i++) > 0 ? (i += i++) > 0 ? i++ : i : (i += i++) > 0 ? i++ : i;
            //Console.WriteLine(a);
            //List<string> names = new List<string> { "Jeff", "Kristin", "Aidan", "Grant" };
            // Array.ForEach(names.ToArray(), Console.WriteLine);
            // names.ForEach(Console.WriteLine);
            // names.Where(Contains);
            //Console.WriteLine(new string("qwerty".Reverse().ToArray()));
            //System.Action a = Console.WriteLine;
            //MethodAction(o => Math.Abs(o));
            //Del<FileStream,object> dl = SomeMethod;
            //var names = new[] { new { name = "Aidan", age = 80 }, new { name = "Grant", age = 90 } };
            //string[] strs = new string[10];
            //object[] objs = new object[4];
            //objs = strs;
            //unsafe
            //{
            //    CharArray ca;
            //    Console.WriteLine(sizeof(CharArray));
            //}

            //List<int> list = new List<int>();
            //int[] ints = new int[10];
            //Array it = Array.CreateInstance(typeof(int), new int[] { 100 }, new int[] { 13 });
            //Console.WriteLine(it.GetValue(16));
            //Console.WriteLine(it.GetType());
            //DayOfWeek d = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), 5);
            //Enum.TryParse("23", out DayOfWeek dayOfWeek);
            //Console.WriteLine(d);
            //TypeCode tc = TypeCode.Boolean;
            //CultureTypes ct = CultureTypes.AllCultures;
            //Console.WriteLine(tc);
            //tc = (TypeCode)ct;
            //Enum e = (Enum)10;
            // Console.WriteLine(e);
            //using (SecureString ss = new SecureString())
            //{
            //    Console.Write("Please enter password: "); while (true)
            //    {
            //        ConsoleKeyInfo cki = Console.ReadKey(true); if (cki.Key == ConsoleKey.Enter) break;

            //        ss.AppendChar(cki.KeyChar);
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();

            //    DisplaySecureString(ss);
            //}
            //Byte[] bytes = new Byte[10];
            //new Random().NextBytes(bytes);
            //Console.WriteLine(BitConverter.ToString(bytes));
            //Console.WriteLine(string.Join("-",bytes));
            //foreach (var item in bytes)           
            //    Console.Write(item.ToString("X") + "-");
            //byte b = 0b01010111;

            //UTF32Encoding uTF32Encoding = new UTF32Encoding();                        
            //Console.WriteLine(Encoding.UTF32.GetEncoder());

            //string s = Convert.ToString(55, 2); 
            //Console.WriteLine(20.ToString("P"));

            //string s = "hello";
            //string st = s;
            //string str = string.Copy(s);
            //Console.WriteLine(ReferenceEquals(s,str));

            //String s = "a\u0304\u0308bc\u0327";
            //StringInfo si = new StringInfo(s);
            //for (int i = 0; i < si.LengthInTextElements; i++)
            //{
            //    Console.WriteLine(si.SubstringByTextElements(i,1));
            //}
            //String s1 = "\u3057\u3093\u304B\u3093\u305b\u3093";
            //String s2 = "\u30b7\u30f3\u30ab\u30f3\u30bb\u30f3";
            //var t = new Thread(() => Console.WriteLine());
            //CultureInfo ci = new CultureInfo("ja-JP");
            //int i = "Asd".CompareTo("Abd");
            //double d = char.GetNumericValue('8');
            //Console.WriteLine(StringComparer.Create(ci, false).GetType());

            //Console.WriteLine(String.Compare(s1, s2, ci, CompareOptions.IgnoreKanaType));
            //DerivedSomeClass ds = new DerivedSomeClass();
            //ds.SomeMethod();
            //SomeClass s = new DerivedSomeClass();
            //s.Dispose();            
            //IEnumerable<Stream> es = new FileStream[12];           
            //IComparable<DerivedSomeClass> ic = new DerivedSomeClass();
            //6.CompareTo(0);
            //DerivedSomeClass ds = new DerivedSomeClass();
            //((IInterface)ds).SomeMethod();
            //DateTimeList dtl = new DateTimeList();
            //var f = VT();
            //Console.WriteLine(f.age);
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine("ասդասդասդֆաֆ");
            //dict[1].MyProperty = 10;
            //Person.something = 10;
            // Person[] ps = new Person[12];
            //Person p = new Person(8);
            //Console.WriteLine(p.Employer.Age);
            //Method(Math.PI);
            //MethodInt();
            //Console.WriteLine(Method(1));

            //int[] ints = { 1, 2, 3, 4, 5, 6 };
            //int k = 0;
            //ints[k++] = ints[k++] * 2;
            //for (int i = 0; i < ints.Length; Console.WriteLine(ints[i++])) ;

            //Console.WriteLine(k);
            //Console.WriteLine(String.Compare("Zoo", "aardavrk"));
            //int result = (int)Calculate("2 * 3");
            //Console.WriteLine(result);
            //dynamic type = typeof(String);
            //dynamic stringType = new StaticMemberDynamicWrapper(type);
            //var r = stringType.Concat("A", "B");  // dynamically invoke String’s static Concat method
            //Console.WriteLine(r);                 // Displays "AB" 
            //dynamic d = 123;
            //var result = M(d);
            //Application excel = new Application();
            //excel.Visible = true;
            //excel.Workbooks.Add(Type.Missing);
            //((Range)excel.Cells[1, 1]).Value = "Text in cell A1";
            //Person p1 = new Person(5);
            //Person p2 = new Person(5);
            //Console.WriteLine(5.Equals(5));
            //Structure p = new Structure(1, 1);
            //Console.WriteLine(p);

            //p.Change(2, 2);
            //Console.WriteLine(p);

            //object o = p;
            //Console.WriteLine(o);

            //((Structure)o).Change(3, 3);
            //Console.WriteLine(o);
            //IChangeBoxedPoint ch = p;
            //ch.Change(10, 10);
            //Console.WriteLine(ch);
            //((IChangeBoxedPoint)p).Change(4, 4);
            //Console.WriteLine(p);

            //((IChangeBoxedPoint)o).Change(5, 5);
            //Console.WriteLine(o);
            //Point p = new Point();
            //p.X = p.Y = 1;
            //object o = p;
            //Structure s;
            //s.data = 12;
            //s.GetHashCode();
            //Console.WriteLine(s.data);
            //Structure? ns = null;           
            //Console.WriteLine(ns.Value);
            //List<int> list = new List<int>();
            //IEnumerable<int> t = list.Where(i => i > 0);
            //BigInteger b = -78;
            //ValueType v = new Structure();
            //int x = ((Structure)v).data;

            //var d = 9000000000000000000m + 9786358690837698037569m;
            //decimal d2 = 9786358690837698037569m;
            //decimal d3 = d + d2;
            //Person p = new Person(6);
            //Type t = p.GetType();
            //Console.WriteLine(x);
            //checked
            //{
            //    M();
            //}

            //Console.WriteLine(b);
            //List<int> list = new List<int> { 11, 20, 3, 14, 5, 36, 7, 8 };
            //var max = GetMax(list);
            //foreach (var item in max)
            //{
            //    Console.WriteLine(item);
            //}
            //object o = new { key = "age", value = 7 };
            //PropertyInfo[] v = o.GetType().GetProperties();
            //foreach (PropertyInfo item in v)           
            //    Console.WriteLine(item.GetValue(o));

            //dynamic d = o;
            //Console.WriteLine(d.key);

            //string url = @"\\10.25.136.8\D\VoiceMessages\dc09e7f1-6968-47aa-bca8-38ebee79228b.3gpp";
            //// byte[] s = File.ReadAllBytes(url);
            //string t = "test jkl";
            //Person p = new Person { Id = 7 };
            //Person p1 = Change(p);

            //Console.WriteLine(p.Id);
            //Console.WriteLine(p == p1);
            //dynamic value;
            //for (Int32 demo = 0; demo < 2; demo++)
            //{
            //    value = (demo == 0) ? (dynamic)5 : "A";
            //    value = value + value;
            //    M(value);
            //}

            #endregion
        }

        private static void M(Int32 n) { Console.WriteLine("M(Int32): " + n); }
        private static void M(String s) { Console.WriteLine("M(String): " + s); }
        static object Calculate(string expression)
        {
            ScriptEngine engine = Python.CreateEngine();
            return engine.Execute(expression);
        }
    }
}
