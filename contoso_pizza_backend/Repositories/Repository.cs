using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using contoso_pizza_backend.Data;
using contoso_pizza_backend.Repositories.Interfaces;

namespace contoso_pizza_backend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly ContosoPizzaContext context;
        public Repository(ContosoPizzaContext context)
        {
            this.context=context;
        }

        public async Task<T> Get(string id)
            => await context.Set<T>().FindAsync(id);
        public async Task<T> Find(Expression<Func<T, bool>> predicate)
            => await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        public async Task<IEnumerable<T>> GetAll()
            => await context.Set<T>().ToListAsync();
        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
            => await context.Set<T>().Where(predicate).ToListAsync();
        public void Add(T entity) 
        {
            context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}