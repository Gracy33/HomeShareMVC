using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Echange
    {
        #region Fields
        private int _idMembre;
        private int _idBien;
        private DateTime _dateDebEchange;
        private DateTime _dateFinEchange;
        private bool _assurance;
        private bool _valide = false; 
        #endregion

        #region Getters/Setters
        public int IdMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public int IdBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }

        public DateTime DateDebEchange
        {
            get { return _dateDebEchange; }
            set { _dateDebEchange = value; }
        }

        public DateTime DateFinEchange
        {
            get { return _dateFinEchange; }
            set { _dateFinEchange = value; }
        }

        public bool Assurance
        {
            get { return _assurance; }
            set { _assurance = value; }
        }

        public bool Valide
        {
            get { return _valide; }
            set { _valide = value; }
        } 
        #endregion

        public Echange() { }

        public static List<Echange> getEchanges()
        {
            List<Dictionary<string, object>> echanges = GestionConnexion.Instance.getData("select * from MembreBienEchange");
            List<Echange> lstEchanges = new List<Echange>();
            foreach (Dictionary<string, object> echange in echanges)
            {
                Echange e = new Echange();
                e.IdMembre = int.Parse(echange["idMembre"].ToString());
                e.IdBien = int.Parse(echange["idBien"].ToString());
                e.DateDebEchange = DateTime.Parse(echange["DateDebEchange"].ToString());
                e.DateFinEchange = DateTime.Parse(echange["DateFinEchange"].ToString());
                if (echange["Assurance"].ToString() != "")
                {
                    e.Assurance = bool.Parse(echange["Assurance"].ToString());
                }
                e.Valide = bool.Parse(echange["Valide"].ToString());
                lstEchanges.Add(e);
            }
            return lstEchanges;
        }
    }
}
