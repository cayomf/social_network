using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaoDeQueijo2;

namespace PaoDeQueijo2.Controllers
{
    public class SharesController : Controller
    {
        private CasaDoPaoDeQueijoContainer db = new CasaDoPaoDeQueijoContainer();

        // GET: Shares
        public ActionResult Index()
        {
            var shareSet = db.ShareSet.Include(s => s.Profile);
            return View(shareSet.ToList());
        }

        // GET: Shares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Share share = db.ShareSet.Find(id);
            if (share == null)
            {
                return HttpNotFound();
            }
            return View(share);
        }

        // GET: Shares/Create
        public ActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email");
            return View();
        }

        // POST: Shares/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,ProfileId")] Share share)
        {
            if (ModelState.IsValid)
            {
                db.ShareSet.Add(share);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", share.ProfileId);
            return View(share);
        }

        // GET: Shares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Share share = db.ShareSet.Find(id);
            if (share == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", share.ProfileId);
            return View(share);
        }

        // POST: Shares/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,ProfileId")] Share share)
        {
            if (ModelState.IsValid)
            {
                db.Entry(share).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", share.ProfileId);
            return View(share);
        }

        // GET: Shares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Share share = db.ShareSet.Find(id);
            if (share == null)
            {
                return HttpNotFound();
            }
            return View(share);
        }

        // POST: Shares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Share share = db.ShareSet.Find(id);
            db.ShareSet.Remove(share);
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
