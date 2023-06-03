using CustomersOrders.Data.Services;
using CustomersOrders.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomersOrders.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        public IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products= await _productService.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetById(id);


            if (product == null)
            {
                return View("NotFound");
            }
            return View(product);
        }

        public IActionResult Create()=> View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


    }
}
