using ConsoleApp.Handlers.Messages;

internal interface IMediator
{
    Message GetMesage(Guid messageId);
    void SendMesage(Message message);
}