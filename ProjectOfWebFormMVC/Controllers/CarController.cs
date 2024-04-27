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
    public class CarController : Controller
    {
       
        public ActionResult Index()
        {
            Car_RegistrationContext db = new Car_RegistrationContext();
            List<Car_Registration> obj = db.GetCars();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Car_Registration c)
        {
            if(ModelState.IsValid==true)
            {
                Car_RegistrationContext db = new Car_RegistrationContext();
                bool check = db.AddCars(c);
                if (check == true)
                {
                    TempData["Insert"] = "Data has been Inserted....";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Insert"] = "Data has not been Inserted....";
                }
            }            
            return View();
        }

        public ActionResult Edit(int Id)
        {
            Car_RegistrationContext db = new Car_RegistrationContext();
            var row = db.GetCars().Find(model => model.Car_Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int Id,Car_Registration c)
        {
            Car_RegistrationContext db = new Car_RegistrationContext();
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
            Car_RegistrationContext db = new Car_RegistrationContext();
            var row = db.GetCars().Find(model => model.Car_Id == Id);
            return View(row);            
        }

        [HttpPost]
        public ActionResult Delete(int Id,Car_Registration c)
        {
            Car_RegistrationContext db = new Car_RegistrationContext();
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
