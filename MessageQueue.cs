
internal class MessageQueue : IMessageQueue
{
    private static IMessageQueue _queue;
    private Dictionary<Guid, string> _messages;
    public MessageQueue()
    {
    }
    public static IMessageQueue Get()
    {
        _queue = _queue ?? new MessageQueue();
        return _queue;
    }

    public void Put(Guid id, string message)
    {

        GetMessages().Add(id, message);
    }
    public void Update(Guid id, string message)
    {
        Remove(id);
        Put(id, message);
    }
    public string Get(Guid messageId)
    {
        return GetMessages()[messageId];
    }

    private Dictionary<Guid, string> GetMessages()
    {
        _messages = _messages ?? new Dictionary<Guid, string>();
        return _messages;
    }

    public void Remove(Guid messageId)
    {
        GetMessages().Remove(messageId);
    }
}