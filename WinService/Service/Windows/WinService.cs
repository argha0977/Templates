using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Service.Windows {
    public partial class Service : ServiceBase {
        private MainLoop _mainLoop;
        public Service(MainLoop mainLoop) {
            InitializeComponent();
            _mainLoop = mainLoop;
        }

        protected override void OnStart(string[] args) {
            _mainLoop.Start();
        }

        protected override void OnStop() {
            _mainLoop.Stop();
        }
    }
}
