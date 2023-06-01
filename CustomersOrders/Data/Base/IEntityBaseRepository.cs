using System.Linq.Expressions;

namespace CustomersOrders.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class,new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] include);
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);


    }
}
