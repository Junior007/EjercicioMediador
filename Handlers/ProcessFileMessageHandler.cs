using ConsoleApp.Messages;
using ConsoleApp.Subscribers;

namespace ConsoleApp.Handlers
{
    internal class ProcessFileMessageHandler<T> : IHandler<T> where T : ProcessFileMessage
    {

        BusManager _busManager;
        public ProcessFileMessageHandler(BusManager busManager)
        {
            _busManager = busManager;
        }

        public void EndProcess(Message message)
        {
            Console.WriteLine($"end: {this.GetType().ToString()}");
            _busManager.UpdateMesage(message);
        }

        public void Handle(Message message)
        {

            Console.WriteLine($"sleeping: {this.GetType().ToString()}");
            Thread.Sleep(1000);
            Console.WriteLine("awake");
            //WriteFileData data = message.Data as WriteFileData;
            //System.IO.File.Create(data.Name);
        }
    }
}
