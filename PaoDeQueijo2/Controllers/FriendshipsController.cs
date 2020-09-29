using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaoDeQueijo2;
using PaoDeQueijo2.Models;

namespace PaoDeQueijo2.Controllers
{
    public class FriendshipsController : Controller
    {
        private CasaDoPaoDeQueijoContainer db = new CasaDoPaoDeQueijoContainer();

        // GET: Friendships
        public ActionResult Index()
        {
            var DB = new CasaDoPaoDeQueijoContainer();
            string Email = User.Identity.GetEmailAdress();
            List<Profile> friends = new List<Profile>();
            var profile = DB.ProfileSet.FirstOrDefault(x => x.Email == Email);
            var friendships = DB.FriendshipSet.Where(x => x.FirstUser == profile.Id || x.SecondUser == profile.Id && x.Accepted == true);
            foreach(var friendship in friendships)
            {
                if(friendship.FirstUser == profile.Id)
                {
                    friends = DB.ProfileSet.Where(x => x.Id == friendship.SecondUser).ToList();
                }
                else
                {
                    List<Profile> friends2 = DB.ProfileSet.Where(x => x.Id == friendship.FirstUser).ToList();
                    foreach(var friend in friends2)
                    {
                        friends.Add(friend);
                    }
                    
                }
            }
            return View(db.FriendshipSet.ToList());
        }

        // GET: Friendships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friendship friendship = db.FriendshipSet.Find(id);
            if (friendship == null)
            {
                return HttpNotFound();
            }
            return View(friendship);
        }

        // GET: Friendships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friendships/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstUser,SecondUser,Accepted")] Friendship friendship)
        {
            if (ModelState.IsValid)
            {
                db.FriendshipSet.Add(friendship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friendship);
        }

        // GET: Friendships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friendship friendship = db.FriendshipSet.Find(id);
            if (friendship == null)
            {
                return HttpNotFound();
            }
            return View(friendship);
        }

        // POST: Friendships/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstUser,SecondUser,Accepted")] Friendship friendship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friendship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friendship);
        }

        // GET: Friendships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friendship friendship = db.FriendshipSet.Find(id);
            if (friendship == null)
            {
                return HttpNotFound();
            }
            return View(friendship);
        }

        // POST: Friendships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friendship friendship = db.FriendshipSet.Find(id);
            db.FriendshipSet.Remove(friendship);
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
