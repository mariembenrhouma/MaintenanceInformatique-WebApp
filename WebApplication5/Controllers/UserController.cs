using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using System.Data;
using System.Configuration;
using WebApplication5.ViewModel;
using System.Data.SqlClient;
using Amazon.DynamoDBv2;

namespace WebApplication5.Controllers
{
    public class UserController : Controller
    {   //create an object of database
        NewdbEntities18 db = new NewdbEntities18();
        public static string depar;
        //SqlCommand com = new SqlCommand();
        //SqlDataReader dr;
        //SqlConnection con = new SqlConnection();

        //// GET: User
        //public ActionResult Clienttt()
        //{
        //    NewdbEntities10 db1 = new NewdbEntities10();
        //    var mymodel = new Class1();
        //    mymodel.equi = db1.equipement.ToList();
        //    mymodel.dep = db1.departement.ToList();
        //    mymodel.dem = db1.demande.ToList();
        //    mymodel.typ = db1.type.ToList();
        //    mymodel.tyentr = db1.type_entretien.ToList();
        //    mymodel.inter =db1.intervention.ToList();
        //    mymodel.pie = db1.piece.ToList();
        //    mymodel.fiche = db1.fiche_tech.ToList();
        //    var  mary =from c in equipement 
        //               join  d in fiche_tech on c.id_equip equals d.id_equip into table1
        //               from d in table1.DefaultIfEmpty()
        //               join 
        //    return View(mymodel);
        //}
        //private void FetchData() { }
          
       

        
        public ActionResult signin()
        {   
            return View(); }
        [HttpPost]
        public ActionResult signin(eya r)
        {  
            //public string dept;
            //clientdetails ab = new clientdetails();
            //List<clientdetails> clientD = new List<clientdetails>();
            var lg = db.eya.Where(a => a.login.Equals(r.login) && a.password.Equals(r.password)).FirstOrDefault();
            Session["login"] = r.login.ToString();
            
            if (lg != null) 
            {   if (r.role == "Client")
                {

                    depar = r.departement.ToString();
                    return RedirectToAction("Ajoutdema", "Client");}
                else
                {
                    return RedirectToAction("Index", "mainten");
                }
                    
            }
            return View();
        }
        


        //create new action method for registration
     
        public ActionResult Registration()
        { return View(); }
        [HttpPost]// P & G are both the methods of posting client data or form data to the server. HTTP is a HyperText Transfer Protocol that is designed to send and receive the data between client and server using web pages
        public ActionResult Registration(eya r)//reg is our table name
        {
            if (db.eya.Any(a => a.login == r.login))
            {
                ViewBag.Notification = "This account has already existed";
                return View();
            }
            else
            {
                db.eya.Add(r);
                db.SaveChanges();
                Session["login"] = r.login.ToString();
                Session["password"] = r.password.ToString();
                Session["dep"] = r.departement.ToString();
                Session["email"] = r.email.ToString();
                Session["role"] = r.role.ToString();

                
                return RedirectToAction("signin","User");
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("signin", "User");
        }

        // GET: User/Details/5



        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
