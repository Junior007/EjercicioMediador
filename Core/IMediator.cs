using ConsoleApp.Messages;

internal interface IMediator
{
    T GetMesage<T>(Guid messageId) where T : Message;
    void SendMesage<T>(T message) where T : Message;
}