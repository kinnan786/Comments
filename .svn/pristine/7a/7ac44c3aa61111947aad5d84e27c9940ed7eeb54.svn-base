using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Comments.Facebook;
using Comments.Facebook.Model;
using Comments.Web.DbContext;
using Comments.Web.Models;
using Facebook;

namespace Comments.Web.Controllers.Page
{
    public class LoginController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url)
                {
                    Query = null,
                    Fragment = null,
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Path = Url.Action("FacebookCallback")
                };
                return uriBuilder.Uri;
            }
        }

        public ActionResult FacebookCallback(string code)
        {
            try
            {
                Debugger.Launch();
                var facebookClient = new FacebookClient();

                dynamic result = facebookClient.Post("oauth/access_token", new
                {
                    client_id = FacebookSettings.ClientId,
                    client_secret = FacebookSettings.ClientSecret,
                    redirect_uri = RedirectUri.AbsoluteUri,
                    code
                });

                facebookClient.AccessToken = result.access_token;

                // Get the user's information
                dynamic userInfo = facebookClient.Get("me?fields=first_name,last_name,id,email");

                string userId = userInfo.id;

                var userModelExits = WebUow.Instance.RepoOf<Users>()
                    .Get(q => q.facebookid == userId).SingleOrDefault();


                if (userModelExits == null)
                {
                    userModelExits = new Users
                    {
                        name = userInfo.first_name,
                        facebookid = userInfo.id,
                        email = userInfo.email,
                        datecreated = DateTime.Now,
                        lastlogin = DateTime.Now
                    };

                    WebUow.Instance.RepoOf<Users>().Add(userModelExits, true);

                    var facebooktemptoken = new FacebookAccessToken
                    {
                        Fuserid = userInfo.id,
                        accesstoken = facebookClient.AccessToken,
                        userid = userModelExits.Id,
                        generatedon = DateTime.Now
                    };

                    WebUow.Instance.RepoOf<FacebookAccessToken>().Add(facebooktemptoken, true);
                }
                else
                {
                    userModelExits.lastlogin = DateTime.Now;
                    WebUow.Instance.RepoOf<Users>().Update(userModelExits, true);
                }

                var ticket = new FormsAuthenticationTicket(1,
                    userInfo.id,
                    DateTime.Now,
                    DateTime.Now.AddDays(360),
                    true,
                    userModelExits.Id.ToString(),
                    FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                var encTicket = FormsAuthentication.Encrypt(ticket);

                var nawaz = new HttpCookie(FormsAuthentication.FormsCookieName)
                {
                    Value = encTicket,
                    Expires = DateTime.Now.AddDays(360)
                    //Secure = true,
                    //HttpOnly = true
                };
                ControllerContext.HttpContext.Response.Cookies.Add(nawaz);

                var token =
                    WebUow.Instance.RepoOf<FacebookAccessToken>()
                        .Get(q => q.Fuserid == userId)
                        .SingleOrDefault() ?? new FacebookAccessToken();

                var facebookClient1 = new FacebookClient();

                dynamic result1 = facebookClient1.Post("oauth/access_token", new
                {
                    grant_type = "fb_exchange_token",
                    client_id = FacebookSettings.ClientId,
                    client_secret = FacebookSettings.ClientSecret,
                    fb_exchange_token = facebookClient.AccessToken
                });
                token.accesstoken = result1.access_token;
                token.expiry = int.Parse(result1.expires.ToString());
                token.generatedon = DateTime.Now;
                token.Fuserid = userInfo.id;
                token.userid = userModelExits.Id;
                WebUow.Instance.RepoOf<FacebookAccessToken>().Update(token, true);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                if (User.Identity.IsAuthenticated)
                    FormsAuthentication.SignOut();
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        public ActionResult Facebook()
        {
            try
            {
                var facebookClient = new FacebookClient();
                var loginUrl = facebookClient.GetLoginUrl(new
                {
                    client_id = FacebookSettings.ClientId,
                    client_secret = FacebookSettings.ClientSecret,
                    redirect_uri = RedirectUri.AbsoluteUri,
                    response_type = "code",
                    scope = "email" // Add other permissions as needed
                });

                return Redirect(loginUrl.AbsoluteUri);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                Debugger.Launch();
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(new LoginViewModel());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
    }
}