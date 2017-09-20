using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("/demo")]
    public class DemoController : Controller
    {

        [HttpGet]
        public string Get()
        {
            Console.WriteLine("handling request");
            return "some response";
        }


    }
}
