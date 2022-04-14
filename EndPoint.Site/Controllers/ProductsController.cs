using MetiKala.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productsService)
        {
            _productService = productsService;
        }
        public IActionResult Index(string filter="",int pageId=1,int groupeId=0)
        {
            return View(_productService.GetProducts(filter,pageId,groupeId));
        }
        [Route("ShowProduct/{id}")]
        public IActionResult ShowProduct(int id)
        {
            ViewBag.features = _productService.GetProductFeatures(id);
            return View(_productService.GetProductByID(id));
        }
    }
}
