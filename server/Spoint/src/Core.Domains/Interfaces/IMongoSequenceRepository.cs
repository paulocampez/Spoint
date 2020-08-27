using Core.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Interfaces
{
    public interface IMongoSequenceRepository
    {
        void Insert(MongoSequence mongoSequence);
        long GetNextValue(string nomeSequence);
    }
}
