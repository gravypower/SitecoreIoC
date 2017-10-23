using System.Linq;
using SimpleInjector;

namespace SitecoreIoC.SimpleInjector
{
    public class ControllersPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterMvcControllers(SitecoreIoCApplication.ApplicationAssemblies.ToArray());
        }
    }
}
