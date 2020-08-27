using Core.Domains.Interfaces;
using Core.Domains.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infra.Data.Mongo
{
    public abstract class Repository<T> : IRepository<T> where T : Entity<T>
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient;
        protected readonly IMongoCollection<T> _mongoCollection;

        protected Repository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mongoClient = new MongoClient(_configuration["mongoConnection:server"]);
            _mongoCollection = _mongoClient.GetDatabase(_configuration["mongoConnection:database"]).GetCollection<T>(typeof(T).Name);
        }

        public void Delete(Guid id)
        {
            _mongoCollection.FindOneAndDelete(p => p.Id == id);
        }

        public List<T> GetAll()
        {
            return _mongoCollection.Find(e => true).ToList();
        }

        public T GetById(Guid id)
        {
            return _mongoCollection.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            _mongoCollection.InsertOne(entity);
        }

        public List<T> Search(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _mongoCollection.FindOneAndReplace(p => p.Id == entity.Id, entity);
        }
    }
}
