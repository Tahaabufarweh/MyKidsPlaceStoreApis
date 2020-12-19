using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Repository.Context;
using MyKidsPlaceStore.AppMiddleware;
using Domains.Models;
using SamaDelivery.Api.Helpers;
using Service.UnitOfWork;
using Service.Interfaces;
using Service.Services;

namespace MyKidsPlaceStore
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<MyKidsStoreDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddHttpContextAccessor();
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();
           

            services.AddCors();
           
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Kids Place Store Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                             {
                               Reference = new OpenApiReference
                                 {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                 }
                              },
                         new string[] { }
                     }
                 });
            });

            services.AddIdentity<ApplicationUser, Roles>()
                            .AddEntityFrameworkStores<MyKidsStoreDbContext>()
                                    .AddDefaultTokenProviders()
                                    .AddSignInManager();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            });


            services.AddFirebase(Configuration, _webHostEnvironment);
            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.User, Policies.UserPolicy());
            });
            services.AddTokenAuthentication(Configuration);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Kids Place Store Api V1");
            });
        }
    }
}
