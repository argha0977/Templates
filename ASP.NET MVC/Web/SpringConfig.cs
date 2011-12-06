using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring.Context.Attributes;
using Web.Controllers;
using InfrastructureConfig.Dsl;
using Spring.Objects.Factory.Support;

namespace Web {

    /// <summary>
    /// DI configuration for Spring.NET
    /// </summary>
    [Configuration]
    public class SpringConfig {

        #region Controllers

        [Definition, Scope(ObjectScope.Prototype)]
        public virtual HomeController HomeController() {
            HomeController controller = new HomeController();

            controller.Config = InfrastructureConfig();
            
            return controller;
        }

        [Definition, Scope(ObjectScope.Prototype)]
        public virtual AccountController AccountController() {
            AccountController controller = new AccountController();
            controller.Config = InfrastructureConfig();

            return controller;
        }

        #endregion


        /// <summary>
        /// Create the infrastructure configuration for this app
        /// </summary>
        /// <returns></returns>
        [Definition, Scope(ObjectScope.Singleton)]
        public virtual IInfrastructureConfig InfrastructureConfig() {
            IInfrastructureConfig config = new InfrastructureConfig.Dsl.InfrastructureConfig();            
            return config;
        }

    }
}