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
    public class TacheController : Controller
    {
        private CraftEntities db = new CraftEntities();

        // GET: Tache
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.projet).Include(t => t.memebre);
            return View(tasks.ToList());
        }

        // GET: Tache/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tache/Create
        public ActionResult Create()
        {
            ViewBag.IdP = new SelectList(db.projets, "IdP", "Titre");
            ViewBag.IdM = new SelectList(db.memebres, "IdM", "Nom");
            return View();
        }

        // POST: Tache/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT,Descriptiont,Duree,Statu,IdP,IdM")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdP = new SelectList(db.projets, "IdP", "Titre", task.IdP);
            ViewBag.IdM = new SelectList(db.memebres, "IdM", "Nom", task.IdM);
            return View(task);
        }

        // GET: Tache/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdP = new SelectList(db.projets, "IdP", "Titre", task.IdP);
            ViewBag.IdM = new SelectList(db.memebres, "IdM", "Nom", task.IdM);
            return View(task);
        }

        // POST: Tache/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT,Descriptiont,Duree,Statu,IdP,IdM")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdP = new SelectList(db.projets, "IdP", "Titre", task.IdP);
            ViewBag.IdM = new SelectList(db.memebres, "IdM", "Nom", task.IdM);
            return View(task);
        }

        // GET: Tache/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tache/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
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
