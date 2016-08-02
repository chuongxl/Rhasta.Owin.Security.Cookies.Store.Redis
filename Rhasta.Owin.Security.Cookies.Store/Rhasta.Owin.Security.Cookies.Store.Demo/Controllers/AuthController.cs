using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Rhasta.Owin.Security.Cookies.Store.Demo.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Rhasta.Owin.Security.Cookies.Store.Demo.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                /* 
                 * Validate your account at here before creating an authentication ticket.
                 */

                IUserRepository userContext = new UserRepository();

                if (userContext.Verify(model.Email, model.Password))
                {

                    var claims = new List<Claim>();

                    // create *required* claims
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Email));
                    claims.Add(new Claim(ClaimTypes.Name, model.Email));

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);
                    // Authenticate user.
                    Request.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTime.UtcNow.AddDays(7)
                    }, identity);

                    return RedirectToLocal(returnUrl);
                }else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            Request.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);

            return RedirectToAction("LogOn");
        }
    }
}