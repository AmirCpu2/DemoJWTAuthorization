using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VM = DemoJWTAuthorization.Models.VM;

namespace DemoJWTAuthorization.Controllers
{
    [Route("api/Task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        /// <summary>
        /// Get All Task List
        /// </summary>
        /// <returns>Task List Model</returns>
        [Route("getAll"),Authorize]
        public List<VM.Task> GetAll() 
        {
            return new List<VM.Task> 
            { 
                new VM.Task { Id = 1, Description = "Create Demo Project", Agent = "AmirCpu" },
                new VM.Task { Id = 2, Description = "Read ERP Project", Agent = "Scrum Master", },
                new VM.Task { Id = 3, Description = "Call Regularity TCI Agent", Agent = "Bayat" },
                new VM.Task { Id = 4, Description = "Start NewProject", Agent = "Hossein MirzaE" },
                new VM.Task { Id = 5, Description = "Code Cleaning", Agent = "AliReza Hejaz" }
            };
        }

        /// <summary>
        /// Get Performanse
        /// </summary>
        /// <returns>Performans List</returns>
        [Route("getPerformanse"), Authorize]
        public List<List<int>> GetPerformanse()
        {
            return new List<List<int>>
            {
                new List<int> {300, 310, 316, 322, 330, 326, 333, 345, 338, 354},
                new List<int> {320, 340, 365, 360, 370, 385, 390, 384, 408, 420},
                new List<int> {370, 394, 415, 409, 425, 445, 460, 450, 478, 484}
            };
        }

    }
}