using Microsoft.AspNetCore.Mvc;
using MvcThreeLayerDemo.Models;
using MvcThreeLayerDemo.Services;
using System.Diagnostics;

namespace MvcThreeLayerDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var productVms = _productService.GetProductVms();
            return View(productVms);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
