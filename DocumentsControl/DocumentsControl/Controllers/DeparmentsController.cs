using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocumentsControl.Models;

namespace DocumentsControl.Controllers
{
    public class DeparmentsController : Controller
    {
        private DocumentsControlEntities db = new DocumentsControlEntities();

        // GET: Deparments
        public ActionResult Index()
        {
            return View(db.Deparment.ToList());
        }

        // GET: Deparments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparment deparment = db.Deparment.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // GET: Deparments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deparments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Department,Name,Acronyms")] Deparment deparment)
        {
            if (ModelState.IsValid)
            {
                db.Deparment.Add(deparment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deparment);
        }

        // GET: Deparments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparment deparment = db.Deparment.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // POST: Deparments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Department,Name,Acronyms")] Deparment deparment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deparment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deparment);
        }

        // GET: Deparments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deparment deparment = db.Deparment.Find(id);
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // POST: Deparments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deparment deparment = db.Deparment.Find(id);
            db.Deparment.Remove(deparment);
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
