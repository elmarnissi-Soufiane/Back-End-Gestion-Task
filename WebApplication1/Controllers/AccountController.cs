using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        CraftEntities entity = new CraftEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = entity.Admines.Any(x => x.Email == credentials.Email && x.Pass == credentials.Pass);
            Admine u = entity.Admines.FirstOrDefault(x => x.Email == credentials.Email && x.Pass == credentials.Pass);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Email, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "something worng");

            return View();
        }
        [HttpPost]
        public ActionResult Signup(Admine admineinfo)
        {
            entity.Admines.Add(admineinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}