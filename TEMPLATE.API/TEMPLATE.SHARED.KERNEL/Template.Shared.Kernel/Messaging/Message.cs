﻿using System;

namespace Template.Shared.Kernel.Messaging
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}