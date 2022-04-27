using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using WebApplication5.Models;
using System.Configuration;
using WebApplication5.ViewModel;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.IO;

namespace WebApplication5.Controllers
{
    public class maintenController : Controller
    {
        public static List<clientdetails> listcl = new List<clientdetails>();
        NewdbEntities18 db = new NewdbEntities18();
        // GET: mainten
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult gestequip()
        {
            NewdbEntities18 db = new NewdbEntities18();
            List<maintdetails> maintD = new List<maintdetails>();

            //List<maintdetails> ObjFiles = new List<maintdetails>();
            //clientdetails cd = new clientdetails();
            var num = db.equipement.Select(a => a.id_equip).ToList();
            var dept = db.departement.Select(a => a.libelledep).ToList();
            var rf = db.equipement.Select(a => a.@ref).ToList();
            var lb = db.equipement.Select(a => a.libelleq).ToList();
            var tp = db.type.Select(a => a.denomination).ToList();
            var inter = db.type_entretien.Select(a => a.libellentr).ToList();
            var fic = db.fiche_tech.Select(a => a.fiche).ToList();
            var dt = db.intervention.Select(a => a.date_inter).ToList();
            foreach (int item in num)
            {
                maintdetails ab = new maintdetails();
                ab.Numéro = item;
                ab.Département = dept[item-1 ];
                ab.Référence = rf[item - 1];
                ab.Libellé = lb[item - 1];
                ab.Type = tp[item - 1];
                ab.Historique_de_réparation = (inter[item - 1]) + " : " + (dt[item - 1]);
                maintD.Add(ab);

            }
            ViewBag.Message = maintD;
            return View();

            //return View();
            //List<maintdetails> ObjFiles = new List<maintdetails> ();
            //foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Files")))
            //{
            //    FileInfo fi = new FileInfo(strfile);
            //    maintdetails obj = new maintdetails();
            //    obj.File = fi.Name;
            //    obj.Size = fi.Length;
            //    obj.Type = GetFileTypeByExtension(fi.Extension);
            //    ObjFiles.Add(obj);
            //}
            //return View(ObjFiles);

        }
            [HttpPost]
            public ActionResult gestequip(HttpPostedFileBase file)
            {

            try
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
                    file.SaveAs(filePath);

                }
                ViewBag.Message = "Uploaded Filed succeded";
                return RedirectToAction("gestequip");
            }

            catch
            {
                ViewBag.Message = "jkzdbcumiebzcehf";
                return RedirectToAction("Index");
            }

