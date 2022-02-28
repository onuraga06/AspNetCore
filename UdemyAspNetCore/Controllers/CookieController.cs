using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UdemyAspNetCore.Controllers
{
    public class CookieController : Controller
    {

        public IActionResult Index()
        {
            SetCookie();
            ViewBag.Cookie = GetCookie();
            return View();
        }

        private void SetCookie()
        {
            // document.cookie
            HttpContext.Response.Cookies.Append("Course", "Asp Net Core", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(10),
                HttpOnly = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict
            });
        }

        private string GetCookie()
        {
            string cookieValue = string.Empty;
            HttpContext.Request.Cookies.TryGetValue("Course", out cookieValue);
            return cookieValue;
        }


        //Response
        // Request
    }
}
