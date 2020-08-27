using Core.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Models
{
    public abstract class Entity<T> : IEntity where T : Entity<T>
    {
        protected Entity()
        {
        }

        public Guid Id { get; set; }
    }
}
