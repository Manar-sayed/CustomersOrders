using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace CustomersOrders.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class,IEntitybase, new()
    {
        private readonly AppDBContext _dbContext;
        public EntityBaseRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAll()=>await _dbContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query=include.Aggregate(query,(current,include)=>current.Include(include));
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)=>await _dbContext.Set<T>().FirstOrDefaultAsync(x=>x.ID==id);

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            EntityEntry entityEntry= _dbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var obj=await _dbContext.Set<T>().FirstOrDefaultAsync(x=>x.ID==id);
            EntityEntry entityEntry=_dbContext.Entry<T>(obj);
            entityEntry.State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
