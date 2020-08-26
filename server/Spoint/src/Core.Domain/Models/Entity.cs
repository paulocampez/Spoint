using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public abstract class Entity<T> : IEntity where T : Entity<T>
    {
        protected Entity()
        {
        }

        public Guid Id { get; set; }
    }
}
