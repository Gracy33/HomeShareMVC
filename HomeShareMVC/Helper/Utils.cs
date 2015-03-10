using HomeShare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Helper
{
    public class Utils
    {
        public static Membre User
        {
            get
            {
                if ((Membre)HttpContext.Current.Session["user"] == null)
                {
                    HttpContext.Current.Session["user"] = new Membre();
                }
                return (Membre)HttpContext.Current.Session["user"];
            }
            set { HttpContext.Current.Session["user"] = value; }
        }

        public static string Login
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["login"].ToString();
                }
                catch
                {
                    return null;
                }
            }

            set
            {
                HttpContext.Current.Session["login"] = value;
            }
        }
    }
}