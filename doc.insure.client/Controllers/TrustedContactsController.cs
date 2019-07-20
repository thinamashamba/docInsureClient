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
using doc.insure.client.App_Start;

namespace doc.insure.client.Controllers
{
    [CustomAuthorize]
    public class TrustedContactsController : Controller
    {
        private docInsureEntities db = new docInsureEntities();

        // GET: TrustedContacts
        public ActionResult Index()
        {
            var trustedContacts = db.TrustedContactViews.ToList().Select(e => e.Map<TrustedContactView, TrustedContactResult>()).ToList(); ;
            return View(trustedContacts);
        }

        // GET: TrustedContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrustedContact trustedContact = db.TrustedContacts.Find(id);
            if (trustedContact == null)
            {
                return HttpNotFound();
            }
            return View(trustedContact);
        }

        // GET: TrustedContacts/Create
        public ActionResult Create()
        {
            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email");
            ViewBag.ContactAppUserId = new SelectList(db.AppUsers, "AppUserId", "Email");
            ViewBag.RelationShipTypeId = new SelectList(db.RelationShipTypes, "RelationShipTypeId", "RelationShipTypeDesc");
            return View();
        }

        // POST: TrustedContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrustedContactId,AppUserId,ContactAppUserId,TrustedContactCreated,TrustedContactEmail,TrustedContactFullName,RelationShipTypeId,TrustedContactGuid,TrustedContactStatusId")] TrustedContact trustedContact)
        {
            if (ModelState.IsValid)
            {

                trustedContact.AppUserId = 1;
                trustedContact.ContactAppUserId = null;
                trustedContact.TrustedContactCreated = DateTime.Now;
                trustedContact.TrustedContactGuid = Guid.NewGuid();
                trustedContact.TrustedContactStatusId = 1; // Pending


                db.TrustedContacts.Add(trustedContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", trustedContact.AppUserId);
            ViewBag.ContactAppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", trustedContact.ContactAppUserId);
            ViewBag.RelationShipTypeId = new SelectList(db.RelationShipTypes, "RelationShipTypeId", "RelationShipTypeDesc", trustedContact.RelationShipTypeId);
            return View(trustedContact);
        }

        // GET: TrustedContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrustedContact trustedContact = db.TrustedContacts.Find(id);
            if (trustedContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", trustedContact.AppUserId);
            ViewBag.ContactAppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", trustedContact.ContactAppUserId);
            ViewBag.RelationShipTypeId = new SelectList(db.RelationShipTypes, "RelationShipTypeId", "RelationShipTypeDesc", trustedContact.RelationShipTypeId);
            return View(trustedContact);
        }

        // POST: TrustedContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrustedContactId,AppUserId,ContactAppUserId,TrustedContactCreated,TrustedContactEmail,TrustedContactFullName,RelationShipTypeId,TrustedContactGuid,TrustedContactStatusId")] TrustedContact trustedContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trustedContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", trustedContact.AppUserId);
            ViewBag.ContactAppUserId = new SelectList(db.AppUsers, "AppUserId", "Email", trustedContact.ContactAppUserId);
            ViewBag.RelationShipTypeId = new SelectList(db.RelationShipTypes, "RelationShipTypeId", "RelationShipTypeDesc", trustedContact.RelationShipTypeId);
            return View(trustedContact);
        }

        // GET: TrustedContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrustedContact trustedContact = db.TrustedContacts.Find(id);
            if (trustedContact == null)
            {
                return HttpNotFound();
            }
            return View(trustedContact);
        }

        // POST: TrustedContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrustedContact trustedContact = db.TrustedContacts.Find(id);
            db.TrustedContacts.Remove(trustedContact);
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
