using ConsoleApp.Messages;
using System.Text.Json;
using ConsoleApp.Subscribers;
using ConsoleApp.Handlers;

internal class Mediator : IMediator
{
    private IMessageQueue _queue;
    private static Dictionary<Type, List<object>> handlers;


    IEnumerable<IHandler> _handlers;

    public Mediator(IEnumerable<IHandler> handlers, IMessageQueue queue)
    {
        _handlers = handlers ?? throw new ArgumentNullException(nameof(IEnumerable<IHandler>));
        _queue = queue;
    }
    public void SendMesage<T>(T message) where T : Message
    {
        string jsonMessage = JsonSerializer.Serialize<T>(message);
        _queue.Put(message.Id, jsonMessage);

        ExecuteSubscribers<T>(message, false);
    }

    /*public void UpdateMesage<T>(T message) where T : Message
    {
        string jsonMessage = JsonSerializer.Serialize<T>(message);
        _queue.Update(message.Id, jsonMessage);

        ExecuteSubscribers<T>(message);
    }*/

    public T GetMesage<T>(Guid messageId) where T : Message
    {
        string jsonMessage = _queue.Get(messageId);
        T outMessage = JsonSerializer.Deserialize<T>(jsonMessage);
        return outMessage;
    }

    private void ExecuteSubscribers<T>(Message message, bool isSincrono)
    {
        Type key = message.GetMessageType();

        var handlers = GetSuscribers(key).Select(s => s as IHandler);

        if (handlers != null)
        {
            if (!isSincrono)
            {
                //Asincrono
                Parallel.ForEach(handlers, handler =>
                {
                    Execute(handler, message);
                });
            }
            else
            {
                //Sincrono
                foreach (IHandler handler in handlers)
                {
                    Execute(handler, message);
                }
            }
        }

        _queue.Remove(message.Id);
    }
    private void Execute(IHandler handler, Message message)
    {

        HandlerResult result = handler.Handle(message);
        if (result.Success)
        {
            Message resultMessage = result.Message; ;
            SendMesage(resultMessage);
        }
        else
        {
            //write in failed queau

        }
    }
    private IEnumerable<IHandler> GetSuscribers(Type key)
    {
        IEnumerable<IHandler> subscribers =
            _handlers
            .Where(handler => handler.GetType().GetGenericArguments().Any(x => x == key));

        return subscribers;
    }
}