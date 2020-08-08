﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VM = DemoJWTAuthorization.Models.VM;
using MM = DemoJWTAuthorization.Models.DAL;


namespace DemoJWTAuthorization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MM.Context _context;

        public HomeController(ILogger<HomeController> logger, MM.Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [Authorize(Roles = "Manager")]
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