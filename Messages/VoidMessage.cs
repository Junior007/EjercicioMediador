namespace ConsoleApp.Messages
{
    public class VoidMessage : Message
    {
        public override bool IsNull => true;
        public VoidMessage(Guid id) : base(id)
        {
        }
    }
}
