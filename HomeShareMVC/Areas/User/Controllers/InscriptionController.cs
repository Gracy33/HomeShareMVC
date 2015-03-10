using HomeShare.DAL;
using HomeShareMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Areas.User.Controllers
{
    public class InscriptionController : Controller
    {
        [HttpGet]
        public ActionResult InscriptionForm()
        {
            Wrapper membrePays = new Wrapper();
            membrePays.LesPays = Pays.getAllPays();
            return View(membrePays);
        }

        [HttpPost]
        public ActionResult InscriptionForm(string txtNom, string txtPrenom, string txtEmail, int pays, string txtPhone, string txtLogin, string txtPassword)
        {
            Membre m = new Membre();
            m.saveMembre(txtNom, txtPrenom, txtEmail, pays, txtPhone, txtLogin, txtPassword);
            return RedirectToRoute(new { area = "User", controller = "Login", action = "LoginForm" });
        }
	}
}