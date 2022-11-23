﻿namespace ConsoleApp.Messages
{
    public class WritedFileMessage : Message
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public WritedFileMessage(Guid id, string name, string path) : base(id)
        {
            Name = name;
            Path = path;
        }
    }
}