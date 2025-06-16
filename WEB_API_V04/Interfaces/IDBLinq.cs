using System.Linq.Expressions;

namespace WEB_API_V04.Interfaces
{
    public interface IDBLinq<T>
    {
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression);
    }
}
