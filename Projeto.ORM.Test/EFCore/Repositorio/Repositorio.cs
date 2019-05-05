using Microsoft.EntityFrameworkCore;
using Projeto.ORM.Test.Datasource;
using System;
using System.Linq;

namespace Projeto.ORM.Test.Repositorio
{
    public abstract class Repositorio<TEntity, ID> : IRepositorio<TEntity, ID> where TEntity : class where ID : struct
    {
        protected readonly MysqlContext Db;

        protected readonly DbSet<TEntity> DbSet;

        protected Repositorio()
        {
            Db = new MysqlContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Delete(ID id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity Find(ID id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}
