using Customer.Infra.Data.Mongo;
using Customer.Command;
using Customer.CommandStack.Handlers;
using Customers.Domain.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infra.CrossCutting
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            //services.AddScoped<IRequestHandler<CreateCustomerCommand, bool>, CustomerCommandHandler>();
        }
    }
}
