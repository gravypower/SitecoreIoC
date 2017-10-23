using System.Web.Mvc;
using $rootnamespace$.Usecases;

namespace $rootnamespace$.Controllers
{
    public class HelloFromIoCController : Controller
    {
        private readonly IHelloFromUsecase _usecase;

        public HelloFromIoCController(IHelloFromUsecase usecase)
        {
            _usecase = usecase;
        }

        // GET: HelloFromCastleWindsor
        public ActionResult Index()
        {
            return View(_usecase.WhoSaidHello());
        }
    }
}