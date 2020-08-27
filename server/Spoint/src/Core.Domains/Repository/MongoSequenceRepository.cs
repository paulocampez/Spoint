using Core.Domains.Interfaces;
using Core.Domains.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Repository
{

    public class MongoSequenceRepository : IMongoSequenceRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient;
        protected readonly IMongoCollection<MongoSequence> _mongoCollection;

        public MongoSequenceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["mongoConnection:server"]);
            _mongoCollection = _mongoClient.GetDatabase(_configuration["mongoConnection:database"]).GetCollection<MongoSequence>(typeof(MongoSequence).Name);
        }

        public long GetNextValue(string nomeSequence)
        {
            var sequence = _mongoCollection.Find(s => s.Name == nomeSequence).FirstOrDefault();

            if (sequence == null)
            {
                _mongoCollection.InsertOne(new MongoSequence { Name = nomeSequence, Value = 1 });
                return 1;
            }

            sequence.Value++;
            _mongoCollection.FindOneAndReplace(s => s._Id == sequence._Id, sequence);
            return sequence.Value;
        }

        public void Insert(MongoSequence mongoSequence)
        {
            _mongoCollection.InsertOne(mongoSequence);
        }
    }
}
