using EjemploRepartos_database.Context;
using EjemploRepartos_repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploRepartos_repository.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly EjemploRepartosContext _context;

        /// <summary>
        /// 
        /// </summary>
        protected GenericRepository(EjemploRepartosContext context)
        {
            _context = context;
        }
      
        public T CreateGeneric<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public List<T> CreateRangeGeneric<T>(List<T> entity) where T : class
        {
            this._context.Set<T>().AddRange(entity);
            return entity;
        }

        public T UpdateGeneric<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public List<T> UpdateRangeGeneric<T>(List<T> entity) where T : class
        {
            this._context.Set<T>().UpdateRange(entity);
            return entity;
        }

        public T RemoveGeneric<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public List<T> RemoveRangeGeneric<T>(List<T> entity) where T : class
        {
            this._context.Set<T>().RemoveRange(entity);
            return entity;
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
