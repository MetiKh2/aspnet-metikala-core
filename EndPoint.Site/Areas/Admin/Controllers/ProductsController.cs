using MetiKala.Application.DTOs.Product;
using MetiKala.Application.Interfaces;
using MetiKala.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        // GET: ProductsController
        public ActionResult Index(string filter="",int pageId=1)
        {

            return View(_productsService.GetProducts(filter,pageId));
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        #region Add


        // GET: ProductsController/Create
        public ActionResult Create()
        {
            var GrandParentGroupes = _productsService.GetGrandParentProductsForAddProduct();
            ViewBag.GranParentGroupes = new SelectList(GrandParentGroupes, "Value", "Text");

            var ParentGroupes = _productsService.GetParentGroupesForAddProduct(int.Parse(GrandParentGroupes.FirstOrDefault().Value));
            ViewBag.ParentGroupes = new SelectList(ParentGroupes, "Value", "Text");

            ViewBag.SubGroupes = new SelectList(_productsService.GetSubProductsForAddProduct(int.Parse(ParentGroupes.FirstOrDefault().Value)), "Value", "Text");

            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]

        public ActionResult Create(Product product, IFormFile file/*, List<AddProduct_Feature> features*//*List<string> featuresDisplay,List<string> featuresValue*/)
        {
            if (!ModelState.IsValid)
            {
                var GrandParentGroupes = _productsService.GetGrandParentProductsForAddProduct();
                ViewBag.GranParentGroupes = new SelectList(GrandParentGroupes, "Value", "Text");

                var ParentGroupes = _productsService.GetParentGroupesForAddProduct(int.Parse(GrandParentGroupes.FirstOrDefault().Value));
                ViewBag.ParentGroupes = new SelectList(ParentGroupes, "Value", "Text");

                ViewBag.SubGroupes = new SelectList(_productsService.GetSubProductsForAddProduct(int.Parse(ParentGroupes.FirstOrDefault().Value)), "Value", "Text");
                return View(product);

            }
            int productId = _productsService.AddProduct(product, file);
            //_productsService.AddProductFeatures(productId, features);
            return Redirect("/Admin/Products/AddFeatures/" + productId);
        }

        public IActionResult AddFeatures(int id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult AddFeatures(int id, List<AddProduct_Feature> features)
        {

            return Json(_productsService.AddProductFeatures(id, features));
        }
        #endregion

        #region Edit
        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productsService.GetProductByID(id);


            if (product == null)
            {
                return NotFound();
            }
            var GrandParentGroupes = _productsService.GetGrandParentProductsForAddProduct();
            ViewBag.GranParentGroupes = new SelectList(GrandParentGroupes, "Value", "Text");

            var ParentGroupes = _productsService.GetParentGroupesForAddProduct(product.GrandParentGroupeID.Value);
            ViewBag.ParentGroupes = new SelectList(ParentGroupes, "Value", "Text", product.ParentGroupeID);

            ViewBag.SubGroupes = new SelectList(_productsService.GetSubProductsForAddProduct(product.ParentGroupeID), "Value", "Text", product.SubGroupeID);

            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]

        public ActionResult Edit(Product product, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                var GrandParentGroupes = _productsService.GetGrandParentProductsForAddProduct();
                ViewBag.GranParentGroupes = new SelectList(GrandParentGroupes, "Value", "Text");

                var ParentGroupes = _productsService.GetParentGroupesForAddProduct(product.GrandParentGroupeID.Value);
                ViewBag.ParentGroupes = new SelectList(ParentGroupes, "Value", "Text", product.ParentGroupeID);

                ViewBag.SubGroupes = new SelectList(_productsService.GetSubProductsForAddProduct(product.ParentGroupeID), "Value", "Text", product.SubGroupeID);
                return View(product);
            }
            _productsService.EditProduct(product, file);
            return Redirect("/Admin/Products/EditFeatures/" + product.ProductID);
        }
        public IActionResult EditFeatures(int id)
        {
            ViewBag.productId = id;
            return View(_productsService.GetProductFeaturesByProductID(id));
        }
        [HttpPost]
        public IActionResult EditFeatures(int id, List<AddProduct_Feature> features)
        {

            return Json(_productsService.EditProductFeatures(id, features));
        }
        #endregion
        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productsService.GetProductByID(id);
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            _productsService.DeleteProduct(product.ProductID);
            return Redirect("/Admin/Products/Index");
        }

        public IActionResult GetSubGroups(int parentId)
        {
            List<SelectListItem> list = new List<SelectListItem> { 
            new SelectListItem{ Text="للطفا انتخاب کنید",Value=""}
            };

            list.AddRange(_productsService.GetSubProductsForAddProduct(parentId));
            return Json(new SelectList(list,"Value","Text"));
        }

        public IActionResult GetParentGroups(int grandId)
        {
            List<SelectListItem> list = new List<SelectListItem> {
            new SelectListItem{ Text="للطفا انتخاب کنید",Value=""}
            };

            list.AddRange(_productsService.GetParentGroupesForAddProduct(grandId));
            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}
