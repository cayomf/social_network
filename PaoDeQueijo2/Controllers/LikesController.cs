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
    public class LikesController : Controller
    {
        private CasaDoPaoDeQueijoContainer db = new CasaDoPaoDeQueijoContainer();

        // GET: Likes
        public ActionResult Index()
        {
            var likeSet = db.LikeSet.Include(l => l.Profile).Include(l => l.Post);
            return View(likeSet.ToList());
        }

        // GET: Likes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.LikeSet.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        // GET: Likes/Create
        public ActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email");
            ViewBag.PostId = new SelectList(db.PostSet, "Id", "Text");
            return View();
        }

        // POST: Likes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Liked,ProfileId,PostId")] Like like)
        {
            if (ModelState.IsValid)
            {
                db.LikeSet.Add(like);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", like.ProfileId);
            ViewBag.PostId = new SelectList(db.PostSet, "Id", "Text", like.PostId);
            return View(like);
        }

        // GET: Likes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.LikeSet.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", like.ProfileId);
            ViewBag.PostId = new SelectList(db.PostSet, "Id", "Text", like.PostId);
            return View(like);
        }

        // POST: Likes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Liked,ProfileId,PostId")] Like like)
        {
            if (ModelState.IsValid)
            {
                db.Entry(like).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", like.ProfileId);
            ViewBag.PostId = new SelectList(db.PostSet, "Id", "Text", like.PostId);
            return View(like);
        }

        // GET: Likes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.LikeSet.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        // POST: Likes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Like like = db.LikeSet.Find(id);
            db.LikeSet.Remove(like);
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
