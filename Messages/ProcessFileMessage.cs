using ConsoleApp.Enums;

namespace ConsoleApp.Messages
{
    public class ProcessFileMessage : Message
    {
        public string Name { get; private set; }

        public ProcessFileMessage(Guid id, States state, string name) : base(id, state)
        {
            Name = name;
        }
    }
}