using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // postgres
            var sqlConnectionString = @"Server=postgres;Database=postgres;User Id=admin;Password=password";
            services.AddDbContext<BloggingContext>(options => options.UseNpgsql(sqlConnectionString));

            // sql server
            // var sqlConnectionString = @"Server=mssql;Database=Blogging;User Id=sa;Password=BareKNuckles10";
            // services.AddDbContext<BloggingContext>(options => options.UseSqlServer(sqlConnectionString));

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
