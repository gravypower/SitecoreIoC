sing $rootnamespace$.Models;

namespace $rootnamespace$.Usecases
{
    public class SimpleInjectorHelloFromUsecase : IHelloFromUsecase
    {
        public Hello WhoSaidHello()
        {
            return new Hello
            {
                HelloFrom = "SimpleInjectorHelloFromUsecase"
            };
        }
    }
}