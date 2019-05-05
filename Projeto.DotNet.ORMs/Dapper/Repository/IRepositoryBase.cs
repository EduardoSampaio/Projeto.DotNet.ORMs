using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Projeto.DotNet.ORMs.Dapper.Repository
{
    public interface IRepositoryBase<TEntity> where  TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Int32 id);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
    }
}
