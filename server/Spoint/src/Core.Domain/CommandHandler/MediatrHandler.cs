using Core.Domain.Commands;
using Core.Domain.Events;
using Core.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.CommandHandler
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T events, CancellationToken cancellation = default, bool enqueue = false) where T : Event
        {
            throw new NotImplementedException();
        }

        public Task SendCommand<T>(T command, CancellationToken cancellation = default, bool enqueue = false) where T : Command
        {
            return _mediator.Send(command, cancellation);
        }
    }


}
