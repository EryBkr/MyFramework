using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Entities.Concrete;
using MyFramework.Project.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Project.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        IProductManager _productManager;
        IUserManager _userManager;
        public ProductController(IProductManager productManager,IUserManager userManager)
        {
            _productManager = productManager;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            
            var model = new ProductListViewModel()
            {
                Products = _productManager.GetAll().ToList()
            };
            ViewBag.Users = _userManager.GetAll().ToList();
            
            return View(model);
        }

       

      
    }
}