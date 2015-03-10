using HomeShare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Models
{
    public class Wrapper
    {
        List<Bien> _meilleursBiens;
        List<Bien> _dernierBien;
        List<Pays> _lesPays;
        Bien _leBien;
        Membre _leMembre;

        public List<Bien> MeilleursBiens
        {
            get { return _meilleursBiens; }
            set { _meilleursBiens = value; }
        }

        public List<Bien> DernierBien
        {
            get { return _dernierBien; }
            set { _dernierBien = value; }
        }

        public List<Pays> LesPays
        {
            get { return _lesPays; }
            set { _lesPays = value; }
        }

        public Bien LeBien
        {
            get { return _leBien; }
            set { _leBien = value; }
        }

        public Membre LeMembre
        {
            get { return _leMembre; }
            set { _leMembre = value; }
        }
    }
}