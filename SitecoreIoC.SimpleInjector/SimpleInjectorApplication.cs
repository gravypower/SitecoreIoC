using System.Web.Mvc;
using SimpleInjector;

namespace SitecoreIoC.SimpleInjector
{
    public class SimpleInjectorApplication : IApplication
    {
        public static Container Container;

        public void PreApplicationStart()
        {
            Container = new Container();
            Container.RegisterPackages(SitecoreIoCApplication.ApplicationAssemblies);
        }

        public void ApplicationShutdown()
        {
            // The Simple Injector Container does not implement IDisposable. See below URL for more information
            // http://simpleinjector.codeplex.com/discussions/432730
        }

        public IControllerFactory GetControllerFactory()
        {
            return new SimpleInjectorControllerFactory(Container);
        }
    }
}
