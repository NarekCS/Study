using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReflectionAndAssemblyLoading
{
    [Serializable]
    class Car { }
    [Serializable]
    class Person : ISerializable
    {
        public int Age { get; set; }

        [SecurityCritical]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(Car));
        }
    }

    static class Program
    {
        private static Int32 Sum(CancellationToken ct, Int32 n)
        {
            Int32 sum = 0; for (; n > 0; n--)
            {

                // The following line throws OperationCanceledException when Cancel   
                // is called on the CancellationTokenSource referred to by the token   
                ct.ThrowIfCancellationRequested();

                checked { sum += n; }   // if n is large, this will throw System.OverflowException   
            }
            return sum;
        }
        static void Cancel(CancellationToken token) { Console.WriteLine(token.IsCancellationRequested); }
        static void M(object o) { Console.WriteLine("thread"); }
        static Action MakeFunc()
        {
            string name = "Mozilla";
            return new Action(() => Console.WriteLine(name));
        }
        public static TDelegate CreateDelegate<TDelegate>(this MethodInfo mi, Object target = null) where TDelegate : Delegate
        {
            return (TDelegate)mi.CreateDelegate(typeof(TDelegate), target);
        }
        static ushort CRC16_Calculate(byte[] buff)
        {
            ushort[] crc16tab = new ushort[256]{ 0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50a5, 0x60c6, 0x70e7, 0x8108, 0x9129, 0xa14a, 0xb16b, 0xc18c, 0xd1ad, 0xe1ce, 0xf1ef, 0x1231, 0x0210, 0x3273, 0x2252, 0x52b5, 0x4294, 0x72f7, 0x62d6, 0x9339, 0x8318, 0xb37b, 0xa35a, 0xd3bd, 0xc39c, 0xf3ff, 0xe3de, 0x2462, 0x3443, 0x0420, 0x1401, 0x64e6, 0x74c7, 0x44a4, 0x5485, 0xa56a, 0xb54b, 0x8528, 0x9509, 0xe5ee, 0xf5cf, 0xc5ac, 0xd58d, 0x3653, 0x2672, 0x1611, 0x0630, 0x76d7, 0x66f6, 0x5695, 0x46b4, 0xb75b, 0xa77a, 0x9719, 0x8738, 0xf7df, 0xe7fe, 0xd79d, 0xc7bc, 0x48c4, 0x58e5, 0x6886, 0x78a7, 0x0840, 0x1861, 0x2802, 0x3823, 0xc9cc, 0xd9ed, 0xe98e, 0xf9af, 0x8948, 0x9969, 0xa90a, 0xb92b, 0x5af5, 0x4ad4, 0x7ab7, 0x6a96, 0x1a71, 0x0a50, 0x3a33, 0x2a12, 0xdbfd, 0xcbdc, 0xfbbf, 0xeb9e, 0x9b79, 0x8b58, 0xbb3b, 0xab1a, 0x6ca6, 0x7c87, 0x4ce4, 0x5cc5, 0x2c22, 0x3c03, 0x0c60, 0x1c41, 0xedae, 0xfd8f, 0xcdec, 0xddcd, 0xad2a, 0xbd0b, 0x8d68, 0x9d49, 0x7e97, 0x6eb6, 0x5ed5, 0x4ef4, 0x3e13, 0x2e32, 0x1e51, 0x0e70, 0xff9f,0xefbe, 0xdfdd, 0xcffc, 0xbf1b, 0xaf3a, 0x9f59, 0x8f78, 0x9188, 0x81a9, 0xb1ca, 0xa1eb, 0xd10c, 0xc12d, 0xf14e, 0xe16f, 0x1080, 0x00a1, 0x30c2, 0x20e3, 0x5004, 0x4025, 0x7046, 0x6067, 0x83b9, 0x9398, 0xa3fb, 0xb3da, 0xc33d, 0xd31c, 0xe37f, 0xf35e,
0x02b1, 0x1290, 0x22f3, 0x32d2, 0x4235, 0x5214, 0x6277, 0x7256, 0xb5ea, 0xa5cb, 0x95a8, 0x8589, 0xf56e, 0xe54f, 0xd52c, 0xc50d, 0x34e2, 0x24c3, 0x14a0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405, 0xa7db, 0xb7fa, 0x8799, 0x97b8, 0xe75f, 0xf77e, 0xc71d, 0xd73c, 0x26d3, 0x36f2, 0x0691, 0x16b0, 0x6657, 0x7676, 0x4615, 0x5634, 0xd94c, 0xc96d, 0xf90e, 0xe92f, 0x99c8, 0x89e9, 0xb98a, 0xa9ab, 0x5844, 0x4865, 0x7806, 0x6827, 0x18c0, 0x08e1, 0x3882, 0x28a3, 0xcb7d, 0xdb5c, 0xeb3f, 0xfb1e, 0x8bf9, 0x9bd8, 0xabbb, 0xbb9a, 0x4a75, 0x5a54, 0x6a37, 0x7a16, 0x0af1, 0x1ad0, 0x2ab3, 0x3a92, 0xfd2e, 0xed0f, 0xdd6c, 0xcd4d, 0xbdaa, 0xad8b, 0x9de8, 0x8dc9, 0x7c26, 0x6c07, 0x5c64, 0x4c45, 0x3ca2, 0x2c83, 0x1ce0, 0x0cc1, 0xef1f, 0xff3e, 0xcf5d, 0xdf7c, 0xaf9b, 0xbfba, 0x8fd9, 0x9ff8, 0x6e17, 0x7e36, 0x4e55, 0x5e74, 0x2e93, 0x3eb2, 0x0ed1, 0x1ef0
};

            ushort crc16 = 0;
            for (int i = 0; i < buff.Length; i++)
            {
                crc16 = (ushort)((crc16 << 8) ^ crc16tab[((crc16 >> 8) ^ buff[i++]) & 0xff]);
            }
            return crc16;
        }
        public static async Task Go2()
        {
#if DEBUG    // Using TaskLogger incurs a memory and performance hit; so turn it on in debug builds   
            TaskLogger.LogLevel = TaskLogger.TaskLogLevel.Pending;
#endif

            // Initiate 3 task; for testing the TaskLogger, we control their duration explicitly  
            var tasks = new List<Task> {
                    Task.Delay(2000).Log("2s op"),
                    Task.Delay(5000).Log("5s op"),
                    Task.Delay(6000).Log("6s op")
            };

            try
            {       // Wait for all tasks but cancel after 3 seconds; only 1 task above should complete in time  
                    // Note: WithCancellation is my extension method described later in this chapter 
                await Task.WhenAll(tasks).WithCancellation(new CancellationTokenSource(3000).Token);
            }
            catch (OperationCanceledException) { }

            // Ask the logger which tasks have not yet completed and sort  
            // them in order from the one that’s been waiting the longest   
            foreach (var op in TaskLogger.GetLogEntries().OrderBy(tle => tle.LogTime))
                Console.WriteLine(op);
        }
        private static async void ShowExceptions()
        {
            var eventAwaiter = new EventAwaiter<FirstChanceExceptionEventArgs>();
            AppDomain.CurrentDomain.FirstChanceException += eventAwaiter.EventRaised;

            while (true) { Console.WriteLine("AppDomain exception: {0}", (await eventAwaiter).Exception.GetType()); }
        }
        public static void Go3()
        {
            ShowExceptions();

            for (Int32 x = 0; x < 3; x++)
            {
                try
                {
                    switch (x)
                    {
                        case 0:
                            throw new InvalidOperationException();
                        case 1:
                            throw new ObjectDisposedException("");
                        case 2:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch { }
            }
        }
        static void CheckSum(byte[] array)
        {
            byte checkSum = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                checkSum ^= array[i];
            }
            array[array.Length - 1] = checkSum;
        }
        public enum Roles
        {
            Guest,
            Customer,
            Trainer,
            Manager,
            Admin
        }
        static void Main(string[] args)
        {
  
            //ConcurrentExclusiveSchedulerPair
            //SemaphoreSlim
            //Barrier
            //CountdownEvent
            //ReaderWriterLockSlim
            //SpinWait
            //var a = Enum.GetNames(typeof(Roles));
            //Console.WriteLine(a.GetType());
            //bool createdNew;
            //new Semaphore(0, 1, "", out createdNew);
            //WaitHandle
            //SpinLock
            //Thread.SpinWait(1000);
            //Thread.Yield();
            //Task.Yield();
            //SpinWait

            //File.Create("", 1000, FileOptions.Asynchronous);
            //FileStream fileStream = new FileStream("", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1, FileOptions.Asynchronous);

            //Task<int> t = new Task<int>(null) ;

            //WebClient webClient = new WebClient();
            //TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
            //webClient.DownloadStringCompleted += (s, e) =>
            //{
            //    if (e.Cancelled)
            //        taskCompletionSource.SetCanceled();
            //    else if 
            //    (e.Error != null)
            //        taskCompletionSource.SetException(e.Error);
            //    else
            //        taskCompletionSource.SetResult(e.Result);
            //};

            //var pipe = new NamedPipeServerStream(null, PipeDirection.InOut, -1, PipeTransmissionMode.Message, PipeOptions.Asynchronous | PipeOptions.WriteThrough);
            //await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, null);
            //Go3();

            //TaskAwaiter<>
            //AsyncTaskMethodBuilder<>
            //NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream()
            //Timer 
            //TaskScheduler.Default
            //Console.WriteLine(5^9);
            //byte[] ascii = Encoding.ASCII.GetBytes("powerful");
            //Array.ForEach(ascii, bt => Console.WriteLine(bt));
            //byte[] bytes = new byte[]{ 0x12, 0x23, 0x25 };
            //ushort u = CRC16_Calculate(bytes);
            //byte[] b = BitConverter.GetBytes(u);
            //Array.ForEach(b, bt => Console.WriteLine(bt));


            //byte[] b = new byte[]{ 0x11, 0x22, 0x33, 0x44 };
            //int longVar = BitConverter.ToInt32(b, 0);

            //DateTime dateTimeVar = new DateTime(longVar);
            //Console.WriteLine(dateTimeVar);
            // Array.ForEach(BitConverter.GetBytes(DateTime.Now.ToShortDateString()), b => Console.WriteLine(b));
            //new int[5].AsParallel().WithDegreeOfParallelism(4).ForAll(Console.WriteLine);
            //ParallelLoopState
            //Parallel.ForEach()
            //ParallelOptions
            //TaskScheduler.FromCurrentSynchronizationContext
            //TaskFactory tf = new TaskFactory();
            //Task task = new Task(null);
            //task.ContinueWith()

            //using (TcpClient client = new TcpClient())
            //{
            //    client.Connect("52.143.151.239", 10000);
            //    using (NetworkStream n = client.GetStream())
            //    {
            //        byte[] info = new byte[34];
            //        info[2] = 0x60;
            //        Random r = new Random();
            //        for (int i = 3; i < info.Length; i++)
            //            info[i] = (byte)r.Next(100);
            //        n.Write(info, 0, info.Length);
            //        Console.ReadLine();
            //    }
            //}

            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task<Int32> t = Task.Run(() => Sum(cts.Token, 1000000000), cts.Token);
            //cts.Cancel();
            //try
            //{    // If the task got canceled, Result will throw an AggregateException  
            //    Console.WriteLine("The sum is: " + t.Result);   // An Int32 value 
            //}
            //catch (AggregateException x)
            //{
            //    // Consider any OperationCanceledException objects as handled.  
            //    // Any other exceptions cause a new AggregateException containing   
            //    // only the unhandled exceptions to be thrown 
            //    x.Handle(e => e is OperationCanceledException);

            //    // If all the exceptions were handled, the following executes 
            //    Console.WriteLine("Sum was canceled");
            //} 
            //int x = 0;
            //var t = Task.Run(() => x = Sum(CancellationToken.None, 90));

            //Console.WriteLine(x);




            //Task.WaitAll()
            //TaskScheduler
            //CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //while (!cancellationTokenSource.Token.IsCancellationRequested)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "a")
            //        cancellationTokenSource.Cancel();
            //}
            //Console.WriteLine("end");
            //CancellationTokenSource
            //CallContext
            //ExecutionContext
            //ThreadPool
            //byte[] bytes = { 0x32, 0x35, 0x75, 0x54 };
            //MemoryStream memoryStream = new MemoryStream();
            //memoryStream.Write(bytes, 0, bytes.Length);
            //memoryStream.Position = 0;
            //byte[] nbytes = new byte[10];

            //int bytesRead = 0;
            //int chunkSize = 1;
            //while (bytesRead < bytes.Length && chunkSize > 0)
            //    bytesRead += chunkSize = memoryStream.Read(bytes, bytesRead, bytes.Length - bytesRead);
            //BinaryReader binaryReader = new BinaryReader(memoryStream);
            //string s = BitConverter.ToString(binaryReader.ReadBytes(4000));
            //Console.WriteLine(s);
            //memoryStream.Position = 0;
            //string s2 = BitConverter.ToString(binaryReader.ReadBytes(4000));
            //Console.WriteLine(s2);
            //Process
            //Thread t = new Thread(M);
            //t.Start();
            //Console.WriteLine("main");
            //Console.WriteLine(Environment.CurrentManagedThreadId);
            //Console.WriteLine();
            //for (int i = 0; i < Process.GetCurrentProcess().Threads.Count; i++)
            //{
            //    Console.WriteLine(Process.GetCurrentProcess().Threads[i].Id);
            //}

            //TcpListener tcpListener = new TcpListener(IPAddress.Any, 443);
            //tcpListener.Start();
            //var s = tcpListener.AcceptTcpClient();
            //Console.WriteLine("kkjkjjk");
            //byte[] b = new byte[64];
            //var r = new RNGCryptoServiceProvider();
            //r.GetBytes(b);
            //Console.WriteLine(Convert.ToBase64String(b));
            //SerializationBinder
            //SurrogateSelector
            //ISerializationSurrogate
            //IObjectReference
            //StreamingContext
            //var d = MakeFunc();
            //d();
            //Person p = new Person();
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    formatter.Serialize(stream, p);
            //    stream.Position = 0;
            //    Console.WriteLine(formatter.Deserialize(stream).GetType());
            //}

            //SerializationInfo serializationInfo = new SerializationInfo(null, null);
            //foreach (var item in serializationInfo) { }

            //IConvertible
            //FormatterConverter
            //ISerializable
            //FormatterServices
            //Person p1 = new Person { Age = 21 };
            //Person p2 = (Person)DeepClone(p1);
            //Console.WriteLine(p1 == p2);
            //Console.WriteLine(p1.Age == p2.Age);
            //Console.WriteLine(new object().GetType().GetType());
            //new object().GetType().GetTypeInfo().GetDeclaredField("");
            //Console.WriteLine(typeof(int).MakeByRefType());
            //Go();
        }
        public static void Go()
        {    // Explicitly load the assemblies that we want to reflect over
            LoadAssemblies();

            // Filter & sort all the types 
            var allTypes = (from a in AppDomain.CurrentDomain.GetAssemblies()
                            from t in a.ExportedTypes
                            where typeof(Exception).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo())
                            orderby t.Name
                            select t).ToArray();

            // Build the inheritance hierarchy tree and show it 
            Console.WriteLine(WalkInheritanceHierarchy(new StringBuilder(), 0, typeof(Exception), allTypes));
        }
        private static StringBuilder WalkInheritanceHierarchy(StringBuilder sb, Int32 indent, Type baseType, IEnumerable<Type> allTypes)
        {
            String spaces = new String(' ', indent * 3);
            sb.AppendLine(spaces + baseType.FullName);
            foreach (var t in allTypes)
            {
                if (t.GetTypeInfo().BaseType != baseType)
                    continue;
                WalkInheritanceHierarchy(sb, indent + 1, t, allTypes);
            }
            return sb;
        }
        private static void LoadAssemblies()
        {
            String[] assemblies = {       "System,                    PublicKeyToken={0}",
                                          "System.Core,               PublicKeyToken={0}",
                                          "System.Data,               PublicKeyToken={0}",
                                         // "System.Design,             PublicKeyToken={1}",
                                         // "System.DirectoryServices,  PublicKeyToken={1}",
                                          "System.Drawing,            PublicKeyToken={1}",
                                         // "System.Drawing.Design,     PublicKeyToken={1}",
                                         // "System.Management,         PublicKeyToken={1}",
                                         // "System.Messaging,          PublicKeyToken={1}",
                                         // "System.Runtime.Remoting,   PublicKeyToken={0}",
                                          "System.Security,           PublicKeyToken={1}",
                                          "System.ServiceProcess,     PublicKeyToken={1}",
                                          "System.Web,                PublicKeyToken={1}",
                                         // "System.Web.RegularExpressions, PublicKeyToken={1}",
                                         // "System.Web.Services,       PublicKeyToken={1}",
                                          "System.Xml,                PublicKeyToken={0}",
            };

            String EcmaPublicKeyToken = "b77a5c561934e089";
            String MSPublicKeyToken = "b03f5f7f11d50a3a";

            // Get the version of the assembly containing System.Object  
            // We'll assume the same version for all the other assemblies 
            Version version = typeof(System.Object).Assembly.GetName().Version;

            // Explicitly load the assemblies that we want to reflect over  
            foreach (String a in assemblies)
            {
                String AssemblyIdentity = String.Format(a, EcmaPublicKeyToken, MSPublicKeyToken) + ", Culture=neutral, Version=" + version;
                Assembly.Load(AssemblyIdentity);
            }
        }
        private static Object DeepClone(Object original)
        {    // Construct a temporary memory stream
            using (MemoryStream stream = new MemoryStream())
            {

                // Construct a serialization formatter that does all the hard work
                BinaryFormatter formatter = new BinaryFormatter();

                // This line is explained in this chapter's "Streaming Contexts" section 
                formatter.Context = new StreamingContext(StreamingContextStates.Clone);

                // Serialize the object graph into the memory stream   
                formatter.Serialize(stream, original);

                // Seek back to the start of the memory stream before deserializing  
                stream.Position = 0;

                // Deserialize the graph into a new set of objects and       
                // return the root of the graph (deep copy) to the caller    
                return formatter.Deserialize(stream);
            }
        }
    }
}
