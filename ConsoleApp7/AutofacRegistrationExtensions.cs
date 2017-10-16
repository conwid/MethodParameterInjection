using Autofac;
using Autofac.Builder;
using Autofac.Extras.DynamicProxy;
using System;

namespace ConsoleApp7
{
    public static class AutofacRegistrationExtensions
    {

        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterInterceptedClass(this ContainerBuilder builder, Type implementationType, params Type[] interceptorTypes)
        {
            return builder.RegisterType(implementationType).EnableClassInterceptors().InterceptedBy(interceptorTypes);
        }

        public static IRegistrationBuilder<TImplementer, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterInterceptedClass<TImplementer>(this ContainerBuilder builder, params Type[] interceptorTypes)
        {
            return builder.RegisterType<TImplementer>().EnableClassInterceptors().InterceptedBy(interceptorTypes);
        }
    }
}
