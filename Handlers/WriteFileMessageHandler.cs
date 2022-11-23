using ConsoleApp.Messages;
using ConsoleApp.Subscribers;

namespace ConsoleApp.Handlers
{
    internal class WriteFileMessageHandler<T> : IHandler<T> where T : WriteFileMessage
    {
        public Message Handle(Message message)
        {
            T data = message as T;

            string path = $"{data.Path}/{data.Name}";
            File.Create(data.Name);

            return new WritedFileMessage(Guid.NewGuid(), data.Name, data.Path);
        }
    }
}
