using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Pays
    {
        #region Fields
        private int _idPays;
        private string _libelle;
        public List<Bien> _biensParPays;
        #endregion

        #region Getters/Setters;
        public int IdPays
        {
            get { return _idPays; }
            set { _idPays = value; }
        }

        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }

        public List<Bien> BiensParPays
        {
            get
            {
                if (_biensParPays == null) _biensParPays = ChargerLesBiens();
                return _biensParPays;
            }
        }
        #endregion

        public Pays() { }

        private List<Bien> ChargerLesBiens()
        {
            return Bien.getBienParPays(this.IdPays);
        }

        public static Pays getPays(int id)
        {
            List<Dictionary<string, object>> pays = GestionConnexion.Instance.getData("select * from Pays where idPays =" + id);

            Pays p = new Pays();
            p.IdPays = int.Parse(pays[0]["idPays"].ToString());
            p.Libelle = pays[0]["Libelle"].ToString();

            return p;
        }

        public static List<Pays> getAllPays()
        {
            List<Dictionary<string, object>> lesPays = GestionConnexion.Instance.getData("select * from Pays");
            List<Pays> lstPays = new List<Pays>();
            foreach (Dictionary<string, object> pays in lesPays)
            {
                Pays p = new Pays();
                p.IdPays = int.Parse(pays["idPays"].ToString());
                p.Libelle = pays["Libelle"].ToString();
                lstPays.Add(p);
            }
            return lstPays;
        }
    }
}
