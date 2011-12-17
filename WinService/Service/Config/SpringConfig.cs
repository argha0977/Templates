using Spring.Context.Attributes;
using Spring.Objects.Factory.Support;
using DslConfig;
using DslConfig.Dsl.ImplicitBaseClasses;
using NLog.Targets;
using Common.Logging;

namespace Service.Config {

    /// <summary>
    /// DI configuration for Spring.NET
    /// </summary>
    [Configuration]
    public class SpringConfig {

        [Definition, Scope(ObjectScope.Singleton)]
        public virtual ServiceContext ServiceContext() {
            ServiceContext serviceContext = new ServiceContext(MainLoop());

            return serviceContext;
        }

        [Definition, Scope(ObjectScope.Singleton)]
        public virtual MainLoop MainLoop() {
            MainLoop mainLoop = new MainLoop();
            mainLoop.Configuration = DslConfig();

            return mainLoop;
        }

        /// <summary>
        /// Create the infrastructure configuration for this app
        /// </summary>
        /// <returns></returns>
        [Definition, Scope(ObjectScope.Singleton)]
        public virtual Configuration DslConfig() {
            Configuration config = new BooDslConfiguration();
            InitNlogDbTarget(config.GetHost());
            return config;
        }

        /// <summary>
        /// Inits the nlog db target.
        /// This is an unwanted dependency to NLOG
        /// Solution would be -> Change DslConfig to support NLog
        /// </summary>
        /// <param name="host">The host.</param>
        private void InitNlogDbTarget(Host host) {
            DatabaseTarget target = NLog.LogManager.Configuration.FindTargetByName("database") as NLog.Targets.DatabaseTarget;
            target.ConnectionString = host.DbConnections["ServiceDb"].ConnectionString;            
            NLog.LogManager.ReconfigExistingLoggers();
        }
    }
}