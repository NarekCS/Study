using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;
using System.Security.Policy;
using System.Security;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;
using System.Threading;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics.Contracts;

namespace ConsoleNetFramework
{
    sealed class AppDomainMonitorDelta : IDisposable
    {
        private AppDomain m_appDomain; private TimeSpan m_thisADCpu; private Int64 m_thisADMemoryInUse; private Int64 m_thisADMemoryAllocated;

        static AppDomainMonitorDelta()
        {       // Make sure that AppDomain monitoring is turned on    
            AppDomain.MonitoringIsEnabled = true;
        }

        public AppDomainMonitorDelta(AppDomain ad)
        {
            m_appDomain = ad ?? AppDomain.CurrentDomain;
            m_thisADCpu = m_appDomain.MonitoringTotalProcessorTime;
            m_thisADMemoryInUse = m_appDomain.MonitoringSurvivedMemorySize;
            m_thisADMemoryAllocated = m_appDomain.MonitoringTotalAllocatedMemorySize;
        }

        public void Dispose()
        {
            GC.Collect();
            Console.WriteLine("FriendlyName ={0}, CPU ={1} ms", m_appDomain.FriendlyName,
                    (m_appDomain.MonitoringTotalProcessorTime - m_thisADCpu).TotalMilliseconds);
            Console.WriteLine(" Allocated {0:N0} bytes of which {1:N0} survived GCs", m_appDomain.MonitoringTotalAllocatedMemorySize - m_thisADMemoryAllocated,
                m_appDomain.MonitoringSurvivedMemorySize - m_thisADMemoryInUse);
        }
    }
    class Fin
    {
        ~Fin()
        {
            Console.WriteLine("destructor");
        }
    }
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    class Some
    {
        static Some()
        {
            Console.WriteLine("some static");
        }
    }
    public class DomainManager: AppDomainManager
    {
        
    }
    class Account
    {
        public int CustomerId { get; set; }
        public string Num { get; set; }
    }
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } 
    }
    public class Program : MarshalByRefObject  // ILease
    {      
        public override object InitializeLifetimeService()
        {
            LifetimeServices.LeaseManagerPollTime = new TimeSpan();
            return base.InitializeLifetimeService();
        }
        string s = "hjfjh";
        static Program()
        {
            Console.WriteLine("ok");
        }
        public Program()
        {
            Console.WriteLine("instance");
        }
       
        static void Main(string[] args)
        {           
            //TypeInfo

            //Activator.CreateInstance()
            //try
            //{
            //    Thread.CurrentThread.Abort("something went wrong");
            //}
            //catch(ThreadAbortException ex)
            //{
            //    string s = (string)ex.ExceptionState;
            //    Console.WriteLine(s);
            //    Console.WriteLine(ex.Message);
            //    Thread.ResetAbort();
            //}
            //AppDomainSetup appDomainSetup = new AppDomainSetup
            //{
            //    AppDomainManagerAssembly = "assembly",
            //    AppDomainManagerType = "DomainManager"
            //};
            //RuntimeHelpers.PrepareConstrainedRegions();
            //try
            //{
            //    Console.WriteLine("try");
            //    Fin fin = new Fin();
            //    //throw new Exception();
            //}
            //finally
            //{
            //    Some some = new Some();
            //    Console.WriteLine("finally");
            //}

            //AppDomain appDomain = AppDomain.CurrentDomain;
            //appDomain.FirstChanceException += AppDomain_FirstChanceException;           

            //using (new AppDomainMonitorDelta(null))
            //{        // Allocate about 10 million bytes that will survive collections 
            //    var list = new List<Object>();
            //    for (Int32 x = 0; x < 1000; x++) list.Add(new Byte[10000]);

            //    // Allocate about 20 million bytes that will NOT survive collections       
            //    for (Int32 x = 0; x < 2000; x++) new Byte[10000].GetType();

            //    // Spin the CPU for about 5 seconds    
            //    Int64 stop = Environment.TickCount + 5000;
            //    while (Environment.TickCount < stop) ;
            //}
            //    AppDomain.MonitoringIsEnabled = true;
            //AppDomain appDomain = AppDomain.CurrentDomain;
            //var list = new List<Object>();
            //for (Int32 x = 0; x < 1000; x++) list.Add(new Byte[10000]);
            //for (Int32 x = 0; x < 2000; x++) new Byte[10000].GetType();
            //long surv = appDomain.MonitoringSurvivedMemorySize;

            //Int64 stop = Environment.TickCount + 5000; while (Environment.TickCount < stop) ;
            //GC.Collect();
            //Console.WriteLine(appDomain.MonitoringTotalAllocatedMemorySize - surv);
            //PermissionSet permissionSet = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            //Evidence evidence = new Evidence();
            //AppDomainSetup appDomainSetup = new AppDomainSetup();
            //AppDomain appDomain = AppDomain.CreateDomain("App Domain Name", evidence, appDomainSetup, permissionSet);
            //AppDomain appDomain = AppDomain.CreateDomain("App Domain Name", null, null);

            //string assemblyName = Assembly.GetCallingAssembly().FullName;
            //try
            //{
            //    Program p = (Program)appDomain.CreateInstanceAndUnwrap(assemblyName, "ConsoleNetFramework.Program");
            //    Console.WriteLine(p.s);
            //}
            //catch (TypeLoadException ex)
            //{
            //    throw ex;
            //}
        }

        private static void AppDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine("Exception");
        }
    }
}
