using Core.Domains.Events;
using System;

namespace Core.Domains.Commands
{
    public abstract class Command : Message
    {
        protected DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
