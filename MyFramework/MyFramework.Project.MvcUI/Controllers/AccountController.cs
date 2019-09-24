using MyFramework.Core.CrossCuttingConcerns.Security.Web;
using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFramework.Project.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        IUserManager _userService;
        public AccountController(IUserManager userManager)
        {
            _userService = userManager;
        }
        public string Login(string name,string pass)
        {
            var user = _userService.GetUserNameAndPassword(name, pass);
            if (user!=null)
            {
                AuthHelper.CreateAuthCookie(new Guid(), user.Name, "black@gmail.com", DateTime.Now.AddMinutes(15),user.myRole,false);
                return "Auth Başarılı";
            }
            else
            {
                return "Auth BAŞARISIZ";
            }

            
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            _userService.Add(user);

            return RedirectToAction("Index","Product");
        }
    }
}