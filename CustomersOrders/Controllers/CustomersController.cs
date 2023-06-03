using CustomersOrders.Data.Services;
using CustomersOrders.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomersOrders.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        public ICustomerservice _customerservice;
        public CustomersController(ICustomerservice customerservice)
        {
            _customerservice = customerservice;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _customerservice.GetAll(x=>x.Products);
            return View(customers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerservice.GetCustomerByIdAsync(id);
            return View(customer);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                await _customerservice.Add(customer);

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var allCustomers = await _customerservice.GetAll(m => m.Products);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredCustomer = allCustomers.Where(n => n.FullName.ToUpper().Contains(searchString.ToUpper()) || n.FullName.Contains(searchString.ToUpper())).ToList();
                return View("Index", filteredCustomer);
            }

            return View("Index", allCustomers);
        }

    }
}
