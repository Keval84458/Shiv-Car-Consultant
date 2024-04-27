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
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login l)
        {

            LoginContext db = new LoginContext();
            bool check=db.CheckData(l);
            if(check==true)
            {
                ModelState.Clear();
                return RedirectToAction("Success");               
            }
            return RedirectToAction("Index");
        }


        public ActionResult Success()
        {
            return View();
        }

       

    }
}