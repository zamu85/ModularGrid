using Microsoft.EntityFrameworkCore;
using Model;
using System.Linq.Expressions;

namespace Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IDbContextFactory<PatientContext> _context;

        public GenericRepository(IDbContextFactory<PatientContext> context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            using var context = _context.CreateDbContext();
            context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            using var context = _context.CreateDbContext();
            context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            using var context = _context.CreateDbContext();
            return context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            using var context = _context.CreateDbContext();
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var context = _context.CreateDbContext();
            return context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            using var context = _context.CreateDbContext();
            context.Set<T>().Remove(entity);
        }
    }
}
