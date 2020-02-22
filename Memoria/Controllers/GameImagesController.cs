using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Memoria.Data;
using Memoria.Models;

namespace Memoria.Controllers
{
    public class GameImagesController : Controller
    {
        private MemoriaContext db = new MemoriaContext();

        // GET: GameImages
        public ActionResult Index()
        {
            return View(db.GameImages.ToList());
        }

        // GET: GameImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameImage gameImage = db.GameImages.Find(id);
            if (gameImage == null)
            {
                return HttpNotFound();
            }
            return View(gameImage);
        }

        // GET: GameImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdImage,Name,Portada,Image0,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9")] GameImage gameImage)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase FileBase = Request.Files[i];
                WebImage image = new WebImage(FileBase.InputStream);
                switch (i)
                {
                    case 0:
                        gameImage.Portada = image.GetBytes();
                        break;
                    case 1:
                        gameImage.Image0 = image.GetBytes();
                        break;
                    case 2:
                        gameImage.Image1 = image.GetBytes();
                        break;
                    case 3:
                        gameImage.Image2 = image.GetBytes();
                        break;
                    case 4:
                        gameImage.Image3 = image.GetBytes();
                        break;
                    case 5:
                        gameImage.Image4 = image.GetBytes();
                        break;
                    case 6:
                        gameImage.Image5 = image.GetBytes();
                        break;
                    case 7:
                        gameImage.Image6 = image.GetBytes();
                        break;
                    case 8:
                        gameImage.Image7 = image.GetBytes();
                        break;
                    case 9:
                        gameImage.Image8 = image.GetBytes();
                        break;
                    case 10:
                        gameImage.Image9 = image.GetBytes();
                        break;

                }

            }



            if (ModelState.IsValid)
            {
                db.GameImages.Add(gameImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameImage);
        }

        // GET: GameImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameImage gameImage = db.GameImages.Find(id);
            if (gameImage == null)
            {
                return HttpNotFound();
            }
            return View(gameImage);
        }

        // POST: GameImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdImage,Name,Portada,Image0,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9")] GameImage gameImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameImage);
        }

        // GET: GameImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameImage gameImage = db.GameImages.Find(id);
            if (gameImage == null)
            {
                return HttpNotFound();
            }
            return View(gameImage);
        }

        // POST: GameImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameImage gameImage = db.GameImages.Find(id);
            db.GameImages.Remove(gameImage);
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
        public ActionResult getImagek(int id, string type)
        {
            GameImage imagenek = db.GameImages.Find(id);
            byte[] byteImage = null;
            switch (type)
            {
                case "Portada":
                    byteImage = imagenek.Portada;
                    break;
                case "Image0":
                    byteImage = imagenek.Image0;
                    break;
                case "Image1":
                    byteImage = imagenek.Image1;
                    break;
                case "Image2":
                    byteImage = imagenek.Image2;
                    break;
                case "Image3":
                    byteImage = imagenek.Image3;
                    break;
                case "Image4":
                    byteImage = imagenek.Image4;
                    break;
                case "Image5":
                    byteImage = imagenek.Image5;
                    break;
                case "Image6":
                    byteImage = imagenek.Image6;
                    break;
                case "Image7":
                    byteImage = imagenek.Image7;
                    break;
                case "Image8":
                    byteImage = imagenek.Image8;
                    break;
                case "Image9":
                    byteImage = imagenek.Image9;
                    break;

            }
            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;
            return File(memoryStream, "image/jpg");
        }
    }
}
