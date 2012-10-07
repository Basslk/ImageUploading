using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlrawiLtd.Infrastructure;
using System.IO;

namespace ImageUploading.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult Create(Product product, HttpPostedFileBase image)
        //{
        //    //string path=System.IO.Path.Combine(this.ControllerContext.RequestContext.HttpContext.Server.MapPath("/img/") , image.FileName).ToString();
        //    string filePath = null;
        //    if (image != null)
        //    {
        //        string uniqueName = Helpers.GenerateUniqueFileName();
        //        string orignalName = Path.GetFileNameWithoutExtension(image.FileName);
        //        string extension = Path.GetExtension(image.FileName);


        //        filePath = Path.Combine(HttpContext.Server.MapPath("/img/Products/"), uniqueName + extension);
        //        if (ModelState.IsValid)
        //        {
        //            product.PictureUrl = filePath;
        //            context.Products.Add(product);

        //            context.SaveChanges();
        //            image.SaveAs(filePath);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            context.Products.Add(product);

        //            context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(product);
        //}


        public ActionResult About()
        {
            return View();
        }
    }
}
