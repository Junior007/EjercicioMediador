


using ConsoleApp.Enums;
using ConsoleApp.Messages;
//for (int i = 0; i < 1000000; i++)
{
    IMessageQueue queue = MessageQueue.Get();

    BusManager bus = new BusManager(queue);

    Guid messageId = Guid.NewGuid();



    WriteFileMessage message = new WriteFileMessage(messageId, States.NotProcess, "test.txt") ;

    bus.SendMesage(message);
    WriteFileMessage messageGet = bus.GetMesage<WriteFileMessage>(messageId) as WriteFileMessage;
}
Console.WriteLine("End");


