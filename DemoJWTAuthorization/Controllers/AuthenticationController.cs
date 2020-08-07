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
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private Context _context;
        private AccountRepository _account;

        public AuthenticationController(Context context)
        {
            _context = context;
            _account = new AccountRepository(context);
        }

        [HttpPost,Route("login")]
        /// <summary>
        /// This Method From Login User
        /// </summary>
        /// <param name="account">AccountLogin Model</param>
        /// <returns>Token</returns>
        public IActionResult Login ([FromBody,Required]  VM.AccountLogin account)
        {

            //Get Hash PassWord
            var hashPassword = _account.GetAccountByUserName(account.UserName)?.Password;

            //UserName ,PassWord Check
            if (hashPassword == null || !hashPassword.Equals(PublicFunction.GetHash(account.Password)))
                return Unauthorized();

            //Add Log
            //..

            //Logined
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("P@ssM0rdKeyAuthorization"));
            var signinCredenrials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claimes = new List<Claim> 
            {
                new Claim(ClaimTypes.Name,account.UserName),
                new Claim(ClaimTypes.Role,"Manager")
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:44386",//$"http://{this.Request.Host}",
                audience: "http://localhost:44386",//$"http://{this.Request.Host}",
                claims: claimes,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signinCredenrials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { Token = tokenString });
        }

        [HttpPost, Route("loginOut")]
        /// <summary>
        /// This Method From LoginOut User
        /// </summary>
        /// <param name="token">Account Model</param>
        /// <returns>bool state</returns>
        public IActionResult LogOut([FromBody, Required]  string token)
        {
            return null;
        }


        [HttpPost, Route("add")]
        /// <summary>
        /// This Method From add User
        /// </summary>
        /// <param name="user">Account Model</param>
        /// <returns>result entity from DataBase</returns>
        public IActionResult Add([FromBody, Required]  VM.Account account)
        {
            return Content(JObject.FromObject(_account.AddAccount(account)).ToString());
        }


        [HttpGet, Route("Test")]
        [Authorize(Roles = "Manager")]
        public IActionResult Test()
        {
            return Content("hi");
        }

        [HttpGet, Route("amir"), Authorize(Roles ="Manager")]
        public IActionResult amir()
        {
            return Content("hi");
        }
    }
}
