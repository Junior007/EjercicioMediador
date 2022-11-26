using ConsoleApp.Messages;

namespace ConsoleApp.Handlers
{
    public class HandlerResult
    {
        public Message Message { get; }

        public bool Success { get; }


        internal HandlerResult(bool success, Message message) 
        {
            Success = success;
            Message = message;
        }
    }
}
