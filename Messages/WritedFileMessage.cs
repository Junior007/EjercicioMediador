using ConsoleApp.Enums;

namespace ConsoleApp.Messages
{
    public class WritedFileMessage : Message
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public WritedFileMessage(Guid id, States state, string name, string path) : base(id, state)
        {
            Name = name;
            Path = path;
        }
    }
}