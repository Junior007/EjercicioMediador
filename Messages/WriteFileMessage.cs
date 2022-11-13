using ConsoleApp.Enums;

namespace ConsoleApp.Messages
{
    public class WriteFileMessage : Message
    {
        public string Name { get; private set; }

        public WriteFileMessage(Guid id, States state, string name) : base(id, state)
        {
            Name = name;
        }
    }
}