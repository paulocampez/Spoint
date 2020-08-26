using Core.Domain.Commands;
using Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IMediatrHandler
    {
        Task RaiseEvent<T>(T events, CancellationToken cancellation = default, bool enqueue = false) where T : Event;
        Task SendCommand<T>(T command, CancellationToken cancellation = default, bool enqueue = false) where T : Command;
    }
}
