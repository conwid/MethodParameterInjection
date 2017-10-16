using Autofac;
using CommonServiceLocator;
using ConsoleApp7.Autofac.Extras.CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class AutofacServiceLocatorLifetimeScopeFactory : ILifetimeScopeFactory
    {
        public ILifetimeScope BeginLifetimeScope()
        {
            return ((AutofacServiceLocator)ServiceLocator.Current).Container.BeginLifetimeScope();
        }
    }
}
