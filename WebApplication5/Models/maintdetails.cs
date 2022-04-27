using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class maintdetails
    {
        public int Numéro { get; set; }
        public String Département { get; set; }

        public String Référence { get; set; }
        public String Libellé { get; set; }
        public string Type { get; set; }
        public string Fiche_technique { get; set; }
        public String Historique_de_réparation { get; set; }

        public int Ajout_demande_de_réparation { get; set; }
        public string departement { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public int id_demande { get; set; }
        public Nullable<int> id_equip { get; set; }
        public Nullable<int> id_typentr { get; set; }
        public Nullable<int> etat { get; set; }
        public Nullable<System.DateTime> date_dem { get; set; }
        public virtual type_entretien type_entretien { get; set; }
        //public IEnumerable<HttpPostedFileBase> files { get; set; }
        //public string File { get; set; }
        //public long Size { get; set; }
    }
    
}