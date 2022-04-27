using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;


namespace WebApplication5.ViewModel
{
    public class Class1
    {
        public IEnumerable<equipement> equi { get; set; }
        public IEnumerable<fiche_tech> fiche { get; set; }
        public IEnumerable<demande> dem { get; set; }
        public IEnumerable<type_entretien> tyentr { get; set; }
        public IEnumerable<departement> dep { get; set; }
        public IEnumerable<type> typ { get; set; }
        public IEnumerable<intervention> inter { get; set; }
        public IEnumerable<piece> pie { get; set; }
        public IEnumerable<clientdetails> cl { get; set; }

        internal static void Add(Class1 cld)
        {
            throw new NotImplementedException();
        }
    }
}