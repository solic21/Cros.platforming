using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;
using LabWork_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabWork_5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            return new SignOutResult(
                new[]
                {
                    OktaDefaults.MvcAuthenticationScheme,
                    CookieAuthenticationDefaults.AuthenticationScheme,
                },
                new AuthenticationProperties { RedirectUri = "/Home/" });
        }

        [HttpGet]
        public IActionResult Profile()
        {
            UserProfileModel myModel = new UserProfileModel();

            myModel.Email = HttpContext.User.Claims.Where(x => x.Type == "email").FirstOrDefault()?.Value.ToString();
            myModel.FirstName = HttpContext.User.Claims.Where(x => x.Type == "given_name").FirstOrDefault()?.Value.ToString();
            myModel.LastName = HttpContext.User.Claims.Where(x => x.Type == "family_name").FirstOrDefault()?.Value.ToString();
            myModel.UserName = HttpContext.User.Claims.Where(x => x.Type == "preferred_username").FirstOrDefault()?.Value.ToString();
            myModel.PhoneNumber = HttpContext.User.Claims.Where(x => x.Type == "phone_number").FirstOrDefault()?.Value.ToString();

            return View(myModel);
        }
    }
}
