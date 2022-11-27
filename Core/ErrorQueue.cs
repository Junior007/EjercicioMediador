
internal class ErrorQueue : IErrorQueue
{
    private Dictionary<Guid, string> _messages;
    public ErrorQueue()
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
}