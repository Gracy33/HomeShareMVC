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
        private int _pays = 1;
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

        public int Pays
        {
            get { return _pays; }
            set { _pays = value; }
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
        #endregion

        public Bien()
        { }

        public static Bien getBien(int id)
        {
            List<Dictionary<string, object>> unBien = GestionConnexion.Instance.getData("select * from BienEchange where idBien=" + id);
            Bien b = new Bien();

            b.IdBien = int.Parse(unBien[0]["idBien"].ToString());
            b.Titre = unBien[0]["titre"].ToString();
            b.DescCourte = unBien[0]["DescCourte"].ToString();
            b.DescLongue = unBien[0]["DescLong"].ToString();
            b.NombrePersonne = int.Parse(unBien[0]["NombrePerson"].ToString());
            b.Pays = int.Parse(unBien[0]["Pays"].ToString());
            b.Ville = unBien[0]["Ville"].ToString();
            b.Rue = unBien[0]["Rue"].ToString();
            b.Numero = unBien[0]["Numero"].ToString();
            b.CodePostal = unBien[0]["CodePostal"].ToString();
            b.Photo = unBien[0]["Photo"].ToString();
            b.AssuranceOblig = bool.Parse(unBien[0]["AssuranceObligatoire"].ToString());
            b.IsEnabled = bool.Parse(unBien[0]["isEnabled"].ToString());
            if (unBien[0]["DisabledDate"].ToString() != "")
            {
                b.DisabledDate = DateTime.Parse(unBien[0]["DisabledDate"].ToString());
            }
            b.Latitude = unBien[0]["Latitude"].ToString();
            b.Longitude = unBien[0]["Longitude"].ToString();
            b.IdMembre = int.Parse(unBien[0]["idMembre"].ToString());
            b.DateCreation = DateTime.Parse(unBien[0]["DateCreation"].ToString());

            return b;
        }

        public static List<Bien> getAllBiens()
        {
            List<Dictionary<string, object>> biens = GestionConnexion.Instance.getData("select * from BienEchange");
            List<Bien> lstBien = new List<Bien>();
            foreach (Dictionary<string, object> unBien in biens)
            {
                Bien b = new Bien();
                b.IdBien = int.Parse(unBien["idBien"].ToString());
                b.Titre = unBien["titre"].ToString();
                b.DescCourte = unBien["DescCourte"].ToString();
                b.DescLongue = unBien["DescLong"].ToString();
                b.NombrePersonne = int.Parse(unBien["NombrePerson"].ToString());
                b.Pays = int.Parse(unBien["Pays"].ToString());
                b.Ville = unBien["Ville"].ToString();
                b.Rue = unBien["Rue"].ToString();
                b.Numero = unBien["Numero"].ToString();
                b.CodePostal = unBien["CodePostal"].ToString();
                b.Photo = unBien["Photo"].ToString();
                b.AssuranceOblig = bool.Parse(unBien["AssuranceObligatoire"].ToString());
                b.IsEnabled = bool.Parse(unBien["isEnabled"].ToString());
                if (unBien["DisabledDate"].ToString() != "")
                {
                    b.DisabledDate = DateTime.Parse(unBien["DisabledDate"].ToString());
                }
                b.Latitude = unBien["Latitude"].ToString();
                b.Longitude = unBien["Longitude"].ToString();
                b.IdMembre = int.Parse(unBien["idMembre"].ToString());
                b.DateCreation = DateTime.Parse(unBien["DateCreation"].ToString());
                lstBien.Add(b);
            }
            return lstBien;
        }

        public static List<Bien> getMeilleurEchange()
        {
            List<Dictionary<string, object>> biens = GestionConnexion.Instance.getData("SELECT TOP 5 * FROM [HomeShareDB].[dbo].[Vue_MeilleursAvis]");
            
            List<Bien> lstBien = new List<Bien>();
            foreach (Dictionary<string, object> unBien in biens)
            {
                Bien b = new Bien();
                b.IdBien = int.Parse(unBien["idBien"].ToString());
                b.Titre = unBien["titre"].ToString();
                b.DescCourte = unBien["DescCourte"].ToString();
                b.DescLongue = unBien["DescLong"].ToString();
                b.NombrePersonne = int.Parse(unBien["NombrePerson"].ToString());
                b.Pays = int.Parse(unBien["Pays"].ToString());
                b.Ville = unBien["Ville"].ToString();
                b.Rue = unBien["Rue"].ToString();
                b.Numero = unBien["Numero"].ToString();
                b.CodePostal = unBien["CodePostal"].ToString();
                b.Photo = unBien["Photo"].ToString();
                b.AssuranceOblig = bool.Parse(unBien["AssuranceObligatoire"].ToString());
                b.IsEnabled = bool.Parse(unBien["isEnabled"].ToString());
                if (unBien["DisabledDate"].ToString() != "")
                {
                    b.DisabledDate = DateTime.Parse(unBien["DisabledDate"].ToString());
                }
                b.Latitude = unBien["Latitude"].ToString();
                b.Longitude = unBien["Longitude"].ToString();
                b.IdMembre = int.Parse(unBien["idMembre"].ToString());
                b.DateCreation = DateTime.Parse(unBien["DateCreation"].ToString());

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
                Bien b = new Bien();
                b.IdBien = int.Parse(unBien["idBien"].ToString());
                b.Titre = unBien["titre"].ToString();
                b.DescCourte = unBien["DescCourte"].ToString();
                b.DescLongue = unBien["DescLong"].ToString();
                b.NombrePersonne = int.Parse(unBien["NombrePerson"].ToString());
                b.Pays = int.Parse(unBien["Pays"].ToString());
                b.Ville = unBien["Ville"].ToString();
                b.Rue = unBien["Rue"].ToString();
                b.Numero = unBien["Numero"].ToString();
                b.CodePostal = unBien["CodePostal"].ToString();
                b.Photo = unBien["Photo"].ToString();
                b.AssuranceOblig = bool.Parse(unBien["AssuranceObligatoire"].ToString());
                b.IsEnabled = bool.Parse(unBien["isEnabled"].ToString());
                if (unBien["DisabledDate"].ToString() != "")
                {
                    b.DisabledDate = DateTime.Parse(unBien["DisabledDate"].ToString());
                }
                b.Latitude = unBien["Latitude"].ToString();
                b.Longitude = unBien["Longitude"].ToString();
                b.IdMembre = int.Parse(unBien["idMembre"].ToString());
                b.DateCreation = DateTime.Parse(unBien["DateCreation"].ToString());

                lstBien.Add(b);
            }
            return lstBien;
        }

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
            valeurs.Add("pays", this.Pays);
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
            string query = @"DELETE from BienEchange where idBien= "+ id;

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

    }
}
