using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{

    public class clientdetails
    {   public int Numéro { get; set; }
        public String Référence { get; set; }
        public String Libellé { get; set; }
        public string Type { get; set; }
        public int Fiche_technique { get; set; }
        public String Historique_de_réparation { get; set; }

        public int Ajout_demande_de_réparation { get; set;}
        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public string File { get; set; }
        public long Size { get; set; }
        public int id_typentr { get; set; }
        public string libellentr { get; set; }
        public string action_propose { get; set; }
        public string description { get; set; }
        


    }
}