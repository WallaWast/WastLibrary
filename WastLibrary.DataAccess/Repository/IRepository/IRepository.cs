using System.Linq.Expressions;

namespace WastLibrary.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Remove(T entity);

        void RemoveRaange(IEnumerable<T> entities);
    }
}
