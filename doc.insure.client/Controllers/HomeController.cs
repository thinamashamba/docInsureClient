using doc.insure.client.App_Start;
using doc.insure.entities.custom;
using doc.insure.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace doc.insure.client.Controllers
{
    public class HomeController : Controller
    {
        private docInsureEntities db = new docInsureEntities();


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel loginData, String returnUrl)
        {

            HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoStore();

            if (ModelState.IsValid)
            {
                try
                {

                    string username = loginData.UserName;
                    string passwordRaw = loginData.Password;

                    var user = db.AppUsers.Where(x => x.Email == username && x.Password == passwordRaw).SingleOrDefault();

                    if (user != null)
                    {
                        Session["User"] = user;
                        FormsAuthentication.SetAuthCookie(user.Email, false);

                        ViewBag.FirstName = user.FullName;

                        //return RedirectToAction("Index", "Home");
                        return RedirectToAction("Index", "Documents");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Log In Failed");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error has occured : " + ex.Message + " : " + ex.StackTrace);
                }
            }
            return View();
        }


        [CustomAuthorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;

            //return Redirect("/");
            return RedirectToAction("Index", "Documents");
        }


        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("Index", "Documents");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}