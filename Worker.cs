
using ConsoleApp.Handlers.Messages;


namespace ConsoleApp
{
    internal class Worker
    {
        IMediator _mediator;
        public Worker(IMediator bus)
        {
            _mediator = bus;
        }
        public void Run()
        {
            var time1 = DateTime.Now;

            //Asincrono
            var ixs = Enumerable.Range(0, 10);
            Parallel.ForEach(ixs, i =>
            {
                Guid messageId = Guid.NewGuid();

                WriteFileMessage message = new WriteFileMessage(messageId, $"test{i}.txt", "c:/temp");

                _mediator.SendMesage(message);
            });

            TimeSpan timeSpan = DateTime.Now - time1;

            Console.WriteLine(timeSpan.TotalMilliseconds);


            Console.WriteLine("End");

        }

    }
}
