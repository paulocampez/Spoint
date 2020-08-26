using Core.Domain.CommandHandler;
using Core.Domain.Interfaces;
using Customers.Commands;
using Customers.Domain;
using Customers.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customers.CommandStack.Handlers
{
    public class CustomerCommandHandler : CommandHandler, IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(IMediatrHandler mediator, ICustomerRepository customerRepository) : base (mediator)
        {
            _customerRepository = customerRepository;
        }

        public Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new Customer() { Id = request.Id, BirthDate = request.BirthDate, CreationDate = request.CreationDate, Email = request.Email, Name = request.Name, Phone = request.Phone, Register = request.Register };
            _customerRepository.Insert(customer);
            //fazer validacoes
            return Success();
        }
    }
}
