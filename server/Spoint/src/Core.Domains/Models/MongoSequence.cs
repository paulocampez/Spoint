using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Models
{
    public class MongoSequence
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        public string Name { get; set; }

        public long Value { get; set; }
    }
}
