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
    public class MahindraController : Controller
    {
        // GET: Mahindra
        public ActionResult Index()
        {
            MahindraContext db = new MahindraContext();
            List<Mahindra> obj = db.GetCars();
            return View(obj);
        }

        public ActionResult Edit(int Id)
        {
            MahindraContext db = new MahindraContext();
            var row = db.GetCars().Find(model => model.Car_Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int Id, Mahindra c)
        {
            MahindraContext db = new MahindraContext();
            bool check = db.UpdateCars(c);
            if (check == true)
            {
                TempData["Update"] = "Data has been Updated....";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Update"] = "Data has not been Updated....";
            }
            return View();
        }
        public ActionResult Delete(int Id)
        {
            MahindraContext db = new MahindraContext();
            var row = db.GetCars().Find(model => model.Car_Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int Id, Mahindra c)
        {
            MahindraContext db = new MahindraContext();
            bool check = db.DeleteCars(Id);
            if (check == true)
            {
                TempData["Delete"] = "Data has been Updated....";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Delete"] = "Data has not been Updated....";
            }
            return View();
        }
    }
}