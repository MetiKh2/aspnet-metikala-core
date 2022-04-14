using MetiKala.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class SearchComponenet:ViewComponent
    {
        private readonly IProductsService _productService;
        public SearchComponenet(IProductsService productsService)
        {
            _productService = productsService;
        }
        public IViewComponentResult Invoke()
        {
            return View("Search",_productService.GetProducts().Item1);
        }
    }
}
