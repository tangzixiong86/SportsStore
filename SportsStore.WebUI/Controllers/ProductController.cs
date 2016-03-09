using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        // GET: Product
        public ViewResult List(string category,int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = this.repository.Products
                    .Where(p=>category==null||p.Category==category)
                    .OrderBy(p => p.ProductID)
                    .Skip(PageSize*(page - 1))
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = this.repository.Products.Where(e =>category==null|| e.Category == category).Count()
                },
                CurrentCategory = category
            };
         
            return View(model);
        }
        public FileContentResult GetImage(int productID)
        {
            Product product = this.repository.Products.FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}