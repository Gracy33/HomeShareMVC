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
        { }



        #region Method Static
        public static Membre getInfo(int id)
        {
            List<Dictionary<string, object>> membre = GestionConnexion.Instance.getData("select * from Membre where idMembre=" + id);

            Membre m = Associe(membre[0]);
            return m;
        }

        public static List<Membre> getAllMembre()
        {
            List<Dictionary<string, object>> membres = GestionConnexion.Instance.getData("select * from Membre");
            List<Membre> lstMembre = new List<Membre>();
            foreach (Dictionary<string, object> item in membres)
            {
                Membre m = Associe(item);
                lstMembre.Add(m);
            }
            return lstMembre;
        }

        private static Membre Associe(Dictionary<string, object> item)
        {
            Membre m = new Membre();
            m.IdMembre = int.Parse(item["idMembre"].ToString());
            m.Nom = item["Nom"].ToString();
            m.Prenom = item["Prenom"].ToString();
            m.Email = item["Email"].ToString();
            m.Pays = int.Parse(item["Pays"].ToString());
            m.Telephone = item["Telephone"].ToString();
            m.Login = item["Login"].ToString();
            m.Password = item["Password"].ToString();
            return m;
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

        public static Membre authentifier(string login, string password)
        {
            List<Dictionary<string, object>> infoUser = GestionConnexion.Instance.getData("Select * from Membre where Login='" + login + "' and Password='" + password + "'");
            Membre membre = null;
            if (infoUser.Count > 0)
            {
                int id = (int)infoUser[0]["idMembre"];
                membre = Membre.getInfo(id);
            }
            return membre;
        }
        #endregion


        #region Insert/Update
        /*INSERT & UPDATE*/
        public virtual bool saveMembre(string txtNom, string txtPrenom, string txtEmail, int pays, string txtPhone, string txtLogin, string txtPassword)
        {
            string query = @"INSERT INTO Membre (Nom, Prenom , Email , Pays , Telephone , Login , Password)
                                 VALUES(@nom,@prenom,@email,@pays,@telephone,@login,@password)";

            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("nom", txtNom);
            valeurs.Add("prenom", txtPrenom);
            valeurs.Add("email", txtEmail);
            valeurs.Add("pays", pays);
            valeurs.Add("telephone", txtPhone);
            valeurs.Add("login", txtLogin);
            valeurs.Add("password", txtPassword);

            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool updateMembre()
        {
            string query = @"UPDATE [dbo].[Membre]
                                       SET  [Nom] = @nom
                                            ,[Prenom] = @prenom
                                            ,[Email] = @email
                                            ,[Pays] = @pays
                                            ,[Telephone] = @telephone
                                            ,[Login] = @login
                                            ,[Password] = @password
                                       Where [idMembre] = @idMembre";


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

        public virtual bool deleteMembre(int id)
        {
            string query = @"DELETE from Membre where idMembre= " + id;

            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("idMembre", id);

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
