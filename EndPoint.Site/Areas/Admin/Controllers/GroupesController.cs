using MetiKala.Application.Interfaces;
using MetiKala.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupesController : Controller
    {
        private readonly IProductsService _productsService;
        public GroupesController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        // GET: GroupesController
        public ActionResult Index(int? id)
        {
            List<ProductsGroupe> groupes;
            if (id==null)
            {
                groupes = _productsService.GetParentGroupes();
            }
            else
            {
                groupes = _productsService.GetSubGroupes(id.Value);
            }
            return View(groupes);
        }

        // GET: GroupesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupesController/Create
        public ActionResult Create(int? id)
        {
            return View(new ProductsGroupe { ParentID=id});
        }

        // POST: GroupesController/Create
        [HttpPost]
    
        public ActionResult Create(ProductsGroupe groupe)
        {
            _productsService.AddGroupes(groupe);
            return RedirectToAction("Index");
        }

        // GET: GroupesController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_productsService.GetProductsGroupeByID(id));
        }

        // POST: GroupesController/Edit/5
        [HttpPost]
       
        public ActionResult Edit(ProductsGroupe groupe)
        {

            _productsService.EditGroupe(groupe);
            return RedirectToAction("Index");
        }

        // GET: GroupesController/Delete/5
        public ActionResult Delete(int id)
        {
            var groupe = _productsService.GetProductsGroupeByID(id);
            return View(groupe);
        }

        // POST: GroupesController/Delete/5
        [HttpPost]
        
        public ActionResult Delete(ProductsGroupe groupe)
        {
            _productsService.DeletGroupe(groupe.GroupeID);
            return RedirectToAction("Index");
        }
    }
}
