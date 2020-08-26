using AutoMapper;
using Customers.Commands;
using Customers.Domain;
using Spoint.Api.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoint.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateCustomerViewModel, CreateCustomerCommand>()
              .ConstructUsing(c => new CreateCustomerCommand(c.Id, c.Name, c.Register, c.BirthDate, c.Email, c.Phone, c.CreationDate));
        }
    }
}
