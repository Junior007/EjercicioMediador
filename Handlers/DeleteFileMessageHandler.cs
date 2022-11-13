using ConsoleApp.Messages;
using ConsoleApp.Subscribers;

namespace ConsoleApp.Handlers
{
    internal class DeleteFileMessageHandler<T> : IHandler<T> where T : DeleteFileMessage
    {
        public DeleteFileMessageHandler(BusManager busManager)
        {

        }

        public void EndProcess(Message message)
        {
            Console.WriteLine($"end: {this.GetType().ToString()}");
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
