using HomeShare.DAL;
using HomeShareMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Controllers
{
    public class BienController : Controller
    {
        //
        // GET: /Bien/
        public ActionResult Details(int id, int idM)
        {
            Session["CurrentController"] = this;
            Wrapper membreBien = new Wrapper();
            membreBien.LeBien = Bien.getBien(id);
            membreBien.LeMembre = Membre.getInfo(idM);
            return View(membreBien);
        }

        //public ActionResult AjouterAvis(int note, string txtMessage, int idMembre, int idB, bool approuve)
        //{
        //    Avis.AddAvis(note, txtMessage, idMembre, idB, approuve);
        //    return new RedirectResult("/Bien/Details/" + id + "/" + idM);
        //}
	}
}