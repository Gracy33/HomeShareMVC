using HomeShare.DAL;
using HomeShareMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Areas.User.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /User/Login/
        [HttpGet]
        public ActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginForm(string login, string password)
        {
            Membre membre = Membre.authentifier(login, password);
            if (membre == null)
            {
                ViewBag.Error = "Mauvaise combinaison Login/Password";
                return View();
            }
            else
            {
                Utils.Login = membre.Prenom + " "+ membre.Nom;
                Utils.User = membre;
                return RedirectToRoute(new { area = "", controller = "Home", action = "Index" });
            }
        }

        public RedirectToRouteResult LogOut()
        {
            Utils.Login = null;
            Session.Abandon();

            return RedirectToRoute(new { area = "", controller = "Home", action = "Index" });
        }
	}
}