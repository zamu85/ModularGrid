namespace Model
{
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetAll();

        T GetById(int id);

        void Remove(T entity);
    }
}
