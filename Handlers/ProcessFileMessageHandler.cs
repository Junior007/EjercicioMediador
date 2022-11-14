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
            T data = message as T;

            DeleteFileMessage processFileMessage = new DeleteFileMessage(Guid.NewGuid(), Enums.States.Process, data.Name, data.Path);

            _busManager.SendMesage(processFileMessage);
        }

        public void Handle(Message message)
        {

            T data = message as T;
            string path = $"{data.Path}/{data.Name}";

            for (int i = 1; i < 10; i++)
            {
                File.WriteAllText(path, data.Name);

            }
            EndProcess(message);
        }
    }
}
