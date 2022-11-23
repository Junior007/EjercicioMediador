namespace ConsoleApp.Messages
{
    public class WriteFileMessage : Message
    {
        public string Name { get; private set; }
        public string Path { get; private set; }

        public WriteFileMessage(Guid id, string name, string path) : base(id)
        {
            Name = name;
            Path = path;
        }
    }
}