using Core.Domain.Models;
using System;

namespace Customers.Domain
{
    public class Customer : Entity<Customer>
    {
        public Customer() { }
        public string Name { get; set; }
        public string Register { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   
        public DateTime CreationDate { get; set; }
    }
}
