using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camarillo_Tennis_Club.Models;
using System.Data;
using System.Web.Helpers;
using Camarillo_Tennis_Club.CustomFilter;


namespace Camarillo_Tennis_Club.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
      
        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }

        //
        // POST: /Account/Login
        [ExceptionHandler]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            try
            {
                string Userrole = "";
                if (!ModelState.IsValid)
                {
                    LoginDBContext loginDBContext = new LoginDBContext();
                    DataSet ds = new DataSet();
                    ds = loginDBContext.getPassword(login.Username);
                    var hashedPassword = Convert.ToString(ds.Tables[0].Rows[0]["UserPassword"]);
                    var doesPasswordMatch = Crypto.VerifyHashedPassword(hashedPassword, login.UserPassword);
                    if (doesPasswordMatch)
                    {
                        Userrole = Convert.ToString(ds.Tables[0].Rows[0]["Userrole"]);
                        Session["Role"] = Userrole;
                        return RedirectToAction("AdminHome");
                    }
                    else
                    {
                        Session["Role"] = "User";
                        return RedirectToAction("Index", "Matches");
                    }


                    // return View(login);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Login", "Login"));
               // return View("Error");
            }

            return View();
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [ExceptionHandler]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginDBContext loginDBContext = new LoginDBContext();
                    var hashedpassword = Crypto.HashPassword(login.UserPassword);
                    login.Userrole = "Admin";
                    login.UserPassword = hashedpassword;
                    loginDBContext.InsertUserDetails(login);
                    Session["Role"] = "Admin";
                    return RedirectToAction("AdminHome");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Login", "Register"));
            }

            return View();
        }

        public ActionResult AdminHome()
        {
            if (Convert.ToString(Session["Role"]) == "Admin")
            {
                return View();
            }
            else
            { return RedirectToAction("Index","Matches"); }
        }


    }
}