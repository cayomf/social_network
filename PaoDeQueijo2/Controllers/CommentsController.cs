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
    public class CommentsController : Controller
    {
        private CasaDoPaoDeQueijoContainer db = new CasaDoPaoDeQueijoContainer();

        // GET: Comments
        public ActionResult Index()
        {
            var commentSet = db.CommentSet.Include(c => c.Profile).Include(c => c.Post);
            return View(commentSet.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.CommentSet.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email");
            ViewBag.PostId = new SelectList(db.PostSet, "Id", "Text");
            return View();
        }

        // POST: Comments/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Date,ProfileId,PostId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.CommentSet.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", comment.ProfileId);
            ViewBag.PostId = new SelectList(db.PostSet, "Id", "Text", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.CommentSet.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", comment.ProfileId);
            ViewBag.PostId = new SelectList(db.PostSet, "Id", "Text", comment.PostId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Date,ProfileId,PostId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", comment.ProfileId);
            ViewBag.PostId = new SelectList(db.PostSet, "Id", "Text", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.CommentSet.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.CommentSet.Find(id);
            db.CommentSet.Remove(comment);
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
