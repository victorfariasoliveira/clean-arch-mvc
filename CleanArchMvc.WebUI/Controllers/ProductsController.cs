using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService= productService;
        }
        public async Task<IActionResult> Index()
        {
            var prodcuts = await _productService.GetProducts();
            return View(prodcuts);
        }
    }
}
