using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.CommandHandler
{
    public abstract class CommandHandler
    {
        protected readonly IMediatrHandler _mediator;

        protected CommandHandler(IMediatrHandler mediator)
        {
            _mediator = mediator;
        }
        protected Task<bool> Success() => Task.FromResult(true);

        protected Task<bool> Failure() => Task.FromResult(false);
    }
}
