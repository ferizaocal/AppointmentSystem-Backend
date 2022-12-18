using System;
using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace AppointmentSystem.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        IQueryable<TEntity> GetAll();
        int Count();
        IQueryable<TEntity> IncludeMany(params Expression<Func<TEntity, object>>[] includes);
        TEntity get(Expression<Func<TEntity, bool>> expression);

        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);

        bool Delete(Expression<Func<TEntity, bool>> expression);
    }
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext db;
        private DbSet<TEntity> _entities;

        public GenericRepository(ApplicationDbContext applicationDb)
        {
            db = applicationDb;
        }

        public TEntity Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
            return entity;
        }

        public bool Delete(Expression<Func<TEntity, bool>> expression)
        {
            var entity = get(expression);
            if (entity != null)
            {
                db.Remove(entity);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public TEntity get(Expression<Func<TEntity, bool>> expression)
        {
            return db.Set<TEntity>()
                .Where(expression)//bu nedir
                .AsNoTracking()//bu nedir
                .SingleOrDefault();//bu nedir
        }



        public IQueryable<TEntity> IncludeMany(params Expression<Func<TEntity, object>>[] includes)
        {
            return db.Set<TEntity>().IncludeMultiple(includes);
        }

        public TEntity Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            db.SaveChanges();
            return entity;
        }

        public int Count() => Table.Count();

        public IQueryable<TEntity> GetAll()
        {
            return db.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<TEntity> Entities => _entities ?? (_entities = db.Set<TEntity>());

    }
}

