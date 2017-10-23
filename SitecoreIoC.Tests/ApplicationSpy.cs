using System.Web.Mvc;

namespace SitecoreIoC.Tests
{
    public class ApplicationSpy : IApplication
    {
        public static bool PreApplicationStartWasCalled = false;
        public static bool ApplicationShutdownWasCalled = false;
        public static bool GetControllerFactoryWasCalled = false;

        public void PreApplicationStart()
        {
            PreApplicationStartWasCalled = true;
        }

        public void ApplicationShutdown()
        {
            ApplicationShutdownWasCalled = true;
        }

        public IControllerFactory GetControllerFactory()
        {
            GetControllerFactoryWasCalled = true;
            return null;
        }
    }
}