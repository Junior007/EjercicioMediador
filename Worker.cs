using ConsoleApp.Enums;
using ConsoleApp.Messages;


namespace ConsoleApp
{
    internal class Worker
    {
        IBusManager _bus;
        public Worker(IBusManager bus)
        {
            _bus = bus;
        }
        public void Run()
        {

            for (int i = 0; i < 2; i++)
            {
                Guid messageId = Guid.NewGuid();

                WriteFileMessage message = new WriteFileMessage(messageId, States.NotProcess, $"test{i}.txt", "c:/temp");

                _bus.SendMesage(message);
            }
            Console.WriteLine("End");

        }

    }
}
