using System;

namespace ConsoleApp7
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {

        }
        public void Commit()
        {
            Console.WriteLine("Commiting...");
        }

        public void Dispose()

        {            
        }
    }
}
