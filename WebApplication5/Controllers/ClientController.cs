using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication5.Models;
using System.Configuration;
using WebApplication5.ViewModel;
using System.Data.SqlClient;
using Amazon.DynamoDBv2;
using System.Web.SessionState;



namespace WebApplication5.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        private NewdbEntities18 db = new NewdbEntities18();
        //NewdbEntities16 db = new NewdbEntities16();
        public ActionResult Index()
        {
            var liste = db.type_entretien.ToList().Distinct();
            SelectList list = new SelectList(liste, "id_typentr", "libellentr");
            ViewBag.breakdown = list;

            return View();
        }
        
       
        public ActionResult Ajoutdema(eya r)
        {
            NewdbEntities18 db = new NewdbEntities18();
            List<clientdetails> clientD = new List<clientdetails>();
            List<int> jj = new List<int>();
            List<string> tp = new List<string>();
            List<int> ti = new List<int>();
            List<int> num = new List<int>();
            List<string> inter = new List<string>();
            List<string> rf = new List<string>();
            List<string> lb = new List<string>();
            List<string> fi = new List<string>();
            List<int> typp = new List<int>();
            List<DateTime> dt = new List<DateTime>();
            clientdetails cd = new clientdetails();

            //var ey = from m in db.eya
            //             select m;
            //ey = ey.Where(s => s.departement.Contains(searchString));
            //Session["dep"] = ey.departement.ToString();
            //if (Session["dep"] != null) {

            var id = db.departement.Where(a => a.libelledep == UserController.depar).Select(a => a.id_dep).ToList();
           


            foreach (var e in id)
            {
                var nu = db.equipement.Where(a => a.id_dep == e).Select(a => a.id_equip).ToList();
                num.Add(nu[0]);

                var rfe = db.equipement.Where(a => a.id_dep == e).Select(a => a.@ref).ToList();
                rf.Add(rfe[0]);
                var lbe = db.equipement.Where(a => a.id_dep == e).Select(a => a.libelleq).ToList();
                lb.Add(lbe[0]);
                var ty = db.equipement.Where(a => a.id_dep == e).Select(a => a.id_type).ToList();
                typp.Add((int)ty[0]);
            }
            
            foreach (var ed in typp)
            {
                var p = db.type.Where(a => a.id_type == ed).Select(a => a.denomination).ToList();
                tp.Add(p[0]);
            }
            foreach (var ei in num)
            {
                var p = db.intervention.Where(a => a.id_equip == ei).Select(a => a.id_typenter).ToList();
                ti.Add((int)p[0]);
            }
            foreach (var ep in ti)
            {
                var p = db.type_entretien.Where(a => a.id_typentr == ep).Select(a => a.libellentr).ToList();
                inter.Add(p[0]);
            }
            foreach (var ee in num)
            {
                //var p = db.fiche_tech.Where(a => a.id_equip == e).Select(a => a.fiche).ToList();
                //fi.Add(p[0]);
                var qf = db.intervention.Where(a => a.id_equip == ee).Select(a => a.date_inter).ToList();
                dt.Add((DateTime)qf[0]);
            }


            //var num = db.equipement.Select(a => a.id_equip).ToList();
            //var rf = db.equipement.Select(a => a.@ref).ToList();
            //var lb = db.equipement.Select(a => a.libelleq).ToList();
            //var tp = db.type.Select(a => a.denomination).ToList();
            //var inter = db.type_entretien.Select(a => a.libellentr).ToList();
            //var fi = db.fiche_tech.Select(a => a.fiche).ToList();
            //var dt = db.intervention.Select(a => a.date_inter).ToList();

            int k = num.Count();
            for (int item=1;item<=k;item++)
            {
                clientdetails ab = new clientdetails();
                ab.Numéro = item;
                ab.Référence = rf[item -1];
                ab.Libellé = lb[item - 1];
                ab.Type = tp[item - 1];
                ab.Historique_de_réparation = inter[item - 1]  + ":"+  dt[item -1];
                clientD.Add(ab);

            }

            ViewBag.Message = clientD;

            var liste = db.type_entretien.ToList().Distinct();
            SelectList list = new SelectList(liste, "id_typentr", "libellentr");
            ViewBag.breakdown = list;


            try
            {
                return View(clientD);
            }
            catch (Exception e)
            { return HttpNotFound(); }
        }
        //[HttpPost]
        //public ActionResult Ajoutdema(type_entretien tpe,eya r)
        //{
        //    NewdbEntities17 db = new NewdbEntities17();
        //    db.type_entretien.Add(tpe);
        //    db.SaveChanges();

        //    return View();
        //}
      


        
      
            
    }
}