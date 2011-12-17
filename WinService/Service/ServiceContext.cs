using System;

namespace Service {

    /// <summary>    
    /// This class  decides which service runner (console, service, ...) should
    /// be used to run the service
    /// </summary>
    public class ServiceContext {
        protected IStartable _runner;

        public ServiceContext(MainLoop _worker) {
            if (Environment.UserInteractive) {
                _runner = new ConsoleRunner(_worker);
            } else {
                _runner = new ServiceRunner(_worker);
            }
        }

        public void Start() {
            _runner.Start();
        }
    }
}
