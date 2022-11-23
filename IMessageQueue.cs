internal interface IMessageQueue
{
    void Put(Guid id, string message);
    string Get(Guid messageId);
    void Remove(Guid messageId);
    //void Update(Guid id, string message);
}