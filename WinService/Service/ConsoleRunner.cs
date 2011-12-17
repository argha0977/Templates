using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Service;

namespace Service {

    /// <summary>
    /// This class manages everything regarding the console application to
    /// start and stop the service
    /// This class represents a concrete strategy of the strategy pattern
    /// </summary>
    internal class ConsoleRunner : IStartable {

        private MainLoop _mainLoop;

        public ConsoleRunner(MainLoop mainLoop) {
            _mainLoop = mainLoop;
        }

        public void Start() {
            Console.WriteLine("STARTING SERVICE ...");
            StartApplication();
            Console.WriteLine("SERVICE STARTED ... PRESS <ENTER> TO QUIT");

            Console.ReadLine();

            Console.WriteLine("STOPPING SERVICE ...");
            StopApplication();
            Console.WriteLine("SERVICE STOPPED");
        }

        private void StartApplication() {
            _mainLoop.Start();
        }

        private void StopApplication() {
            _mainLoop.Stop();
        }
    }
}
