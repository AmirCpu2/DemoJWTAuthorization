using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MM = DemoJWTAuthorization.Models.DAL;

namespace DemoJWTAuthorization
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAuthorization(op => {
                if (op.InvokeHandlersAfterFailure) 
                {
                    new RedirectToActionResult("Index","Home",new { ErrorMessage = "Token Expyre,Try Logined." });
                }
            });

            services.AddControllersWithViews();

            services.AddControllers();

            #region Authentication
            //Creat Midelware Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(op => {
                    //Token Cofigure
                    op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "http://localhost:44386",
                        ValidAudience = "http://localhost:44386",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("P@ssM0rdKeyAuthorization"))
                        
                    };
                });
            

            services.AddCors(op => {

                op.AddPolicy("DeveloperCors", bl => 
                    {
                        bl.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .Build();
                    });
            });
            #endregion

            #region Db Context

            services.AddDbContext<MM.Context>(op =>
            { op.UseSqlServer("Data Source =.;Initial Catalog=silkrood_DemoWJTAutorization;Integrated Security=true;user id=sa;password=B@mdad!@#246;"); });

            #endregion

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>   
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.MapWhen(context => PublicFunction.ValidateToken(context.Request.Headers["Authorization"]) && 
            //            !context.Request.GetDisplayUrl().Contains("Login") , (new RedirectToActionResult("Index", "Home", new { ErrorMessage = "Token Expyre,Try Logined." }) );

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/

            //config Core for develop
            app.UseCors("DeveloperCors");
        }

    }
}
