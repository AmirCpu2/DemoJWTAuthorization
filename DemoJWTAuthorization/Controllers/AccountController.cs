using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DemoJWTAuthorization.Models;
using DemoJWTAuthorization.Models.DAL;
using DemoJWTAuthorization.Models.VM;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using VM = DemoJWTAuthorization.Models.VM;

namespace DemoJWTAuthorization.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private Context _context;
        private AccountRepository _account;

        public AccountController(Context context)
        {
            _context = context;
            _account = new AccountRepository(context);
        }

        [HttpGet,Authorize]
        public IActionResult GetAccount(int id)
        {
            return Content(JObject.FromObject(_account.GetById(id)).ToString());
        }

        [HttpPost, Route("add")]
        /// <summary>
        /// This Method From add User
        /// </summary>
        /// <param name="user">Account Model</param>
        /// <returns>result entity from DataBase</returns>
        public IActionResult Add([FromBody, Required]  VM.Account account)
        {
            return Content(JObject.FromObject(_account.Add(account)).ToString());
        }


    }
}