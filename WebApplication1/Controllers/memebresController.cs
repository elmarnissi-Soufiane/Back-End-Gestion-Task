using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class memebresController : Controller
    {
        private CraftEntities db = new CraftEntities();

        // GET: memebres
        public ActionResult Index()
        {
            return View(db.memebres.ToList());
        }

        // GET: memebres/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memebre memebre = db.memebres.Find(id);
            if (memebre == null)
            {
                return HttpNotFound();
            }
            return View(memebre);
        }

        // GET: memebres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: memebres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdM,Nom,Prenom,Email,Num")] memebre memebre)
        {
            if (ModelState.IsValid)
            {
                db.memebres.Add(memebre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memebre);
        }

        // GET: memebres/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memebre memebre = db.memebres.Find(id);
            if (memebre == null)
            {
                return HttpNotFound();
            }
            return View(memebre);
        }

        // POST: memebres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdM,Nom,Prenom,Email,Num")] memebre memebre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memebre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memebre);
        }

        // GET: memebres/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memebre memebre = db.memebres.Find(id);
            if (memebre == null)
            {
                return HttpNotFound();
            }
            return View(memebre);
        }

        // POST: memebres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            memebre memebre = db.memebres.Find(id);
            db.memebres.Remove(memebre);
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
