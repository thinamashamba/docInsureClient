using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using doc.insure.entities.models;
using doc.insure.entities.custom;
using doc.insure.common.Extensions;
using doc.insure.logic;
using doc.insure.client.App_Start;

namespace doc.insure.client.Controllers
{
    [CustomAuthorize]
    public class DocumentsController : Controller
    {
        private docInsureEntities db = new docInsureEntities();

        // GET: Documents
        public ActionResult Index()
        {
            var documents = db.DocumentViews.ToList().Select(e => e.Map<DocumentView, DocumentResult>()).ToList();
            return View(documents);
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email");
            ViewBag.DocumentCategoryId = new SelectList(db.DocumentCategories, "DocumentCategoryId", "DocumentCategoryDesc");
            return View();
        }

        [HttpPost]
        public ActionResult FileUploadCreate(HttpPostedFileBase file, Document document)
        {
            if (ModelState.IsValid && file != null)
            {


                var filePath = new DocumentLogic().AddNewFile(file);
                //fantasyQuiz.QuestionImageUrl = imageUrl;

                document.DocumentLink = filePath;
                document.OriginalFileName = file.FileName;

                document.AppUserId = 1;
                document.DocumentGUID = Guid.NewGuid();
                document.dtCreated = DateTime.Now;

                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");


            }

            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email");
            ViewBag.DocumentCategoryId = new SelectList(db.DocumentCategories, "DocumentCategoryId", "DocumentCategoryDesc");
            return View(document);
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentId,AppUserId,DocumentTitle,DocumentDescription,DocumentGUID,DocumentLink,DocumentCategoryId")] Document document)
        {
            if (ModelState.IsValid)
            {

                document.AppUserId = 1;
                document.DocumentGUID = Guid.NewGuid();
                document.dtCreated = DateTime.Now;

                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", document.AppUserId);
            return View(document);
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", document.AppUserId);
            ViewBag.DocumentCategoryId = new SelectList(db.DocumentCategories, "DocumentCategoryId", "DocumentCategoryDesc", document.DocumentCategoryId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentId,AppUserId,DocumentTitle,DocumentDescription,DocumentGUID,DocumentLink,DocumentCategoryId,dtCreated")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", document.AppUserId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
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
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
