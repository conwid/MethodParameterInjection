namespace ConsoleApp7
{
    public class ViewModel
    {
        private readonly IService service;
        public ViewModel(IService service)
        {
            this.service = service;
        }

        public void DoSomethingElse()
        {
            service.DoSomething();
        }
    }
}
