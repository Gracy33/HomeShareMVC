using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.DAL
{
    public class Option
    {
        #region Fields
        private int _idOption;
        private string _libelle;
        #endregion

        #region Getters/Setters;
        public int IdOption
        {
            get { return _idOption; }
            set { _idOption = value; }
        }

        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }
        #endregion

        public Option() { }

        public static Option getOption(int id)
        {
            List<Dictionary<string, object>> option = GestionConnexion.Instance.getData("select * from Options where idOption=" + id);

            Option opt = new Option();
            opt.IdOption = int.Parse(option[0]["idOption"].ToString());
            opt.Libelle = option[0]["Libelle"].ToString();

            return opt;
        }

        public static List<Option> getAllOptions()
        {
            List<Dictionary<string, object>> options = GestionConnexion.Instance.getData("select * from Options");
            List<Option> lstOption = new List<Option>();
            foreach (Dictionary<string, object> option in options)
            {
                Option opt = new Option();
                opt.IdOption = int.Parse(option["idOption"].ToString());
                opt.Libelle = option["Libelle"].ToString();
                lstOption.Add(opt);
            }
            return lstOption;
        }
    }
}
