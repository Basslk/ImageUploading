using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageUploading.Models;
using System.IO;
using AlrawiLtd.Infrastructure;

namespace ImageUploading.Controllers
{   
    [HandleError()]
    public class ProductsController : Controller
    {
        private ImageUploadingContext context = new ImageUploadingContext();

        //
        // GET: /Products/

        public ViewResult Index()
        {
            return View(context.Products.ToList());
        }

        //
        // GET: /Products/Details/5

        public ViewResult Details(int id)
        {
            Product product = context.Products.Single(x => x.ProductId == id);
            return View(product);
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            return View(new Product());
        } 

        //
        // POST: /Products/Create

        [HttpPost]
        public ActionResult Create(Product product, IEnumerable<HttpPostedFileBase> image)
        {
            if (ModelState.IsValid)
            {
                product.ProductPhotos = new System.Collections.ObjectModel.Collection<Photo>();
                foreach (var item in image)
                {

                    string t = this.ControllerContext.RequestContext.HttpContext.Server.MapPath("/App_Data");
                    string path = System.IO.Path.Combine(t, item.FileName).ToString();
                    string filePath = null;
                    if (image != null)
                    {
                        string uniqueName = Helpers.GenerateUniqueFileName();
                        string orignalName = Path.GetFileNameWithoutExtension(item.FileName);
                        string extension = Path.GetExtension(item.FileName);


                        filePath = Path.Combine(HttpContext.Server.MapPath("/App_Data"), uniqueName + extension);
                        product.ProductPhotos.Add(new Photo { PhotoUrl = filePath });
                        item.SaveAs(filePath);
                    }

                }

                
                context.Products.Add(product);
                context.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(product);
        }

        //
        // GET: /Products/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = context.Products.Single(x => x.ProductId == id);
            return View(product);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Products/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = context.Products.Single(x => x.ProductId == id);
            return View(product);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = context.Products.Single(x => x.ProductId == id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        //public ActionResult GetImage(int productId)
        //{
        //    Product prod = context.Products.FirstOrDefault(p => p.ProductId == productId);
        //    if (prod != null)
        //    {
        //        if (prod.ProductImageUrl != null)
        //        {
        //            var result = File(prod.ProductImageUrl, "image/jpeg");
        //            return result;
        //        }
        //        else
        //            return null;
        //    }
        //    else
        //        return null;
        //}
        [OutputCache(Duration = int.MaxValue, VaryByParam = "PhotoId",Location=System.Web.UI.OutputCacheLocation.Client)] 
        public FilePathResult GetImage(int PhotoId)
        {
            Photo prod = context.Photos.FirstOrDefault(p => p.PhotoId == PhotoId);
            if (prod != null)
            {
                if (prod.PhotoUrl != null)
                {
                    var result = File(prod.PhotoUrl, "image/png");
                    return result;
                }
                else
                    return null;
            }
            else
                return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}