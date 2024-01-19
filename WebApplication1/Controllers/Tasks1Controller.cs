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
    public class Tasks1Controller : Controller
    {
        private CraftEntities db = new CraftEntities();

        // GET: Tasks1
        /*public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.projet);
            return View(tasks.ToList());
        }*/
        public ActionResult Index(string title)
        {
            // Use the 'title' parameter to filter tasks
            var filteredTasks = db.Tasks.Where(task => task.projet.Titre == title).ToList();

            return View(filteredTasks);
        }
        public ActionResult UpdateStatus(int idT)
        {
            // Find the task by IdT
            var task = db.Tasks.FirstOrDefault(t => t.IdT == idT);

            if (task != null)
            {
                // Update the status to "done" (or any other desired value)
                task.Statu = "done";

                // Save changes to the database
                db.SaveChanges();
            }

            // Redirect back to the previous page or wherever you want to go
            return RedirectToAction("Index", "Tasks");
        }

        // GET: Tasks1/Details/5
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

        // GET: Tasks1/Create
        public ActionResult Create()
        {
            ViewBag.IdP = new SelectList(db.projets, "IdP", "Titre");
            return View();
        }

        // POST: Tasks1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT,Descriptiont,Duree,Statu,IdP")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index", "Tasks");
            }

            ViewBag.IdP = new SelectList(db.projets, "IdP", "Titre", task.IdP);
            return View(task);
        }

        // GET: Tasks1/Edit/5
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
            return View(task);
        }

        // POST: Tasks1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT,Descriptiont,Duree,Statu,IdP")] Task task)
        {
            if (ModelState.IsValid)
            {
                task.Statu = "ended";
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Tasks");
            }
            ViewBag.IdP = new SelectList(db.projets, "IdP", "Titre", task.IdP);
            return View(task);
        }

        // GET: Tasks1/Delete/5
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

        // POST: Tasks1/Delete/5
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
