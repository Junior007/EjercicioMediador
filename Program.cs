


using ConsoleApp.Enums;
using ConsoleApp.Messages;
for (int i = 0; i < 10000; i++)
{
    IMessageQueue queue = MessageQueue.Get();

    BusManager bus = new BusManager(queue);

    Guid messageId = Guid.NewGuid();

    WriteFileMessage message = new WriteFileMessage(messageId, States.NotProcess, $"test{i}.txt", "c:/temp");

    bus.SendMesage(message);
}
Console.WriteLine("End");


