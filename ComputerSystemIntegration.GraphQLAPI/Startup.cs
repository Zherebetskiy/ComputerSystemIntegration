using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerSystemIntegration.DataAccess.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using GraphQL;
using ComputerSystemIntegration.GraphQLAPI.Models;
using GraphQL.Types;

namespace ComputerSystemIntegration.GraphQLAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var dbConfig = new MongoConfig();
            Configuration.Bind("MongoConnection", dbConfig);

            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(IRepository).Assembly);
            services.AddSingleton(dbConfig);
            services.AddTransient<IRepository, Repository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<VacancyQuery>();
            services.AddSingleton<VacancyMutation>();
            //services.AddSingleton<CommentType>();
            services.AddSingleton<VacancyType>();
            services.AddSingleton<VacancyInputType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new VacancySchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
