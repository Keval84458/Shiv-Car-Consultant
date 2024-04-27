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
    public class SoldCarController : Controller
    {
        // GET: SoldCar
        public ActionResult Index()
        {
            SoldCarContext db = new SoldCarContext();
            List<SoldCar> obj = db.GetCars();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SoldCar s)
        {
            SoldCarContext db = new SoldCarContext();
            bool check = db.AddSoldCars(s);
            if(check==true)
            {
                TempData["Insert"] = "Data has been inserted...";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Insert"] = "Data has not been inserted...";
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            SoldCarContext db = new SoldCarContext();
            var row = db.GetCars().Find(model => model.Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(SoldCar s)
        {
            SoldCarContext db = new SoldCarContext();
            bool check = db.UpdateSoldCars(s);
            if (check == true)
            {
                TempData["Update"] = "Data has been Updated...";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Update"] = "Data has not been Updated...";
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            SoldCarContext db = new SoldCarContext();
            var row = db.GetCars().Find(model => model.Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int Id,SoldCar s)
        {
            SoldCarContext db = new SoldCarContext();
            bool check = db.DeleteSoldCars(Id);
            if (check == true)
            {
                TempData["Delete"] = "Data has been Deleted...";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Delete"] = "Data has not been Deleted...";
            }
            return View();
        }
    }
}