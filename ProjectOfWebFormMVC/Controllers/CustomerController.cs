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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            Customer_RegistrationContext db = new Customer_RegistrationContext();
            List<Customer_Registration> obj = db.GetCustomer();
            return View(obj);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer_Registration c)
        {
            if (ModelState.IsValid == true)
            {
                Customer_RegistrationContext db = new Customer_RegistrationContext();
                bool check = db.AddCustomer(c);
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
            Customer_RegistrationContext db = new Customer_RegistrationContext();
            var row = db.GetCustomer().Find(model => model.Customer_Id == Id);
            return View(row);
        }


        [HttpPost]
        public ActionResult Edit(int Id, Customer_Registration c)
        {
            if (ModelState.IsValid == true)
            {
                Customer_RegistrationContext db = new Customer_RegistrationContext();
                bool check = db.UpdateCustomer(c);
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
            }

            return View();
        }

        public ActionResult Delete(int Id)
        {
            Customer_RegistrationContext db = new Customer_RegistrationContext();
            var row = db.GetCustomer().Find(model => model.Customer_Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int Id, Customer_Registration c)
        {
            Customer_RegistrationContext db = new Customer_RegistrationContext();
            bool check = db.DeleteCustomer(Id);
            if (check == true)
            {
                TempData["Delete"] = "Data has been Deleted....";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Delete"] = "Data has not been Deleted....";
            }
            return View();
        }


        public ActionResult Details(int id)
        {
            Customer_RegistrationContext db = new Customer_RegistrationContext();
            var row = db.GetCustomer().Find(model => model.Customer_Id == id);
            return View(row);
        }

    }
}