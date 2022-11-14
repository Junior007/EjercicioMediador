using ConsoleApp.Messages;
using ConsoleApp.Subscribers;

namespace ConsoleApp.Handlers
{
    internal class DeleteFileMessageHandler<T> : IHandler<T> where T : DeleteFileMessage
    {
        BusManager _busManager;
        public DeleteFileMessageHandler(BusManager busManager)
        {
            _busManager = busManager;
        }

        public void EndProcess(Message message)
        {
            //T data = message as T;

            //DeleteFileMessage deleteFileMessage = new DeleteFileMessage(Guid.NewGuid(), Enums.States.StateLess, data.Name, data.Path);

            //_busManager.SendMesage(deleteFileMessage);
        }

        public void Handle(Message message)
        {
            T data = message as T;
            string path = $"{data.Path}/{data.Name}";

            File.Delete(path);

        }
    }
}
