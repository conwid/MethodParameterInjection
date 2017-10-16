using Autofac;

namespace ConsoleApp7
{
    public interface ILifetimeScopeFactory
    {
        ILifetimeScope BeginLifetimeScope();
    }
}