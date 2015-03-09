using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Membre
    {
        #region Fields
        private int _idMembre;
        private string _nom;
        private string _prenom;
        private string _email;
        private int _pays;
        private string _telephone;
        private string _login;
        private string _password;
        public List<Bien> _biens;
        #endregion

        #region Getters/Setters
        public int IdMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Pays
        {
            get { return _pays; }
            set { _pays = value; }
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion

        //Constructeur vide
        public Membre()
        {  }

        public static Membre getInfo(int id)
        {
            List<Dictionary<string, object>> membre = GestionConnexion.Instance.getData("select * from Membre where idMembre=" + id);
            Membre m = new Membre();
            m.IdMembre = int.Parse(membre[0]["idMembre"].ToString());
            m.Nom = membre[0]["Nom"].ToString();
            m.Prenom = membre[0]["Prenom"].ToString();
            m.Email = membre[0]["Email"].ToString();
            m.Pays = int.Parse(membre[0]["Pays"].ToString());
            m.Telephone = membre[0]["Telephone"].ToString();
            m.Login = membre[0]["Login"].ToString();
            m.Password = membre[0]["Password"].ToString();

            return m;
        }

        public static List<Membre> getAllMembre()
        {
            List<Dictionary<string, object>> membres = GestionConnexion.Instance.getData("select * from Membre");
            List<Membre> lstMembre = new List<Membre>();
            foreach (Dictionary<string, object> membre in membres)
            {
                Membre m = new Membre();
                m.IdMembre = int.Parse(membre["idMembre"].ToString());
                m.Nom = membre["Nom"].ToString();
                m.Prenom = membre["Prenom"].ToString();
                m.Email = membre["Email"].ToString();
                m.Pays = int.Parse(membre["Pays"].ToString());
                m.Telephone = membre["Telephone"].ToString();
                m.Login = membre["Login"].ToString();
                m.Password = membre["Password"].ToString();
                lstMembre.Add(m);
            }
            return lstMembre;
        }

        //public static List<Bien> getBiens(int idM)
        //{
        //    List<Bien> retour = new List<Bien>();
        //    List<Dictionary<string, object>> lesBiens = GestionConnexion.Instance.getData("select * from BienEchange where idMembre =" + idM);
        //    foreach (Dictionary<string, object> unBien in lesBiens)
        //    {
        //        Bien b = new Bien();
        //        b.IdBien = int.Parse(unBien["idBien"].ToString());
        //        b.Titre = unBien["titre"].ToString();
        //        b.DescCourte = unBien["DescCourte"].ToString();
        //        b.DescLongue = unBien["DescLong"].ToString();
        //        b.NombrePersonne = int.Parse(unBien["NombrePerson"].ToString());
        //        b.Pays = int.Parse(unBien["Pays"].ToString());
        //        b.Ville = unBien["Ville"].ToString();
        //        b.Rue = unBien["Rue"].ToString();
        //        b.Numero = unBien["Numero"].ToString();
        //        b.CodePostal = unBien["CodePostal"].ToString();
        //        b.Photo = unBien["Photo"].ToString();
        //        b.AssuranceOblig = bool.Parse(unBien["AssuranceObligatoire"].ToString());
        //        b.IsEnabled = bool.Parse(unBien["isEnabled"].ToString());
        //        if (unBien["DisabledDate"].ToString() != "")
        //        {
        //            b.DisabledDate = DateTime.Parse(unBien["DisabledDate"].ToString());
        //        }
        //        b.Latitude = unBien["Latitude"].ToString();
        //        b.Longitude = unBien["Longitude"].ToString();
        //        b.IdMembre = int.Parse(unBien["idMembre"].ToString());
        //        b.DateCreation = DateTime.Parse(unBien["DateCreation"].ToString());
        //        retour.Add(b);
        //    }
        //    return retour;
        //}

        public virtual bool saveMembre()
        {
            Membre memb = Membre.getInfo(this.IdMembre);
            string query = "";
            if (memb == null)
            {
                query = @"INSERT INTO [dbo].[Membre]
                                       ([Nom]
                                       ,[Prenom]
                                       ,[Email]
                                       ,[Pays]
                                       ,[Telephone]
                                       ,[Login]
                                       ,[Password])
                                 VALUES(@nom,@prenom,@email,@pays,@telephone,@login,@password";
            }
            else
            {
                query = @"UPDATE [dbo].[Membre]
                           SET  [Nom] = @nom
                                ,[Prenom] = @prenom
                                ,[Email] = @email
                                ,[Pays] = @pays
                                ,[Telephone] = @telephone
                                ,[Login] = @login
                                ,[Password] = @password
                           Where [idMembre] = @idMembre";
            }

            //les données a insérer
            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("idMembre", this.IdMembre);
            valeurs.Add("nom", this.Nom);
            valeurs.Add("prenom", this.Prenom);
            valeurs.Add("email", this.Email);
            valeurs.Add("pays", this.Pays);
            valeurs.Add("telephone", this.Telephone);
            valeurs.Add("login", this.Login);
            valeurs.Add("password", this.Password);

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
