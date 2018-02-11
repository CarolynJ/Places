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
    public class UserController : ApiController
    {
        private readonly UsersSqlDAL userDal;

      

      

        [System.Web.Http.HttpPost]
        public ActionResult NewUser(User newUser)
        {
            var result = userDal.SaveNewUser(newUser);

            return RedirectToAction("Index");
        }

        private ActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }
    }
}
        