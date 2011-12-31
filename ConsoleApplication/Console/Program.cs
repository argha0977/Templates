using Spring.Context;
using Spring.Context.Support;
using System;

namespace ConsoleApp {
    public static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main() {
            GenericApplicationContext ctx = new CodeConfigApplicationContext();            
            ctx.ScanWithAssemblyFilter(assy => assy.FullName.Contains("Console"));
            ctx.Refresh();

            MainLoop mainLoop = ctx.GetObject<MainLoop>();
            Console.WriteLine("STARTING CONSOLE APPLICATION ...");
            mainLoop.Start();
            Console.WriteLine("CONSOLE APPLICATION STARTED ... PRESS <ENTER> TO QUIT");

            Console.ReadKey();

            Console.WriteLine("STOPPING CONSOLE APPLICATION ...");
            mainLoop.Stop();
            Console.WriteLine("CONSOLE APPLICATION STOPPED");
        }

        
    }
}
