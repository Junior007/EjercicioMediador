using ConsoleApp.Enums;

namespace ConsoleApp.Messages
{
    public class DeleteFileMessage : Message
    {
        public string Name { get; private set; }

        public DeleteFileMessage(Guid id, States state, string name) : base(id, state)
        {
            Name = name;
        }
    }
}