using Autofac;
using Castle.DynamicProxy;
using CommonServiceLocator;
using ConsoleApp7.Autofac.Extras.CommonServiceLocator;
using System.Linq;
using System.Reflection;

namespace ConsoleApp7
{
    public class ResolveParameterInterceptor : IInterceptor
    {
        private readonly ILifetimeScopeFactory scopeFactory;

        public ResolveParameterInterceptor(ILifetimeScopeFactory factory)
        {
            this.scopeFactory = factory;
        }
        public void Intercept(IInvocation invocation)
        {
            using (var scope = scopeFactory.BeginLifetimeScope())
            {
                var resolveParameters = invocation.Method.GetParameters().Where(p => p.GetCustomAttribute<ResolvedAttribute>() != null);
                foreach (var p in resolveParameters)
                {
                    invocation.SetArgumentValue(p.Position, scope.Resolve(p.ParameterType));
                }
                invocation.Proceed();
            }
        }
    }
}
