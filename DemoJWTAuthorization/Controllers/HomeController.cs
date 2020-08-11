using System;
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
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace DemoJWTAuthorization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MM.Context _context;
        private readonly IAuthorizationService _authorizationService;
        //private readonly IDocumentRepos itory _documentRepository;

        public HomeController(ILogger<HomeController> logger, MM.Context context, IAuthorizationService authorizationService)
        {
            _logger = logger;
            _context = context;
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return PartialView();
        }

        public ActionResult Admin()
        {
           /* //GetToken
            this.Request.Headers.TryGetValue("Authorization", out var aut);

            var token = aut.ToString()?.Split(" ");

            if (aut.ToString() == null || token.Length < 2 || !PublicFunction.ValidateToken(token[1]))
                return RedirectToAction("Login");
                */
            return PartialView();
        }


    }
}