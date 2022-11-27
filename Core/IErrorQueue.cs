internal interface IErrorQueue
{
    void Put(Guid id, string message);
    string Get(Guid messageId);
    void Remove(Guid messageId);
}