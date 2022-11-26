using ConsoleApp.Messages;
using ConsoleApp.Subscribers;

namespace ConsoleApp.Handlers
{
    internal class DeleteFileMessageHandler<T> : IHandler<T> where T : ProcessedFileMessage
    {
        public HandlerResult Handle(Message message)
        {
            T data = message as T;
            string path = $"{data.Path}/{data.Name}";

            File.Delete(path);
            return new HandlerResult(true, new VoidMessage(Guid.NewGuid()));
        }
    }
}
