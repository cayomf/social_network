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
    public class PostsController : Controller
    {
        private CasaDoPaoDeQueijoContainer db = new CasaDoPaoDeQueijoContainer();

        // GET: Posts
        public ActionResult Index()
        {
            var postSet = db.PostSet.Include(p => p.Profile).Include(p => p.Share);
            return View(postSet.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.PostSet.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email");
            ViewBag.ShareId = new SelectList(db.ShareSet, "Id", "Id");
            return View();
        }

        // POST: Posts/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Date,Media,ProfileId,ShareId")] Post post)
        {
            
            if (ModelState.IsValid)
            {
                post.ProfileId = (int)Session["ProfileId"];
                if (post.ShareId == null)
                {
                    post.ShareId = 00000;
                }
                db.PostSet.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", post.ProfileId);
            ViewBag.ShareId = new SelectList(db.ShareSet, "Id", "Id", post.ShareId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.PostSet.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", post.ProfileId);
            ViewBag.ShareId = new SelectList(db.ShareSet, "Id", "Id", post.ShareId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Date,Media,ProfileId,ShareId")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfileId = new SelectList(db.ProfileSet, "Id", "Email", post.ProfileId);
            ViewBag.ShareId = new SelectList(db.ShareSet, "Id", "Id", post.ShareId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.PostSet.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.PostSet.Find(id);
            db.PostSet.Remove(post);
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
