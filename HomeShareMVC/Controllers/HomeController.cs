using HomeShare.DAL;
using HomeShareMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Wrapper lstBien = new Wrapper();
            lstBien.DernierBien = Bien.getDerniersBiens();
            lstBien.MeilleursBiens = Bien.getMeilleurEchange();
            return View(lstBien);
        }

    }
}