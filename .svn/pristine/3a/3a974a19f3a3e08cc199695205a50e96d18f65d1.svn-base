using System.Diagnostics;
using System.Web.Mvc;

namespace Comments.Web.Controllers.Page
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Debugger.Launch();
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToRoute(new {Controller = "Login", Action = "Index"});
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}