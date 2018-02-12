using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlacesMVCpractice.DAL;
using PlacesMVCpractice;
using PlacesMVCpractice.Models;
using System.Web.Mvc;

namespace PlacesMVCpractice.Controllers
{
    public class UserController : Controller
    {
        private readonly UsersSqlDAL userDal;

       public ActionResult Input()
        {
            return View("Input");
        }

      public ActionResult Index()
        {
            UsersSqlDAL userDal = new UsersSqlDAL();
            List<User> users = userDal.GetAllUsers();
            return View("Index", users);
        }

        public ActionResult NewUser()
        {
            return View("Input", new User());
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult NewUser(User newUser)
        {
            UsersSqlDAL userDal = new UsersSqlDAL();
            var result = userDal.SaveNewUser(newUser);

            return RedirectToAction("Index");
        }

        private ActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }
    }
}
        