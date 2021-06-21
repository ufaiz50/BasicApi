﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        IEnumerable<Entity> Get();
        Entity GetNIK(Key key);

        int Insert(Entity entity);
        int Update(Entity entity, Key key);
        int Delete(Key key);
    }
}
