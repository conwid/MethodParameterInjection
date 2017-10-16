using Autofac;
using CommonServiceLocator;
using ConsoleApp7.Autofac.Extras.CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ViewModel>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ResolveParameterInterceptor>();
            builder.RegisterType<AutofacServiceLocatorLifetimeScopeFactory>().As<ILifetimeScopeFactory>().SingleInstance();
            //builder.RegisterType<Service>().EnableClassInterceptors().InterceptedBy(typeof(ResolveParameterInterceptor)).As<IService>();
            builder.RegisterInterceptedClass<Service>(typeof(ResolveParameterInterceptor)).As<IService>();
            var container = builder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            var vm = container.Resolve<ViewModel>();            
            vm.DoSomethingElse();
            vm.DoSomethingElse();

            Console.ReadLine();
        }
    }
}
