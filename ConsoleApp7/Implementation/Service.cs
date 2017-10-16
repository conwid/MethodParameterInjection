using System;

namespace ConsoleApp7
{
    public class Service : IService
    {
        public virtual void DoSomething([Resolved] IUnitOfWork uow = default(IUnitOfWork))
        {
            if (uow == null)
            {
                Console.WriteLine("Null");
            }
            else
            {
                Console.WriteLine("Not null");
                uow.Commit();
            }
        }
    }
}
