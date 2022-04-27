using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class bh
    {
        public IEnumerable<entretien> entretien { get; set; }
        public IEnumerable<clientdetails> client { get; set; }
    }
}