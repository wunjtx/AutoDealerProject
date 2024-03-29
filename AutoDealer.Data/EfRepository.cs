﻿using AutoDealer.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealer.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext dbContext;

        private IDbSet<T> dbSet;

        protected virtual IDbSet<T> DbSet
        {
            get
            {
                this.dbSet = this.dbSet ?? dbContext.Set<T>();
                return this.dbSet;
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return this.DbSet;
            }
        }

        public EfRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }
        public IDbSet<T> GetSet()
        {
            return this.dbSet;
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.DbSet.Add(entity);
            this.dbContext.SaveChanges();

        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.dbContext.SaveChanges();
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetEntitiesIndex<S>(int pageIndex, int pageCount, out int Total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            throw new NotImplementedException();
        }
    }
}
