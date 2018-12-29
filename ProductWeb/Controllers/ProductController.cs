using System;
using System.Web.Mvc;
using Product.Services;

namespace ProductWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }
        
        // GET
        public ActionResult View(Int32 id)
        {
            return View(_productService.GetById(id));
        }
    }
}