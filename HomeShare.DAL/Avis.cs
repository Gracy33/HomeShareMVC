using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Avis
    {
        #region Fields
        private int _idAvis;
        private int _note;
        private string _message;
        private int _idMembre;
        private int _idBien;
        private DateTime _dateAvis;
        private bool _approuve = false;
        #endregion

        #region Getters/Setters
        public int IdAvis
        {
            get { return _idAvis; }
            set { _idAvis = value; }
        }

        public int Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

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

        public DateTime DateAvis
        {
            get { return _dateAvis; }
            set { _dateAvis = value; }
        }

        public bool Approuve
        {
            get { return _approuve; }
            set { _approuve = value; }
        } 
        #endregion

        public Avis() { }

        public static List<Avis> getAvisBien(int idB)
        {
            List<Avis> retour = new List<Avis>();
            List<Dictionary<string, object>> lesAvis = GestionConnexion.Instance.getData("select * from BienEchange where idBien =" + idB);
            foreach (Dictionary<string, object> unAvis in lesAvis)
            {
                Avis avis = new Avis();
                avis.IdAvis = int.Parse(unAvis["idAvis"].ToString());
                avis.Note = int.Parse(unAvis["note"].ToString());
                avis.Message = unAvis["message"].ToString();
                avis.IdMembre = int.Parse(unAvis["idMembre"].ToString());
                avis.IdBien = int.Parse(unAvis["idBien"].ToString());
                avis.DateAvis = DateTime.Parse(unAvis["DateAvis"].ToString());
                avis.Approuve = bool.Parse(unAvis["Approuve"].ToString());
                retour.Add(avis);
            }
            return retour;
        }

        public static void AddAvis(int note, string txtMessage, int idM, int idB, bool approuve )
        {
            string query = @"INSERT INTO [dbo].[AvisMembreBien]
                               ([note]
                               ,[message]
                               ,[idMembre]
                               ,[idBien]
                               ,[DateAvis]
                               ,[Approuve])
            VALUES
           (@note,@message,@idMembre,@idBien, @dateAvis, @approuve)";

            DateTime date = DateTime.Now;

            Dictionary<string, object> dicovalues = new Dictionary<string, object>();            
            dicovalues.Add("note", note);
            dicovalues.Add("message", txtMessage);
            dicovalues.Add("idMembre", idM);
            dicovalues.Add("idBien", idB);
            dicovalues.Add("dateAvis", date);
            dicovalues.Add("approuve", approuve);

            GestionConnexion.Instance.saveData(query, GenerateKey.APP, dicovalues);
        }
    }
}
