using ConsoleApp.Messages;
using ConsoleApp.Subscribers;

namespace ConsoleApp.Handlers
{
    internal class WriteFileMessageHandler<T> : IHandler<T> where T : WriteFileMessage
    {
        BusManager _busManager;

        public WriteFileMessageHandler(BusManager busManager)
        {
            _busManager = busManager;
        }

        public void EndProcess(Message message)
        {
            T data = message as T;
            //data.State= NotProcess

            Console.WriteLine($"end: {this.GetType().ToString()}");
            _busManager.UpdateMesage(message);
        }

        public void Handle(Message message)
        {

            T data = message as T;
            System.IO.File.Create(data.Name);


            EndProcess(message);
        }


    }
}
