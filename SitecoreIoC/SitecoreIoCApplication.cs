using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using SitecoreIoC;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SitecoreIoCApplication), "PreApplicationStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(SitecoreIoCApplication), "ApplicationShutdown")]

namespace SitecoreIoC
{
    public static class SitecoreIoCApplication
    {
        private static readonly IApplication Application;

        private static readonly List<string> IgnoreAssemblyList = new List<string>
        {
            "YUI Compressor .NET Library",
            "Castle.Windsor 3.2.1 for .NETFramework v4.5",
            "Castle.Core 3.2.0 for .NETFramework v4.5"
        };

        private static readonly List<string> IgnoreCompaniesList = new List<string>
        {
            "Sitecore Corporation",
            "Microsoft Corporation."
        };

        public readonly static IEnumerable<Assembly> ApplicationAssemblies;

        static SitecoreIoCApplication()
        {
            ApplicationAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .Where(a => !IgnoreAssemblyList.Contains(a.GetAssemblyAttribute<AssemblyTitleAttribute>(ass => ass.Title)))
                .Where(a => !IgnoreCompaniesList.Contains(a.GetAssemblyAttribute<AssemblyCompanyAttribute>(ass => ass.Company)));

            var applications = ApplicationAssemblies.SelectMany(a => a.GetTypes())
                .Where(t => !t.IsInterface)
                .Where(t => typeof(IApplication).IsAssignableFrom(t)).ToList();

            try
            {
                var applicationType = applications.Single();
                Application = (IApplication) Activator.CreateInstance(applicationType);
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Sequence contains more than one element")
                    throw new MultipleApplicationFound(applications);

                if (e.Message == "Sequence contains no elements")
                    throw new NoApplicationFound();
  
                throw;
            }
            catch (ReflectionTypeLoadException re)
            {
                var message = "Could not load types: \n";
                foreach (var loaderException in re.LoaderExceptions)
                {
                    message += loaderException.Message + "\n";
                }

                throw new Exception(message);
            }
        }

        public static string GetAssemblyAttribute<T>(this Assembly assembly, Func<T, string> value)
            where T : Attribute
        {
            var attribute = (T)Attribute.GetCustomAttribute(assembly, typeof(T));
            if (attribute == null)
            {
                return string.Empty;
            }
            return value.Invoke(attribute);
        }

        public static void PreApplicationStart()
        {
            Application.PreApplicationStart();
        }

        public static void ApplicationShutdown()
        {
            Application.ApplicationShutdown();
        }

        public static IControllerFactory GetControllerFactory()
        {
            return Application.GetControllerFactory();
        }

        public static string GetBinDirectory()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"); 
        }
    }
}
