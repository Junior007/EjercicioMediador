
internal class MessageQueue : IMessageQueue
{
    private Dictionary<Guid, string> _messages;
    public MessageQueue()
    {
        _messages = new Dictionary<Guid, string>();
    }
    public void Put(Guid id, string message)
    {
        lock (this)
            _messages.Add(id, message);
    }

    public string Get(Guid messageId)
    {
        return _messages[messageId];
    }

    public void Remove(Guid messageId)
    {
        _messages.Remove(messageId);
    }    
    
    /*public void Update(Guid id, string message)
    {
        Remove(id);
        Put(id, message);
    }*/
}