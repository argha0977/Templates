using System.ServiceProcess;

namespace Service {

    /// <summary>
    /// This class manages everything regarding the real service to
    /// start and stop    
    /// </summary>
    internal class ServiceRunner : IStartable {
        protected MainLoop _worker;

        public ServiceRunner(MainLoop worker) {
            this._worker = worker;
        }

        public void Start() {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Windows.Service(_worker)
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