            //TempData["Message"] = "files uploaded successfully";
            //return RedirectToAction("Index");
        }
   


    //List<maintdetails> ObjFiles = new List<maintdetails>();
    //   foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Files")))
    //   {
    //            FileInfo fi = new FileInfo(strfile);
    //            maintdetails obj = new maintdetails();
    //            obj.File = fi.Name;
    //            obj.Size = fi.Length;
    //            obj.Type = GetFileTypeByExtension(fi.Extension);
    //            ObjFiles.Add(obj);
    //   }

    //   return View(ObjFiles);
    //}
    //public FileResult Download(string fileName)
    //{
    //    string fullPath = Path.Combine(Server.MapPath("~/Files"), fileName);
    //    byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
    //    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    //}
    //private string GetFileTypeByExtension(string fileExtension)
    //{
    //    switch (fileExtension.ToLower())
    //    {
    //        case ".docx":
    //        case ".doc":
    //            return "Microsoft Word Document";
    //        case ".xlsx":
    //        case ".xls":
    //            return "Microsoft Excel Document";
    //        case ".txt":
    //            return "Text Document";
    //        case ".jpg":
    //        case ".png":
    //            return "Image";
    //        default:
    //            return "Unknown";
    //    }
    //}
    //[HttpPost]
    //public ActionResult gestequip(maintdetails doc)
    //{
    //    NewdbEntities15 db = new NewdbEntities15();
    //    List<maintdetails> maintD = new List<maintdetails>();
    //    maintdetails ab = new maintdetails();
    //    fiche_tech fh = new fiche_tech();
    //    foreach (var file in doc.files)
    //    {
    //        if (file.ContentLength > 0)
    //        {
    //            var fileName = Path.GetFileName(file.FileName);
    //            var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
    //            file.SaveAs(filePath);
    //            fh.id_fiche = Int32.Parse(filePath);
    //            ab.Fiche_technique = filePath;
    //        }
    //    }
    //    //maintD.Add(ab);
    //    //ViewBag.Message = maintD;

    //    TempData["Message"] = "files uploaded successfully";
    //    return RedirectToAction("Index");
    //}
    public ActionResult Ajout()
        { return View(); }
        [HttpPost]
        public ActionResult Ajout(class2 cld)
        { 
                NewdbEntities18 db = new NewdbEntities18();
                departement dp = new departement();
                dp.id_dep = (int)cld.id_dep;
                dp.libelledep = cld.libelledep;
                db.departement.Add(dp);
                db.SaveChanges();
                type t = new type();
                t.id_type = (int)cld.id_type;
                t.denomination = cld.denomination;
                db.type.Add(t);
                db.SaveChanges();
                equipement eq = new equipement();
                eq.id_dep = cld.id_dep;
                eq.id_type = t.id_type;
                eq.id_equip = cld.id_equip;
                eq.libelleq = cld.libelleq;
                eq.@ref = cld.@ref;
                db.equipement.Add(eq);
                db.SaveChanges();
                fiche_tech fch = new fiche_tech();
                fch.id_fiche = cld.id_fiche;
                fch.id_equip = cld.id_equip;
                db.fiche_tech.Add(fch);
                db.SaveChanges();
                type_entretien tp = new type_entretien();
                int last = cld.id_typentr;
                tp.id_typentr = last;
                tp.libellentr = cld.libellentr;
                db.type_entretien.Add(tp);
                db.SaveChanges();
               
                return RedirectToAction("gestequip");
            }
        public ActionResult Edit(int? numé)
        {
            equipement e = db.equipement.Find(numé);
            return View(e);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(equipement cld )
        {
            NewdbEntities18 db = new NewdbEntities18();
            db.Entry(cld).State = EntityState.Modified;
            
            db.SaveChanges();
            return RedirectToAction("gestequip");

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        List<maintdetails> maintD = new List<maintdetails>();
            //        maintdetails ab = new maintdetails();
            //        ab.Numéro = mn.Numéro;
            //        ab.Département = mn.Département;
            //        ab.Référence = mn.Référence;
            //        ab.Libellé = mn.Libellé;
            //        ab.Type = mn.Type;
            //        maintD.Add(ab);
            //        //db.Entry(mn).State = EntityState.Modified;
            //        db.SaveChanges();
            //        return RedirectToAction("gestequip");
            //    }
            //    catch (Exception)
            //    {
            //        return RedirectToAction("Index");
            //    }

            //}
            ////db.SaveChanges();
            //return RedirectToAction("gestequip");
            ////return View(eqi);
        }
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            equipement a = db.equipement.Find(id);
            //if (a == null)
            //{
            //    return HttpNotFound();
            //}
            return View(a);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            NewdbEntities18 db = new NewdbEntities18();
            equipement qui = db.equipement.Find(id);

            var l = from b in db.equipement
                    where b.id_equip == id
                    select b.id_equip;

            //equipement p = db.equipement.Find(id);
 
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
            }
            db.SaveChanges();
            db.equipement.Remove(qui);
            db.SaveChanges();
            //db.equipement.Remove(qui);
            //db.SaveChanges();
            return RedirectToAction("gestequip");
        }

        //public ActionResult gestrep()
        //{
        //    NewdbEntities15 db = new NewdbEntities15();
        //    List<repdetails> maintD = new List<repdetails>();
        //    //clientdetails cd = new clientdetails();
        //    var num = db.equipement.Select(a => a.id_equip).ToList();
        //    var dept = db.departement.Select(a => a.libelledep).ToList();
        //    var rf = db.equipement.Select(a => a.@ref).ToList();
        //    var lb = db.equipement.Select(a => a.libelleq).ToList();
        //    var tp = db.type.Select(a => a.denomination).ToList();
        //    var inter = db.type_entretien.Select(a => a.libellentr).ToList();

        //    foreach (int item in num)
        //    {
        //        repdetails ab = new repdetails();
        //        ab.Numéro = item;
        //        ab.Département = dept[item - 1];
        //        ab.Référence = rf[item - 1];
        //        ab.Libellé = lb[item - 1];
        //        ab.Type = tp[item - 1];
        //        ab.intervention = inter[item - 1];
        //        maintD.Add(ab);
        //    }
        //    ViewBag.Message = maintD;
        //    return View(); }
        //public ActionResult valider(int? id)
        //{   
        //    type_entretien te = db.type_entretien.Find(id);
        //    return View(te);
        //}
        //[HttpPost, ActionName("valider")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edittpost(int? id)
        //{
            
        //    var studentToUpdate = db.type_entretien.Find(id);
        //    if (TryUpdateModel(studentToUpdate, "",
        //       new string[] { "libellentr"/*, "FirstMidName", "EnrollmentDate"*/ }))
        //    {
        //        try
        //        {
        //            db.SaveChanges();

        //            return RedirectToAction("gestrep");
        //        }
        //        catch (DataException /* dex */)
        //        {
        //            //Log the error (uncomment dex variable name and add a line here to write a log.
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //        }
        //    }
        //    return View(studentToUpdate);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult valider([Bind(Include = "libellentr")] type_entretien typ)
        //{
        //    try
        //    {
        //        db.Entry(typ).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("gestrep");
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        foreach (var eve in e.EntityValidationErrors)
        //        {
        //            Console.WriteLine("Entity  \"{0}\" exceptions \"{1}\" :", eve.Entry.Entity.GetType().Name, eve.Entry.State);
        //            foreach (var ve in eve.ValidationErrors)
        //            {
        //                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
        //            }
        //        }
        //    }
        //        return RedirectToAction("gestequip");
        //}


        //public ActionResult Delete(int id)
        //{ return View(); }
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        var clt = (from x in listcl where x.Numéro == id select x).Single();
        //        listcl.Remove(clt);
        //        return RedirectToAction("gestequip");
        //    }
        //    catch { return View(); }
        //}
        //////public ActionResult Details(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    departement departement = db.departement.Find(id);
        ////    if (departement == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(departement);
        ////}
        //// GET: departements/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: departements/Create
        //// Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        //// plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id_dep,libelle")] departement departement)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.departement.Add(departement);
        //        db.SaveChanges();
        //        return RedirectToAction("Homee");
        //    }

        //    return View(departement);
        //}

        //// GET: departements/Edit/5
        //public ActionResult eqEdit(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    equipement equipe = db.equipement.Find(id);
        //    //if (equipe == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return View(equipe);
        //}

        //// POST: departements/Edit/5
        //// Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        //// plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]//We use bind when we want that some properties of complex property are ignored when received on server.
        //public ActionResult eqEdit([Bind(Include = "id_equip,ref,libelle,id_dep,id_type,etat")] equipement equipe)
        //{

        //        //if (ModelState.IsValid)
        //        //{

        //            db.Entry(equipe).State = EntityState.Modified;
        //            db.SaveChanges();
        //        return RedirectToAction("gestequip");



        //    //catch (DbUpdateConcurrencyException) { }

        //}

        //// GET: departements/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    equipement equipe = db.equipement.Find(id);
        //    if (equipe == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(equipe);
        //}

        //// POST: departements/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    departement departement = db.departement.Find(id);
        //    db.departement.Remove(departement);
        //    db.SaveChanges();
        //    return RedirectToAction("Homee");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        public ActionResult dempiec()
        {
            NewdbEntities18 db = new NewdbEntities18();
            List<demdetails> demD = new List<demdetails>();
            
            var num = db.equipement.Select(a => a.id_equip).ToList();
            var dept = db.departement.Select(a => a.libelledep).ToList();
            var rf = db.equipement.Select(a => a.@ref).ToList();
            var lb = db.equipement.Select(a => a.libelleq).ToList();
            var tp = db.type.Select(a => a.denomination).ToList();
            var pie = db.piece.Select(a => a.libellep).ToList();


            foreach (int item in num)
            {
                demdetails ab = new demdetails();
                ab.Numéro = item;
                ab.Département = dept[item - 1];
                ab.Référence = rf[item - 1];
                ab.Libellé = lb[item - 1];
                ab.Type = tp[item - 1];
                ab.Piedemandée = pie[item - 1];
                demD.Add(ab);

            }
            ViewBag.Message = demD;
            var li = db.piece.ToList().Distinct();
            SelectList list = new SelectList(li, "id_piece", "libellep");
            ViewBag.Pieces = list;
            return View(); }
        public ActionResult Ajou()
        {   return View(); }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Ajou( piece p)
        {
            
                NewdbEntities18 db = new NewdbEntities18();
                db.piece.Add(p);
                db.SaveChanges();
            //return RedirectToAction("Index");
                return RedirectToAction("dempiec");
        }
        //public ActionResult gestdep()
        //{
        //    NewdbEntities14 db = new NewdbEntities14();
        //    List<dep> demD = new List<dep>();
        //    var dept = db.departement.Select(a => a.libelle).ToList();
        //    foreach (String item in dept)
        //    {
        //        dep ab = new dep();

        //        ab.Département = item;
        //        demD.Add(ab);

        //    }
        //    ViewBag.Message = demD;

        //    return View(); }
        public ActionResult gesttype()
        { return View(); }
        public ActionResult stat()
        { return View(); }
    }
}