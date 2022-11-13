using ConsoleApp.Messages;

namespace ConsoleApp.Subscribers
{
    public interface IHandler<T> : IHandler where T : Message
    {
    }

    public interface IHandler
    {
        public void Handle(Message message);
        public void EndProcess(Message message);

    }
}
