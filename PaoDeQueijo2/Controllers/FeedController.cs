using Microsoft.AspNet.Identity;
using PaoDeQueijo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaoDeQueijo2.Controllers
{
    public class FeedController : Controller
    {
        // GET: Feed
        public ActionResult Index()
        {
            var DB = new CasaDoPaoDeQueijoContainer();
            string Email = User.Identity.GetEmailAdress();
            var profile = DB.ProfileSet.FirstOrDefault(x => x.Email == Email);
            var posts = DB.PostSet.Where(x => x.ProfileId == profile.Id);

            return View();
            
        }
    }
}