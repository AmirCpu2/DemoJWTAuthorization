using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login([FromBody,Required] AccountLogin account)
        {

            var re = new Public.RestClient();

            re.HttpMethod = Public.Enums.HttpVerb.POST;
            
            re.EndPoint = System.IO.Path.Combine("http://Localhost:1080", "/api/");
            re.PostJSON = "";

            return RedirectToAction("Admin");
        }

        public IActionResult Admin()
        {
            //Get Header
            var header = this.Request.Headers;
            header.TryGetValue("Authorization", out var v);

            //var token = Public.RestClient.Instanse.AuthorizationToken = v.ToString().Split(" ")[1];

            //if jwd not Defunde
            if (String.IsNullOrEmpty(v))
            {
                ViewBag["Message"] = "شما باید دوباره وارد شوید";
                ViewBag["token"] = "";

                return View("Login");
            }

            return View();
        }

    }
}
