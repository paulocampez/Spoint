﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
