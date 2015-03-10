using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Bien
    {
        #region Fields
        private int _idBien;
        private string _titre;
        private string _descCourte;
        private string _descLongue;
        private int _nombrePersonne;
        private int _idPays = 1;
        private string _ville;
        private string _rue;
        private string _numero;
        private string _codePostal;
        private string _photo;
        private bool _assuranceOblig = false;
        private bool _isEnabled = false;
        private DateTime _disabledDate;
        private string _latitude;
        private string _longitude;
        private int _idMembre;
        private DateTime _dateCreation;
        private Pays _paysDuBien;
        public List<Avis> _lesAvis;
        #endregion


        #region Getters/Setters
        public int IdBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }

        public string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        public string DescCourte
        {
            get { return _descCourte; }
            set { _descCourte = value; }
        }

        public string DescLongue
        {
            get { return _descLongue; }
            set { _descLongue = value; }
        }

        public int NombrePersonne
        {
            get { return _nombrePersonne; }
            set { _nombrePersonne = value; }
        }

        public int IdPays
        {
            get { return _idPays; }
            set { _idPays = value; }
        }
        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }

        public string Rue
        {
            get { return _rue; }
            set { _rue = value; }
        }

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public string CodePostal
        {
            get { return _codePostal; }
            set { _codePostal = value; }
        }

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public bool AssuranceOblig
        {
            get { return _assuranceOblig; }
            set { _assuranceOblig = value; }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }

        public DateTime DisabledDate
        {
            get { return _disabledDate; }
            set { _disabledDate = value; }
        }

        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public int IdMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public DateTime DateCreation
        {
            get { return _dateCreation; }
            set { _dateCreation = value; }
        }

        public List<Avis> LesAvis
        {
            get
            {
                if (_lesAvis == null) _lesAvis = ChargerLesAvis();
                return _lesAvis;
            }
        }

        public Pays PaysDuBien
        {
            get
            {
                if (_paysDuBien == null) _paysDuBien = chargerInfoPays();
                return _paysDuBien;
            }
        }

        #endregion

        public Bien()
        { }

        private Pays chargerInfoPays()
        {
            return Pays.getPays(this.IdPays);
        }

        private List<Avis> ChargerLesAvis()
        {
            return Avis.getAvisBien(this.IdBien);
        }

        #region Method Static
        public static Bien getBien(int id)
        {
            List<Dictionary<string, object>> unBien = GestionConnexion.Instance.getData("select * from BienEchange where idBien=" + id);
            Bien b = Associe(unBien[0]);
            return b;
        }

        public static List<Bien> getAllBiens()
        {
            List<Dictionary<string, object>> biens = GestionConnexion.Instance.getData("select * from BienEchange");
            List<Bien> lstBien = new List<Bien>();
            foreach (Dictionary<string, object> unBien in biens)
            {
                Bien b = Associe(unBien);
                lstBien.Add(b);
            }
            return lstBien;
        }

        public static List<Bien> getMeilleurEchange()
        {
            List<Dictionary<string, object>> biens = GestionConnexion.Instance.getData("SELECT TOP 5 * FROM [HomeShareDB].[dbo].[Vue_MeilleursAvis]");

            List<Bien> lstBien = new List<Bien>();
            foreach (Dictionary<string, object> item in biens)
            {
                Bien b = Associe(item);
                lstBien.Add(b);
            }
            return lstBien;
        }

        public static List<Bien> getDerniersBiens()
        {
            List<Dictionary<string, object>> biens = GestionConnexion.Instance.getData("SELECT TOP 5 * FROM [HomeShareDB].[dbo].[Vue_CinqDernierBiens]");

            List<Bien> lstBien = new List<Bien>();
            foreach (Dictionary<string, object> unBien in biens)
            {
                Bien b = Associe(unBien);
                lstBien.Add(b);
            }
            return lstBien;
        }

        public static List<Bien> getBienParPays(int idPays)
        {
            List<Dictionary<string, object>> lstBiens = GestionConnexion.Instance.getData("SELECT * FROM [HomeShareDB].[dbo].[Vue_BiensParPays] where Pays = "+ idPays );

            List<Bien> biensPays = new List<Bien>();
            foreach (Dictionary<string, object> unBien in lstBiens)
            {
                Bien b = Associe(unBien);
                biensPays.Add(b);
            }
            return biensPays;
        }

        private static Bien Associe(Dictionary<string, object> item)
        {
            Bien b = new Bien();
            b.IdBien = int.Parse(item["idBien"].ToString());
            b.Titre = item["titre"].ToString();
            b.DescCourte = item["DescCourte"].ToString();
            b.DescLongue = item["DescLong"].ToString();
            b.NombrePersonne = int.Parse(item["NombrePerson"].ToString());
            b.IdPays = int.Parse(item["Pays"].ToString());
            b.Ville = item["Ville"].ToString();
            b.Rue = item["Rue"].ToString();
            b.Numero = item["Numero"].ToString();
            b.CodePostal = item["CodePostal"].ToString();
            b.Photo = item["Photo"].ToString();
            b.AssuranceOblig = bool.Parse(item["AssuranceObligatoire"].ToString());
            b.IsEnabled = bool.Parse(item["isEnabled"].ToString());
            if (item["DisabledDate"].ToString() != "")
            {
                b.DisabledDate = DateTime.Parse(item["DisabledDate"].ToString());
            }
            b.Latitude = item["Latitude"].ToString();
            b.Longitude = item["Longitude"].ToString();
            b.IdMembre = int.Parse(item["idMembre"].ToString());
            b.DateCreation = DateTime.Parse(item["DateCreation"].ToString());
            return b;
        }
        #endregion

        #region Insert/Update/Delete
        public virtual bool updateBien()
        {
            Bien info = Bien.getBien(this.IdBien);
            string query = @"UPDATE BienEchange 
                             SET [titre] = @titre
                              ,[DescCourte] = @descCourte
                              ,[DescLong] = @descLong
                              ,[NombrePerson] = @nombrePerson
                              ,[Pays] = @pays
                              ,[Ville] = @ville
                              ,[Rue] = @rue
                              ,[Numero] = @numero
                              ,[CodePostal] = @codePostal
                              ,[Photo] = @photo
                              ,[AssuranceObligatoire] = @assuranceObligatoire
                              ,[isEnabled] = @isEnabled
                              ,[DisabledDate] = @disabledDate
                              ,[Latitude] = @latitude
                              ,[Longitude] = @longitude
                              ,[idMembre] = @idMembre
                              ,[DateCreation] = @dateCreation
                            WHERE [idBien] = @idBien";


            //les données a insérer
            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("idBien", this.IdBien);
            valeurs.Add("titre", this.Titre);
            valeurs.Add("descCourte", this.DescCourte);
            valeurs.Add("descLong", this.DescLongue);
            valeurs.Add("nombrePerson", this.NombrePersonne);
            valeurs.Add("pays", this.IdPays);
            valeurs.Add("ville", this.Ville);
            valeurs.Add("rue", this.Rue);
            valeurs.Add("numero", this.Numero);
            valeurs.Add("codePostal", this.CodePostal);
            valeurs.Add("photo", this.Photo);
            valeurs.Add("assuranceObligatoire", this.AssuranceOblig);
            valeurs.Add("isEnabled", this.IsEnabled);
            valeurs.Add("disabledDate", this.DisabledDate);
            valeurs.Add("latitude", this.Latitude);
            valeurs.Add("longitude", this.Longitude);
            valeurs.Add("idMembre", this.IdMembre);
            valeurs.Add("dateCreation", this.DateCreation);

            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool deleteBien(int id)
        {
            string query = @"DELETE from BienEchange where idBien= " + id;

            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("idBien", id);

            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
