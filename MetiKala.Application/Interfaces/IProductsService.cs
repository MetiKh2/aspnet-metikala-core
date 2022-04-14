using MetiKala.Application.DTOs.Discount;
using MetiKala.Application.DTOs.Product;
using MetiKala.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetiKala.Application.Interfaces
{
   public interface IProductsService
    {
        #region Groupes

        void AddGroupes(ProductsGroupe groupe);
        List<ProductsGroupe> GetParentGroupes();
        List<ProductsGroupe> GetAllGroupes();
        List<ProductsGroupe> GetSubGroupes(int parentId);
        ProductsGroupe GetProductsGroupeByID(int id);
        void DeletGroupe(int groupeId);
        void EditGroupe(ProductsGroupe groupe);
        #endregion

        #region Products
        List<SelectListItem> GetGrandParentProductsForAddProduct();
        List<SelectListItem> GetParentGroupesForAddProduct(int grandId);
        List<SelectListItem> GetSubProductsForAddProduct(int parentId);
        int AddProduct(Product product,IFormFile image);
        bool AddProductFeatures(int productId,List<AddProduct_Feature> features);
        Product GetProductByID(int id);
        void EditProduct(Product product,IFormFile file);
        int GetParentGroupeBtProductID(int id);
        int GetSubGroupeBtProductID(int id);
        List<ProductFeature> GetProductFeaturesByProductID(int id);
        bool EditProductFeatures(int productId, List<AddProduct_Feature> features);
        Tuple<List<Product>, int> GetProducts(string filter = "", int pageId = 1,int groupeId=0);
        void DeleteProduct(int productId);
        //Tuple<List<Product>, int> GetProducts(int pageId=1,string filter="",int groupeId=0);
        List<ProductFeature> GetProductFeatures(int productId);

        #endregion

        #region Discount
        UserDiscountResult UseDiscount(string code ,string username,int orderId);
        bool ExistDiscountCode(string code);
        #endregion
    }
}
