using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication5.Models;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class mediaController : Controller
    {
        // GET: media

        public ActionResult Indexx()
        {
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
            return View();
        }
        [HttpPost]
        public ActionResult Indexx(HttpPostedFileBase file)
        {

            try
            {

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
                    file.SaveAs(filePath);
                }
                ViewBag.Message = "Uploaded Filed efckle!nchgelu fcefe";
                return View();
            }
            catch
            {
                ViewBag.Message = "jkzdbcumiebzcehf";
                return View();
            }

            //TempData["Message"] = "files uploaded successfully";
            //return RedirectToAction("Index");
        }
    }
}



//        public FileResult Download(string fileName)
//        {
//            string fullPath = Path.Combine(Server.MapPath("~/Files"), fileName);
//            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
//            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
//        }

//        private string GetFileTypeByExtension(string fileExtension)
//        {
//            switch (fileExtension.ToLower())
//            {
//                case ".docx":
//                case ".doc":
//                    return "Microsoft Word Document";
//                case ".xlsx":
//                case ".xls":
//                    return "Microsoft Excel Document";
//                case ".txt":
//                    return "Text Document";
//                case ".jpg":
//                case ".png":
//                    return "Image";
//                default:
//                    return "Unknown";
//            }
//        }
        
//    }
//}
//public class ObjFile
//{
//    public IEnumerable<HttpPostedFileBase> files { get; set; }
//    public string File { get; set; }
//    public long Size { get; set; }
//    public string Type { get; set; }
//}
