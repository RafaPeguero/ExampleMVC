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
    public class DocumentsController : Controller
    {
        private DocumentsControlEntities db = new DocumentsControlEntities();

        // GET: Documents
        public ActionResult Index()
        {
            var document = db.Document.Include(d => d.Deparment).Include(d => d.Deparment1).Include(d => d.User);
            return View(document.ToList());
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            ViewBag.ID_departmentOrigin = new SelectList(db.Deparment, "ID_Department", "Name");
            ViewBag.ID_departmentDestination = new SelectList(db.Deparment, "ID_Department", "Name");
            ViewBag.ID_User = new SelectList(db.User, "ID_Usuario", "Name");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Document,ID_User,ID_departmentOrigin,ID_departmentDestination,Document_Name,Description")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Document.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_departmentOrigin = new SelectList(db.Deparment, "ID_Department", "Name", document.ID_departmentOrigin);
            ViewBag.ID_departmentDestination = new SelectList(db.Deparment, "ID_Department", "Name", document.ID_departmentDestination);
            ViewBag.ID_User = new SelectList(db.User, "ID_Usuario", "Name", document.ID_User);

            return View(document);
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_departmentOrigin = new SelectList(db.Deparment, "ID_Department", "Name", document.ID_departmentOrigin);
            ViewBag.ID_departmentDestination = new SelectList(db.Deparment, "ID_Department", "Name", document.ID_departmentDestination);
            ViewBag.ID_User = new SelectList(db.User, "ID_Usuario", "Name", document.ID_User);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Document,ID_User,ID_departmentOrigin,ID_departmentDestination,Document_Name,Description")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_departmentOrigin = new SelectList(db.Deparment, "ID_Department", "Name", document.ID_departmentOrigin);
            ViewBag.ID_departmentDestination = new SelectList(db.Deparment, "ID_Department", "Name", document.ID_departmentDestination);
            ViewBag.ID_User = new SelectList(db.User, "ID_Usuario", "Name", document.ID_User);
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Document.Find(id);
            db.Document.Remove(document);
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
