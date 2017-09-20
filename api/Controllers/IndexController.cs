using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("/")]
    public class IndexController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Im ok"; // HAproxy health check
        }


    }
}
