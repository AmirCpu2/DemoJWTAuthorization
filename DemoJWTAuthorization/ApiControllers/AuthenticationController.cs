using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
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
        private AccountRepository _account;
        private AccountLogRepository _accountLog;

        public AuthenticationController(Context context)
        {
            _account = new AccountRepository(context);
            _accountLog = new AccountLogRepository(context);
        }

        /// <summary>
        /// This Method From Login User
        /// </summary>
        /// <param name="account">AccountLogin Model</param>
        /// <returns>Token</returns>
        [HttpPost,Route("login")]
        public IActionResult Login ([FromBody,Required]  VM.AccountLogin account)
        {

            //Get Hash PassWord
            var hashPassword = _account.GetByUserName(account.UserName)?.Password;

            //UserName ,PassWord Check
            if (hashPassword == null || !hashPassword.Equals(PublicFunction.GetHash(account.Password)))
                return Unauthorized();

            //Add Log
            _accountLog.AddForse(_account.GetByUserName(account.UserName).Id,Public.Enums.AccountLogState.login);

            //Logined
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("P@ssM0rdKeyAuthorization"));
            var signinCredenrials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claimes = new List<Claim> 
            {
                new Claim(ClaimTypes.Name,account.UserName),
                new Claim(ClaimTypes.Role,"Manager")
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: $"http://{this.Request.Host}",
                audience: $"http://{this.Request.Host}",
                claims: claimes,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signinCredenrials
            );
            
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { Token = tokenString , Id = _account.GetByUserName(account.UserName).Id });
        }

        /// <summary>
        /// This Method From LoginOut User
        /// </summary>
        /// <param name="token">string jwt token</param>
        /// <returns>token state</returns>
        [HttpPost, Route("logout"),Authorize]
        public IActionResult LogOut([FromHeader,Required] string Authorization)
        {
            try
            {

                var token = Authorization.Split(" ").Length > 1 ? Authorization.Split(" ")[1] : null; //jToken.GetValue("token").ToString();

                //Validate
                if (String.IsNullOrEmpty(token) || !PublicFunction.ValidateToken(token))
                    return Unauthorized();

                //Get UserName Of Peyload
                var username = PublicFunction.DecodeToken(token).Claims.First(q => q.Type == ClaimTypes.Name).Value;

                //Add Log
                _accountLog.AddForse(_account.GetByUserName(username).Id, Public.Enums.AccountLogState.logout);

                return Ok(PublicFunction.GetPrincipalFromExpiredToken(token));
            }
            catch 
            {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Token Validation Checker
        /// </summary>
        /// <param name="token">string Token</param>
        /// <returns>bool status</returns>
        [HttpPost, Route("tokenIsValid")]
        public IActionResult TokenIsValid(string token) => Ok(new { data = PublicFunction.ValidateToken(token).ToString() });

    }
}
