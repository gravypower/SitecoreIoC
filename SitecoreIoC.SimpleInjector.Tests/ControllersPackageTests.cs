using NUnit.Framework;
using SimpleInjector;
using SitecoreIoC.Tests.Common;

namespace SitecoreIoC.SimpleInjector.Tests
{
    [TestFixture]
    public class ControllersPackageTests
    {
        [SetUp]
        public void SetUp()
        {
            SitecoreIoCApplication.PreApplicationStart();

            var loadAssembley = SimpleInjectorApplication.Container;
        }

        [Test]
        public void CanResolveController()
        {
            var container = new Container();

            var controllersPackage = new ControllersPackage();
            controllersPackage.RegisterServices(container);
            Assert.That(container.GetInstance<DummyController>(), Is.Not.Null);
        }

        [Test]
        public void CanResolveControllerFromAnotherAssembley()
        {
            var container = new Container();

            var controllersPackage = new ControllersPackage();
            controllersPackage.RegisterServices(container);
            Assert.That(container.GetInstance<AnotherDummyController>(), Is.Not.Null);
        }

        [Test]
        public void GivenPreApplicationStartCalledCanResolveController()
        {
            Assert.That(SimpleInjectorApplication.Container.GetInstance<DummyController>(), Is.Not.Null);
        }

        [Test]
        public void GivenPreApplicationStartCalledCanResolveControllerFromAnotherAssembley()
        {
            Assert.That(SimpleInjectorApplication.Container.GetInstance<AnotherDummyController>(), Is.Not.Null);
        }

        [Test]
        public void Isolated_GivenPreApplicationStartCalledCanResolveController()
        {
            Isolated.Execute(() =>
            {
                SitecoreIoCApplication.PreApplicationStart();
                Assert.That(SimpleInjectorApplication.Container.GetInstance<DummyController>(), Is.Not.Null);
            });
        }

        [Test]
        public void Isolated_GivenPreApplicationStartCalledCanResolveControllerFromAnotherAssembley()
        {
            Isolated.Execute(() =>
            {
                SitecoreIoCApplication.PreApplicationStart();
                Assert.That(SimpleInjectorApplication.Container.GetInstance<AnotherDummyController>(), Is.Not.Null);
            });
        }
    }
}
