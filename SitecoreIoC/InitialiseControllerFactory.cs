using Sitecore.Mvc.Controllers;
using Sitecore.Pipelines;
using ControllerBuilder = System.Web.Mvc.ControllerBuilder;

namespace SitecoreIoC
{
    public class InitialiseControllerFactory
    {
        public virtual void Process(PipelineArgs args)
        {
            var controllerFactory = SitecoreIoCApplication.GetControllerFactory();

            if(controllerFactory == null)
                return;

            var sitecoreControllerFactory = new SitecoreControllerFactory(controllerFactory);
            ControllerBuilder.Current.SetControllerFactory(sitecoreControllerFactory);
        }
    }
}
