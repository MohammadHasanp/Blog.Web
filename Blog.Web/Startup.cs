using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Blog.CoreLayer.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Blog.CoreLayer.Services.Category;
using Blog.CoreLayer.Services.Posts;
using Blog.CoreLayer.Services.FileManager;
using Blog.CoreLayer.Services.Comment;
using Blog.CoreLayer.Services.Mainpage;

namespace Blog.Web
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
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddScoped<ICategoryServices,CategoryServices>();
            services.AddScoped<IUserServices,UserServices>();
            services.AddScoped<IFileManager,FileManager>();
            services.AddTransient<IPostServices,Postservices>();
            services.AddTransient<ICommentServices,CommentServices>();
            services.AddTransient<IMainPageService, MainPageService>();
            services.AddDbContext<BlogContext>(Option =>
            {
                Option.UseSqlServer(Configuration.GetConnectionString("Defualt"));
            });
            services.AddAuthorization(option =>
            {
                option.AddPolicy("adminPolicy", builder =>
                {
                    builder.RequireRole("Admin");
                });
            });
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(option =>
            {
                option.LoginPath = "/Auth/Login";
                option.LogoutPath = "/Auth/Logout";
                option.ExpireTimeSpan = TimeSpan.FromDays(30);
                option.AccessDeniedPath="/";
            });
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
                app.UseExceptionHandler("/ErrorHandler/500");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithRedirects("/ErrorHandler/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{Area:Exists}/{Controller=Home}/{Action=Index}/{id?}"
                    );
                endpoints.MapRazorPages();
            });
        }
    }
}
