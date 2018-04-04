using Autofac;
using Autofac.Integration.Mvc;
using TDDKennisSessie.Logic;
using TDDKennisSessie.TddExamples;
using TDDKennisSessieDataLayer.Backend.Actual;
using TDDKennisSessieDataLayer.Backend.Interfaces;

namespace TDDKennisSessieAPI
{
    public class DependencyContainer
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Register(c => new ProjectDatabaseBackend()).As<IProjectBackend>();
            builder.RegisterType<ProjectLogic>();
            builder.RegisterType<PasswordValidator>();

            return builder.Build();
        }

        public static AutofacDependencyResolver MvcDiResolver()
        {
            return new AutofacDependencyResolver(Build());
        }
    }
}