using Core.Domain.Interfaces;
using Customers.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Customers.Domain;
using Microsoft.Extensions.Configuration;

namespace Customer.Infra.Data.Mongo
{
    public class CustomerRepository : Repository<Customers.Domain.Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration) { }

    }
}
