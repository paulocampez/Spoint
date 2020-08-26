using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.Interfaces;
using Customers.Commands;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] CreateCustomerViewModel createCustomerViewModel)
        {
            _mediatorHandler.SendCommand(_mapper.Map<CreateCustomerCommand>(createCustomerViewModel));
            
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
