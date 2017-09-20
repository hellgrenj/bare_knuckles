using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly BloggingContext _bloggingContext;
        public ValuesController(BloggingContext context)
        {
            _bloggingContext = context;
        }
        
        [HttpGet]
        public List<Blog> Get()
        {
            try
            {
                _bloggingContext.Blogs.Add(new Blog() { Urls = "I dont know", Rating = 2 });
                _bloggingContext.SaveChanges();
                var blogs = _bloggingContext.Blogs
                    .Where(b => b.Rating > 1)
                    .OrderBy(b => b.Urls)
                    .ToList();

                return blogs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    }
}
