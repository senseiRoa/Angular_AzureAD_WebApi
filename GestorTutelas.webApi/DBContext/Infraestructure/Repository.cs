using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GestorTutelas.webApi.DBContext.Infraestructure
{
     public class Repository<T,TContext> : IRepository<T> where T : class where TContext: DbContext
    {
        private readonly TContext context;

        public Repository(TContext context)
        {
           this.context = context;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public bool Insert(T entity)
        {
            try
            {
                if (entity == null) return false;

                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                if (entity == null) return false;

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Update(object id, T entity)
        {
            try
            {
                var original = context.Set<T>().Find(id);
                //if (original is Usuario)
                //{
                //    ((Usuario)entity).clave = ((Usuario)original).clave;
                //}
                context.Entry(original).CurrentValues.SetValues(entity);
                context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool DeleteEntity(T entity)
        {
            try
            {
                if (entity == null) return false;

                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            
            catch (Exception ex)
            {
                throw;
            }
        }

        public T GetById(object id)
        {
            var entity = context.Set<T>().Find(id);           

            return  entity;
        }

        public IQueryable<T> Table => context.Set<T>();

        public bool Delete(object id)
        {
            try
            {
                var entity = GetById(id);

                
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool SaveAll(List<T> list)
        {
            try
            {
                context.Set<T>().AddRange(list);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool UpdateAll(List<T> list)
        {
            try
            {
                list.ForEach(entity =>
                {
                    context.Entry(entity).State = EntityState.Modified;
                });

                context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

   
}
