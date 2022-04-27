using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class repdetails
    {
        public int Numéro { get; set; }
        public String Département { get; set; }

        public String Référence { get; set; }
        public String Libellé { get; set; }
        public string Type { get; set; }
        public String intervention  { get; set; }
        public int nombreheureinter { get; set; }

        public int etatinter { get; set; }
        public type tp { get; set; }
    }
    
}