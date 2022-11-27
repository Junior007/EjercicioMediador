using ConsoleApp.Handlers.Messages;

namespace ConsoleApp.Handlers
{
    public class HandlerResult
    {
        public Message Message { get; }
        public Message WarningMessage { get; }

        public bool Success { get; }


        internal HandlerResult(bool success, Message message, Message warningMessage) 
        {
            Success = success;
            Message = message;
            WarningMessage = warningMessage;
        }
    }
}
