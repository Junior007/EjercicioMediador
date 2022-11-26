using ConsoleApp.Messages;
using ConsoleApp.Subscribers;

namespace ConsoleApp.Handlers
{
    internal class ProcessFileMessageHandler<T> : IHandler<T> where T : WritedFileMessage
    {
        public HandlerResult Handle(Message message)
        {
            T data = message as T;
            string path = $"{data.Path}/{data.Name}";

            for (int i = 1; i < 10000; i++)
            {
                File.AppendAllText(path, data.Name);

            }

            return new HandlerResult(true, new ProcessedFileMessage(Guid.NewGuid(), data.Name, data.Path));
        }
    }
}
