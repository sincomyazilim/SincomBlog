using SincomBlog.Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace SincomBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {//8
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null,
            params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);


    }
}
