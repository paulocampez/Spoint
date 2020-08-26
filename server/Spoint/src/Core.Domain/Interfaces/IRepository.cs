using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
        T GetById(Guid id);
        List<T> GetAll();
        List<T> Search(Expression<Func<T, bool>> predicate);
    }
}
