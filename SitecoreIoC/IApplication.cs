using System.Web.Mvc;

namespace SitecoreIoC
{
    public interface IApplication
    {
        void PreApplicationStart();
        void ApplicationShutdown();

        IControllerFactory GetControllerFactory();
    }
}
