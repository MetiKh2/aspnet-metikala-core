using MetiKala.Application.DTOs.Discount;
using MetiKala.Application.DTOs.Product;
using MetiKala.Application.Interfaces;
using MetiKala.Common.Convertors;
using MetiKala.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IDatabaseContext _context;
       private readonly IUserService _userService;
        //private readonly IOrderService _orderService;
        public ProductsService(IDatabaseContext context, IUserService userService/*,IOrderService orderService*/)
        {
            _context = context;
          //  _orderService = orderService;
            _userService = userService;
          
        }
        public void AddGroupes(ProductsGroupe groupe)
        {
            _context.ProductsGroupes.Add(groupe);
            _context.SaveChanges();
        }

        public int AddProduct(Product product, IFormFile image)
        {
            if (image!=null)
            {
                product.Image = GeneratCode.GenerateUniqCode()+Path.GetExtension(image.FileName);
              string imagePath=  Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/products/images",product.Image);
                using (var stream =new FileStream(imagePath,FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                ImageConvertor resizer = new ImageConvertor();
                string thumbPath= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products/ThumbImages", product.Image);
                resizer.Image_resize(imagePath,thumbPath,130);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.ProductID;
        }

        public bool AddProductFeatures(int productId, List<AddProduct_Feature> features)
        {
            try
            {
                foreach (var item in features)
                {
                    _context.ProductFeatures.Add(new ProductFeature { Display = item.DisplayName, Value = item.Value, ProductID = productId });
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            product.IsRemoved = true;
            _context.SaveChanges();
        }

        public  void DeletGroupe(int groupeId)
        {
            var groupe = GetProductsGroupeByID(groupeId);
            groupe.IsRemoved = true;
            _context.SaveChanges();
        }

        public void EditGroupe(ProductsGroupe groupe)
        {
            _context.ProductsGroupes.Update(groupe);
            _context.SaveChanges();
        }

        public void EditProduct(Product product, IFormFile file)
        {
            if (file!=null)
            {
                if (product.Image!=null)
                {
                    var deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products/images", product.Image);
                    var deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products/ThumbImages", product.Image);
                    if (File.Exists(deletePath))
                    {
                        File.Delete(deletePath);
                    }
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }
                product.Image = GeneratCode.GenerateUniqCode() + Path.GetExtension(file.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products/images", product.Image);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                ImageConvertor resizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products/ThumbImages", product.Image);
                resizer.Image_resize(imagePath, thumbPath, 130);
            }

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public bool EditProductFeatures(int productId, List<AddProduct_Feature> features)
        {
            try
            {

                var lastProductFeatures = _context.ProductFeatures.Where(p => p.ProductID == productId).ToList();
                foreach (var item in lastProductFeatures)
                {
                    _context.ProductFeatures.Remove(item);
                }
                AddProductFeatures(productId, features);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ExistDiscountCode(string code)
        {
            return _context.Discounts.Any(p=>p.DiscountCode==code);
        }

        public List<ProductsGroupe> GetAllGroupes()
        {
            return _context.ProductsGroupes.ToList();
        }

        public List<SelectListItem> GetGrandParentProductsForAddProduct()
        {
            return _context.ProductsGroupes.Where(p => p.ParentID == null).Select(p => new SelectListItem
            { Text = p.GroupeTitle, Value = p.GroupeID.ToString() }).ToList();
        }

        public int GetParentGroupeBtProductID(int id)
        {
            return _context.Products.Where(p => p.ProductID == id).Select(p=>p.ParentGroupeID).FirstOrDefault();
        }

        public List<ProductsGroupe> GetParentGroupes()
        {
            return _context.ProductsGroupes.Where(p => p.ParentID == null).ToList();
        }

        public List<SelectListItem> GetParentGroupesForAddProduct(int grandId)
        {
            return _context.ProductsGroupes.Where(p => p.ParentID == grandId).Select(p => new SelectListItem
            { Text = p.GroupeTitle, Value = p.GroupeID.ToString() }).ToList();
        }

        public Product GetProductByID(int id)
        {
            return _context.Products.Find(id);
        }

        public List<ProductFeature> GetProductFeatures(int productId)
        {
            return _context.ProductFeatures.Where(p => p.ProductID == productId).ToList();
        }

        public List<ProductFeature> GetProductFeaturesByProductID(int id)
        {
            return _context.ProductFeatures.Where(p => p.ProductID == id).ToList();
        }

        public Tuple<List<Product>,int> GetProducts(string filter="",int pageId=1, int groupeId=0)
        {
            IQueryable<Product> products = _context.Products.Include(p=>p.SubGroupe).Include(p=>p.ParentGroupe).Include(p=>p.GrandParentGroupe);
            int take=3;
            if (!string.IsNullOrEmpty(filter))
            {
                products = products.Where(p=>p.ProductTitle.Contains(filter));
                take = 10000;
            }

            if (groupeId!=0)
            {

                products = products.Where(p => p.ParentGroupeID == groupeId || p.SubGroupeID == groupeId || p.GrandParentGroupeID == groupeId);
                take = 10000;
            }

            int skip = (pageId - 1) * take;
            int pageCount = products.Count() / take;
            return Tuple.Create(products.OrderByDescending(p=>p.ProductID).Skip(skip).Take(take).ToList(),pageCount);
        }

        public ProductsGroupe GetProductsGroupeByID(int id)
        {
            return _context.ProductsGroupes.Find(id);
        }

        public int GetSubGroupeBtProductID(int id)
        {
            var result = _context.Products.FirstOrDefault(p => p.ProductID == id);
            if (result.SubGroupeID==null)
            {
                return 0;
            }
            return result.SubGroupeID.Value;
        }

        public List<ProductsGroupe> GetSubGroupes(int parentId)
        {
            return _context.ProductsGroupes.Where(p => p.ParentID == parentId).ToList();

        }

        public List<SelectListItem> GetSubProductsForAddProduct(int parentId)
        {
            return _context.ProductsGroupes.Where(p => p.ParentID == parentId).Select(p => new SelectListItem
            { Text = p.GroupeTitle, Value = p.GroupeID.ToString() }).ToList();
        }

        public UserDiscountResult UseDiscount(string code, string username, int orderId)
        {
            var userId = _userService.GetUserIDByUserName(username);
            var discount = _context.Discounts.Where(p => p.DiscountCode == code).FirstOrDefault(); if (discount == null)
            {
                return UserDiscountResult.NotFound;
            }
            var userDiscount = _context.UserDiscount.Any(p => p.UserID == userId && p.DiscountID == discount.DiscountID);
            var order = _context.Orders.Where(p=>p.UserID==userId&&p.OrderID==orderId).FirstOrDefault();
            if (userDiscount == true)
            {
                return UserDiscountResult.UserUsed;
            }
            if (discount.CountUse < 1)
            {
                return UserDiscountResult.EndUseCount;
            }
          
            if (discount.StartDate > DateTime.Now)
            {
                return UserDiscountResult.expireDate;
            }
            if (discount.EndDate < DateTime.Now)
            {
                return UserDiscountResult.expireDate;
            }
          var discountSum=(order.SumAmount*discount.DiscountPercent )/ 100;
            order.SumAmount = order.SumAmount - discountSum;
            _context.SaveChanges();
            return UserDiscountResult.Success;
        }
    }
}
