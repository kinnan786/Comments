using System;
using System.Collections.Generic;
using Comments.Data.Context;
using Comments.Data.Implementation;

namespace Comments.Data.Uow
{
    public class Uow : UnitOfWork
    {
        public Uow()
        {
            DbContext = new SmoEntities();
            Repositories = new Dictionary<Type, object>();
        }
    }
}