using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DemoJWTAuthorization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VM = DemoJWTAuthorization.Models.VM;

namespace DemoJWTAuthorization.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost,Route("login")]
        /// <summary>
        /// This Method From Login User
        /// </summary>
        /// <param name="user">Account Model</param>
        /// <returns></returns>
        public IActionResult Login ([FromBody,Required]  VM.AccountModel account)
        {
            return Content(JObject.FromObject(account).ToString());
        }

        [HttpGet, Route("Test")]
        public IActionResult Test()
        {
            return Content("hi");
        }
    }
}
