using CustomersOrders.Data.Base;
using CustomersOrders.Models;

namespace CustomersOrders.Data.Services
{
    public class CustomerServics :EntityBaseRepository<Customers>,ICustomerservice
    {
        public CustomerServics(AppDBContext context):base(context){}
    }
}
