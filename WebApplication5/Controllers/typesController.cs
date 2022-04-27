using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class typesController : Controller
    {
        private NewdbEntities18 db = new NewdbEntities18();

        // GET: types
        public ActionResult Index()
        {
            return View(db.type.ToList());
        }

        // GET: types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type type = db.type.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // GET: types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: types/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_type,denomination")] type type)
        {
            if (ModelState.IsValid)
            {
                db.type.Add(type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type);
        }

        // GET: types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type type = db.type.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: types/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_type,denomination")] type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type);
        }

        // GET: types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            type type = db.type.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: types/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(type p)
        //{
        //    type t = db.type.Where(x => x.id_type == p.id_type).FirstOrDefault();


        //    db.type.Remove(t);
        //    db.SaveChanges();
        //    db.Dispose();
        //    return View(t);
        //    //return RedirectToAction("Index");
        //}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            type ty = db.type.Find(id);

            var l = from b in db.equipement
                    where b.id_type == id
                    select b.id_equip;
            /*db.equipement.Select(id_equip).Where(x => x.id_dep == id).First();*/
            //db.equipement.Remove(l);
            //var p =db.demande.Where(x =>x.id_equip=={equipement.Select id_equip Where);
            foreach (var i in l)
            {
                var le =
                    from c in db.demande
                    where c.id_equip == i /*(from b in db.equipement where b.id_dep == id select b.id_equip;)*/
                    select c.id_demande;
                var lee =
                    from d in db.fiche_tech
                    where d.id_equip == i
                    select d.id_fiche;
                var o =
                    from k in db.intervention
                    where k.id_equip == i
                    select k.id_inter;
                foreach (var j in o)
                {
                    var y =
                    from k in db.piece
                    where k.id_inter == j
                    select k.id_piece;
                    foreach (var h in y)
                    {
                        piece p = db.piece.Find(h);
                        db.piece.Remove(p);
                    }
                    //db.SaveChanges();
                    intervention w = db.intervention.Find(j);
                    db.intervention.Remove(w);
                }

                //db.SaveChanges();
                foreach (var e in le)
                {
                    demande de = db.demande.Find(e);
                    db.demande.Remove(de);
                    //db.SaveChanges();
                }
                foreach (var ee in lee)
                {
                    fiche_tech f = db.fiche_tech.Find(ee);
                    db.fiche_tech.Remove(f);
                    //db.SaveChanges();
                }
                equipement eq = db.equipement.Find(i);
                db.equipement.Remove(eq);
                //db.SaveChanges();

            }
            db.SaveChanges();
            db.type.Remove(ty);
            db.SaveChanges();
            return RedirectToAction("Index");
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
