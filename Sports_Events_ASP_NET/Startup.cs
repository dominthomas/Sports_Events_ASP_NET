﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsEvents.Models;

namespace Sports_Events_ASP_NET
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
        Configuration = configuration;

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            SqliteConnectionStringBuilder dbStrBuilder = new SqliteConnectionStringBuilder();
            dbStrBuilder.DataSource = "./sports_events_sqlite_db.db";
            //SqliteConnection dbConnection = new SqliteConnection(dbStrBuilder.ConnectionString);

            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlite(dbStrBuilder.ConnectionString));
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=HomePage}/{id?}");
            });
        }
    }
}