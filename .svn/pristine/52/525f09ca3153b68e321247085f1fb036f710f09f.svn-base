using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Comments.Web.Controllers.Page
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}