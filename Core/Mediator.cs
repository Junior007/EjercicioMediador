using ConsoleApp.Handlers.Messages;
using System.Text.Json;
using ConsoleApp.Subscribers;
using ConsoleApp.Handlers;

internal class Mediator : IMediator
{
    private IMessageQueue _queue;
    private IErrorQueue _errorQueue;
    private static Dictionary<Type, List<object>> handlers;


    IEnumerable<IHandler> _handlers;

    public Mediator(IEnumerable<IHandler> handlers, IMessageQueue queue, IErrorQueue errorQueue)
    {
        _handlers = handlers ?? throw new ArgumentNullException(nameof(IEnumerable<IHandler>));
        _queue = queue;
        _errorQueue = errorQueue;
    }
    public void SendMesage(Message message) 
    {
        string jsonMessage = JsonSerializer.Serialize<Message>(message);
        _queue.Put(message.Id, jsonMessage);

        ExecuteSubscribers<Message>(message, false);
    }

    public Message GetMesage(Guid messageId)
    {
        string jsonMessage = _queue.Get(messageId);
        Message outMessage = JsonSerializer.Deserialize<Message>(jsonMessage);
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

        try
        {
            HandlerResult result = handler.Handle(message);
            if (result.Success)
            {
                Message resultMessage = result.Message; ;
                SendMesage(resultMessage);
            }
            else
            {
                SendErrorMessage(result);
            }
        }
        catch (Exception ex)
        {
            SendException(ex);
        }
    }

    private void SendException(Exception ex) 
    {
        string jsonMessage = JsonSerializer.Serialize<Exception>(ex);
        _errorQueue.Put(Guid.NewGuid(), jsonMessage);
    }

    private void SendErrorMessage(HandlerResult result)
    {
        string jsonMessage = JsonSerializer.Serialize<Message>(result.WarningMessage);
        _errorQueue.Put(Guid.NewGuid(), jsonMessage);
    }

    private IEnumerable<IHandler> GetSuscribers(Type key)
    {
        IEnumerable<IHandler> subscribers =
            _handlers
            .Where(handler => handler.GetType().GetGenericArguments().Any(x => x == key));

        return subscribers;
    }


}