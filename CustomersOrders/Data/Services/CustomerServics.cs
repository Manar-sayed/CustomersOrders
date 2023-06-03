using CustomersOrders.Data.Base;
using CustomersOrders.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomersOrders.Data.Services
{
    public class CustomerServics :EntityBaseRepository<Customers>,ICustomerservice
    {
        private readonly AppDBContext _context;
        public CustomerServics(AppDBContext context):base(context){ _context = context; }
        public async Task<Customers> GetCustomerByIdAsync(int id)
        {
            var customerDetails = await _context.Customers
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.ID == id);
            return customerDetails;
        }
    }
}
