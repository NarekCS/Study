﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLtest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Process.Start(@"C:\Users\narek.avanesyan\Desktop\CLexe\CityLifeAPI.exe");
                //using (Process myProcess = new Process())
                //{
                //    //myProcess.StartInfo.UseShellExecute = false;
                //   // myProcess.StartInfo.WorkingDirectory = @"C:\Users\narek.avanesyan\Desktop\CL exe";
                //    // You can start any process, HelloWorld is a do-nothing example.
                //    myProcess.StartInfo.FileName = @"C:\Users\narek.avanesyan\Desktop\CL exe\CityLifeAPI.exe";
                //   // myProcess.StartInfo.CreateNoWindow = true;
                //    myProcess.Start();
                //    // This code assumes the process you are starting will terminate itself. 
                //    // Given that is is started without a window so you cannot terminate it 
                //    // on the desktop, it must terminate itself or you can do it programmatically
                //    // from this application using the Kill method.
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
