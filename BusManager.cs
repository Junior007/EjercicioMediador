using ConsoleApp.Handlers;
using ConsoleApp.Messages;
using System.Text.Json;
using ConsoleApp.Subscribers;
internal class BusManager : IBusManager
{
    private IMessageQueue _queue;
    private static Dictionary<Type, List<object>> handlers;

    private Dictionary<Type, List<object>> GetAllSuscribers
    {
        get
        {
            handlers = handlers ?? new Dictionary<Type, List<object>>();

            if (handlers.Count == 0)
            {
                IEnumerable<Type> handlers = typeof(IHandler<Message>).Assembly.GetTypes().Where(x => x.GetInterfaces().Any(i => i.Name == typeof(IHandler<Message>).Name) && !x.IsInterface);

                foreach (var handler in handlers)
                {
                    Type key = handler.GetGenericArguments().First(x => x.BaseType.IsAssignableTo(typeof(Message)))?.BaseType;

                    var t = handler.MakeGenericType(key);

                    var instance = Activator.CreateInstance(t, this);

                    bool exists = BusManager.handlers.Keys.FirstOrDefault(x => x == key) != null;
                    if (exists)
                    {
                        var subs = BusManager.handlers[key];
                        subs.Add(instance);
                    }
                    else
                    {
                        var subs = new List<object>() { instance };
                        BusManager.handlers.Add(key, subs);
                    }

                }
            }
            return handlers;
        }
    }

    public BusManager(IMessageQueue queue)
    {
        _queue = queue ?? throw new ArgumentNullException();

    }

    public void SendMesage<T>(T message) where T : Message
    {
        string jsonMessage = JsonSerializer.Serialize<T>(message);
        _queue.Put(message.Id, jsonMessage);

        ExecuteSubscribers<T>(message);
    }

    public void UpdateMesage<T>(T message) where T : Message
    {
        string jsonMessage = JsonSerializer.Serialize<T>(message);
        _queue.Update(message.Id, jsonMessage);

        ExecuteSubscribers<T>(message);
    }

    public T GetMesage<T>(Guid messageId) where T : Message
    {
        string jsonMessage = _queue.Get(messageId);
        T outMessage = JsonSerializer.Deserialize<T>(jsonMessage);
        return outMessage;
    }

    private void ExecuteSubscribers<T>(Message message)
    {
        Type key = message.GetMessageType();

        var handlers = GetSuscribers(key).Select(s => s as IHandler);

        if (handlers != null)
        {
            if (handlers != null)
                Parallel.ForEach(handlers, handler =>
            {
                handler.Handle(message);
            });
        }

        _queue.Remove(message.Id);
    }

    private IEnumerable<object> GetSuscribers(Type key)
    {
        IEnumerable<object> subscribers =
            GetAllSuscribers
            .Where(s => s.Key == key)
            .Select(s => s.Value).FirstOrDefault();

        return subscribers;
    }
}