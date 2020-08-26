using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spoint.Api.Models.Customer
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Register { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
