using MetiKala.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class ProcductsGroupesComponent:ViewComponent
    {
        private readonly IProductsService _productsService;
        public ProcductsGroupesComponent(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public IViewComponentResult Invoke()
        {
            return View("ProcductsGroupes", _productsService.GetAllGroupes());
        }
    }
}
