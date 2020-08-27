using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domains.Interfaces;
using Customer.Command;
using Customers.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spoint.Api.Models.Customer;

namespace Spoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository, IMediatrHandler mediatorHandler)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _mediatorHandler = mediatorHandler;
        }

        // GET: api/Customer

        [HttpGet]
        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(_customerRepository.GetAll());
        }

        [HttpGet("{id}", Name = "Get")]
        public CustomerViewModel Get(Guid id)
        {
            var customer = _customerRepository.GetById(id);
            CustomerViewModel customerViewModel = new CustomerViewModel() { BirthDate = customer.BirthDate, Register = customer.Register, Phone =  customer.Phone, CreationDate = customer.CreationDate, Email = customer.Email, Id = customer.Id, Name = customer.Name };

            return customerViewModel;
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] CreateCustomerViewModel createCustomerViewModel)
        {
            _mediatorHandler.SendCommand(_mapper.Map<CreateCustomerCommand>(createCustomerViewModel));
            
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CustomerViewModel value)
        {
            var customer = _customerRepository.GetById(id);

            customer.BirthDate = value.BirthDate;
            customer.Email = value.Email;
            customer.Name = value.Name;
            customer.Phone = value.Phone;
            customer.Register = value.Register;

            _customerRepository.Update(customer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _customerRepository.Delete(id);
        }
    }
}
