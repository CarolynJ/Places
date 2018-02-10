using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlacesMVCpractice.DAL;
using PlacesMVCpractice.Models;

namespace PlacesMVCpractice.Controllers
{
    public class VacationController : Controller
    {
        private readonly VacationSqlDAL vacationDal;

        public VacationController() { }

        public VacationController(VacationSqlDAL vacationDal)
        {
            this.vacationDal = vacationDal;
        }

        // GET: Vacation
        public ActionResult Index()
        {
            VacationSqlDAL vacationDal = new VacationSqlDAL();
            List<Vacation> vacations = vacationDal.GetList();
           
            return View("Index", vacations);
        }

        // GET: Store/Detail/id
        public ActionResult Detail(int id)
        {
            // Check to make sure that the id is for a valid product
            VacationSqlDAL vacationDal = new VacationSqlDAL();
            var vacation = vacationDal.GetDetail(id);
            if (vacation == null)
            {
                return new HttpNotFoundResult(); //404
            }

            return View("Detail", vacation);
        }

        //----
        // GET: Vacation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vacation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vacation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vacation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vacation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
