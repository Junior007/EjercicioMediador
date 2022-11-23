namespace ConsoleApp.Messages
{
    public class ProcessedFileMessage : Message
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public ProcessedFileMessage(Guid id,string name, string path) : base(id)
        {
            Name = name;
            Path = path;
        }
    }
}