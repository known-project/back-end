﻿using System.Threading.Tasks;
using AutoMapper;
using KP.BackEnd.Core;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using KP.BackEnd.Persistence.Repositories;
using KP.BackEnd.Core.Repositories;

namespace KP.BackEnd
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
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseLazyLoadingProxies()
                        .UseNpgsql(
                            Configuration.GetConnectionString("DefaultConnection")
                        )
                ).BuildServiceProvider();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddAutoMapper(typeof(Startup));

            services.Configure<IdentityOptions>(options => {
                //TODO
                //Lax requirements because this is a demo
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.ConfigureApplicationCookie(cookieOptions => {
                cookieOptions.Cookie.SameSite = SameSiteMode.None;
                cookieOptions.Cookie.Name = "auth_cookie";

                cookieOptions.Events = new CookieAuthenticationEvents {
                    OnRedirectToLogin = redirectContext => {
                        redirectContext.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(@"*")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvc() /*options => {
                options.Filters.Add(new ValidateAntiForgeryTokenAttribute());
            })*/.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

//            services.AddAntiforgery(antiforgeryOptions => {
//                antiforgeryOptions.HeaderName = "X-XSRF-TOKEN";
//            });

            // DI Configurations
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IChannelPostRepository, ChannelPostRepository>();
            services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISupervisorRepository, SupervisorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                    .Database.Migrate();
            }
            
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else 
            {
                //TODO
                app.UseHsts();
            }

            // app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}