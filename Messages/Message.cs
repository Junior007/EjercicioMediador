﻿using ConsoleApp.Enums;

namespace ConsoleApp.Messages
{
    public abstract class Message
    {
        public Message(Guid id, States state)
        {
            Id = id != Guid.Empty ? id : throw new ArgumentNullException();
            State = state != States.StateLess ? state : throw new ArgumentNullException();
            Type = this.GetType().ToString();
        }

        public virtual bool IsNull => false;
        public Guid Id { get; private set; }

        public States State { get; private set; }

        public string Type { get; private set; }

        public Type GetMessageType()
        {
            return typeof(Message).Assembly.GetTypes().First(x => Type == x.FullName);
        }

    }
}