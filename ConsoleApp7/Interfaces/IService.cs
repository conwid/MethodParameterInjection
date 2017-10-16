namespace ConsoleApp7
{
    public interface IService
    {
        void DoSomething([Resolved] IUnitOfWork uow = default(IUnitOfWork));
    }
}
