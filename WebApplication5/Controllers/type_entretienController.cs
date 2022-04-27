using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class type_entretienController : Controller
    {
        private NewdbEntities18 db = new NewdbEntities18();

        // GET: type_entretien
        public ActionResult Index()
        {
            NewdbEntities18 db = new NewdbEntities18();
            List<repdetails> maintD = new List<repdetails>();
            //clientdetails cd = new clientdetails();
            var num = db.equipement.Select(a => a.id_equip).ToList();
            var dept = db.departement.Select(a => a.libelledep).ToList();
            var rf = db.equipement.Select(a => a.@ref).ToList();
            var lb = db.equipement.Select(a => a.libelleq).ToList();
            var tp = db.type.Select(a => a.denomination).ToList();
            var inter = db.type_entretien.Select(a => a.libellentr).ToList();
            var mine = db.intervention.Select(a => a.nb_min).ToList();


            foreach (int item in num)
            {
                repdetails ab = new repdetails();
                ab.Numéro = item;
                ab.Département = dept[item - 1];
                ab.Référence = rf[item - 1];
                ab.Libellé = lb[item - 1];
                ab.Type = tp[item - 1];
                ab.intervention = inter[item - 1];
                if (mine[item - 1] != null)
                { ab.nombreheureinter = (int)mine[item - 1]; }
                else { ab.nombreheureinter = 0; }
                maintD.Add(ab);
            }
            ViewBag.Message = maintD;
            return View();
        }
        //    return View(db.type_entretien.ToList());
        //}

        public ActionResult SaveRecord(int? id)
        {
            intervention i = db.intervention.Find(id);
            return View(i);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRecord([Bind(Include = "id_inter ,id_equip ,id_typenter, nb_min ,typenter , date_inter")] intervention intervention)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intervention).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(intervention);
        }
        public ActionResult Ude(int? id)
        {
            intervention i = db.intervention.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Ude(string gyp)
        {
            NewdbEntities18 db = new NewdbEntities18();
            if (gyp == "true")
            {
                DateTime dt = DateTime.Now;
                ViewBag.Message = "yupp";
                intervention inet = new intervention();
                inet.date_inter = dt;
                db.intervention.Add(inet);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult SaveRecord(repdetails model,int? id) {
        //    try
        //    {
        //        NewdbEntities15 db = new NewdbEntities15();
        //        intervention intt = new intervention();
        //        var inte = db.intervention.Select(a => a.id_inter).ToList();

        //        intervention i = new intervention();
        //        i=db.intervention.Find(id);
        //        //foreach (int item in inte)
        //        //{
        //        //var dbe = Database.Open("Newdb");
        //        //var inse = "INSERT INTO intervention(nb_min)"+" VALUES(model.nombreheureinter)";
        //        //dbe.Execute(inse, model.nombreheureinter);
        //        //repdetails ab = new repdetails();
        //        //if (item == ab.Numéro)
        //        //{
        //        //foreach (DataRow row in intervention.Rows)
        //        //{
        //        //    row["nb_min"] = model.nombreheureinter;
        //        //}
        //        i.nb_min = model.nombreheureinter;
        //        //intt.nb_min = model.nombreheureinter;

        //           db.intervention.Add(i);
        //           db.SaveChanges();
        //           //return RedirectToAction("Index");
        //    }
        //    catch(Exception ex) { throw ex; }
        //    return RedirectToAction("gestequip");
        //}

        // GET: type_entretien/Edit/5
        public ActionResult Edit(int? id)
        {
           
            type_entretien type_entretien = db.type_entretien.Find(id);
            
            return View(type_entretien);
        }
        
        // POST: type_entretien/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_typentr,libellentr,action_propose,description")] type_entretien type_entretien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_entretien).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(type_entretien);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
