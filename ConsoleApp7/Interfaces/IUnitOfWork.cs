using System;

namespace ConsoleApp7
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
