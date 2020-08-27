using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domains;

namespace Customer.Command
{
    public class CreateCustomerCommand : Core.Domains.Commands.Command
    {
        public CreateCustomerCommand(Guid id, string name, string register, DateTime birthDate, string email, string phone, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Register = register;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
            CreationDate = creationDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Register { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
