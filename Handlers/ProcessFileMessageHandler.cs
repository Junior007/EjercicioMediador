using ConsoleApp.Messages;
using ConsoleApp.Subscribers;

namespace ConsoleApp.Handlers
{
    internal class ProcessFileMessageHandler<T> : IHandler<T> where T : WritedFileMessage
    {
        public Message Handle(Message message)
        {
            T data = message as T;
            string path = $"{data.Path}/{data.Name}";

            for (int i = 1; i < 10; i++)
            {
                File.WriteAllText(path, data.Name);

            }
            Console.WriteLine(this.ToString());
            return new ProcessedFileMessage(Guid.NewGuid(), Enums.States.Process, data.Name, data.Path);
        }
    }
}
