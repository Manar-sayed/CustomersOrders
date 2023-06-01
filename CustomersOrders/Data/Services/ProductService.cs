using CustomersOrders.Data.Base;
using CustomersOrders.Models;

namespace CustomersOrders.Data.Services
{
    public class ProductService :EntityBaseRepository<Products>,IProductService
    {
        public ProductService(AppDBContext context) : base(context) { }
        
    }
}
