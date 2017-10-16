namespace ConsoleApp7
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CommonServiceLocator;
    using global::Autofac;

    namespace Autofac.Extras.CommonServiceLocator
    {
        // https://github.com/conwid/Autofac.Extras.CommonServiceLocator
        public class AutofacServiceLocator : ServiceLocatorImplBase
        {

            private readonly ILifetimeScope _container;

            public ILifetimeScope Container => _container;

            public AutofacServiceLocator(ILifetimeScope container)
            {
                _container = container ?? throw new ArgumentNullException("container");
            }

            protected override object DoGetInstance(Type serviceType, string key)
            {
                if (serviceType == null)
                {
                    throw new ArgumentNullException(nameof(serviceType));
                }

                return key != null ? _container.ResolveNamed(key, serviceType) : _container.Resolve(serviceType);
            }   
            
            protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
            {
                if (serviceType == null)
                {
                    throw new ArgumentNullException(nameof(serviceType));
                }

                var enumerableType = typeof(IEnumerable<>).MakeGenericType(serviceType);

                object instance = _container.Resolve(enumerableType);
                return ((IEnumerable)instance).Cast<object>();
            }
        }
    }
}
