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

            ProcessFileMessage processFileMessage = new ProcessFileMessage(Guid.NewGuid(),Enums.States.Process, data.Name, data.Path);

            _busManager.SendMesage(processFileMessage);
        }

        public void Handle(Message message)
        {
            T data = message as T;

            string path = $"{data.Path}/{data.Name}";
            File.Create(data.Name);

            EndProcess(message);
        }


    }
}
