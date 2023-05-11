using Microsoft.EntityFrameworkCore;
using SincomBlog.Shared.Data.Abstract;
using SincomBlog.Shared.Entities.Abstract;
using System.Linq.Expressions;

namespace SincomBlog.Shared.Data.Concrete.EntityFramework
{
    public class EfCoreEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {//9
        private readonly DbContext _context;

        public EfCoreEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }
        //------------------------------------------------------------
        public async Task AddAsync(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
           await Task.Run(()=> { _context.Set<TEntity>().Remove(entity); });//burda RemoveAsync olmadıgı ıcın Task.Run kodunu eklıyoruz
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, 
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query=_context.Set<TEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties) 
                { 
                    query=query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(()=>{ _context.Set<TEntity>().Update(entity); });
        }
    }
}
