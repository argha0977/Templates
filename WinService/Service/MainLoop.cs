using System;
using System.Threading;
using Common.Logging;
using DslConfig;

namespace Service {
    /// <summary>
    /// This is the service main loop.
    /// All applicaiton specific code should start in this class
    /// </summary>
    public class MainLoop {

        protected Thread _workerThread;
        protected bool _runThread = true;
        protected ILog logger;

        internal Configuration Configuration { get; set; }

        public MainLoop() {
            logger = LogManager.GetCurrentClassLogger();
            _workerThread = new Thread(new ThreadStart(ExecuteWorkerThread));
        }

        public void Start() {
            _workerThread.Start();
            logger.Debug(x => x("Service Thread started!"));
        }

        public void Stop() {
            _runThread = false;
            _workerThread.Join(TimeSpan.FromSeconds(5));
            logger.Debug(x => x("Service stopped!"));
        }

        private void ExecuteWorkerThread() {
            try {
                //The Endless Main loop
                while (_runThread) {
                    ProcessWorkflow();
                    Thread.Sleep(Configuration.GetVariable<TimeSpan>("ThreadSleep"));
                }
            } catch (Exception ex) {
                logger.Error(x => x("Error in MainLoop", ex));
                throw;
            } finally {
            }
        }

        protected virtual void ProcessWorkflow() {
            logger.Trace(x => x("Main Loop running!"));            
        }
    }
}
