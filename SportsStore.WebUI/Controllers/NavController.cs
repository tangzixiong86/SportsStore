using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }
        // GET: Nav
        //public PartialViewResult Menu(string category=null, bool horizontalLayout = false)
        //{
        //    ViewBag.SelectedCategory = category;

        //    IEnumerable<string> categories = this.repository.Products
        //        .Select(x => x.Category)
        //        .Distinct()
        //        .OrderBy(x => x);
        //    string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
        //    return PartialView(viewName, categories);
        //}
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = this.repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
           
            return PartialView("FlexMenu", categories);
        }
    }
}