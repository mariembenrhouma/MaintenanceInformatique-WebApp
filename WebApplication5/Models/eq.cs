using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class eq
    {
        public IEnumerable<equipement> equi { get; set; }
        public IEnumerable<fiche_tech> fiche { get; set; }
        public IEnumerable<demande> dem { get; set; }
        public IEnumerable<type_entretien> tyentr { get; set; }
        public IEnumerable<departement> dep { get; set; }
        public IEnumerable<type> typ { get; set; }
        public IEnumerable<intervention> inter { get; set; }
        public IEnumerable<piece> pie { get; set; }
    }
}