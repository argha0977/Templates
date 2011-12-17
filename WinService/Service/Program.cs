using Spring.Context;
using Spring.Context.Support;

namespace Service {
    public static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main() {
            GenericApplicationContext ctx = new CodeConfigApplicationContext();
            ctx.ScanWithAssemblyFilter(assy => assy.FullName.Contains("Service"));
            ctx.Refresh();
                        
            ServiceContext serviceContext = ctx.GetObject<ServiceContext>();
            serviceContext.Start();
        }

        
    }
}
