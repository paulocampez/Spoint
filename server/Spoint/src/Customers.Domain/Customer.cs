using Core.Domains.Models;
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
        public string Password { get; private set; }
        public DateTime CreationDate { get; set; }

        public static class Factory
        {
            public static Customer CreateNewCustomer(Guid id, string name, string register, DateTime birthDate, string email, string phone, string password, DateTime creationDate) =>
                new Customer
                {
                    Id = id,
                    Name = name,
                    Register = register,
                    BirthDate = birthDate,
                    Email = email,
                    Phone = phone,
                    Password = password,
                    CreationDate = creationDate
                };
        }
    }
}
