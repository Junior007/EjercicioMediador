using ConsoleApp.Messages;

internal interface IBusManager
{
    T GetMesage<T>(Guid messageId) where T : Message;
    void SendMesage<T>(T message) where T : Message;
}