using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class class2
    {
        public int id_equip { get; set; }//
        public string @ref { get; set; }//
        public string libelledep { get; set; }//
        public Nullable<int> id_dep { get; set; }//
        public Nullable<int> id_type { get; set; }
        public string denomination { get; set; }//
        public Nullable<int> etat { get; set; }
        public string libelleq { get; set; }//
        public int id_fiche { get; set; }//
        public int id_typentr { get; set; }
        public string libellentr { get; set; }
    }
}