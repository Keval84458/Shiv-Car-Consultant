using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectOfWebFormMVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectOfWebFormMVC.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            ServicesContext db = new ServicesContext();
            List<Services> obj = db.GetCarName();
            return View(obj);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Services s)
        {
            ServicesContext db = new ServicesContext();
            bool check = db.AddCarService(s);
            if(check==true)
            {
                TempData["Insert"] = "Data has been inserted..";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Insert"] = "Data has not been inserted..";
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            ServicesContext db = new ServicesContext();
            var row = db.GetCarName().Find(model => model.Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int Id,Services s)
        {
            ServicesContext db = new ServicesContext();
            bool check = db.UpdateCarService(s);
            if (check == true)
            {
                TempData["Update"] = "Data has been Updated..";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Update"] = "Data has not been Updated..";
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            ServicesContext db = new ServicesContext();
            var row = db.GetCarName().Find(model => model.Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int Id,Services s)
        {
            ServicesContext db = new ServicesContext();
            bool check = db.DeleteCarService(Id);
            if (check == true)
            {
                TempData["Delete"] = "Data has been Deleted..";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Delete"] = "Data has not been Deleted..";
            }
            return View();
        }
    }
}