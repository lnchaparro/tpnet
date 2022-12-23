using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CRUD1.Security;
using CRUD1.Data;

namespace CRUD1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            var cn = new Connection();
            builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(cn.GetSQLInfo()));
            builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Security/SignIn";
                options.AccessDeniedPath = "/Security/AccessDenied";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Proveedor}/{action=Listar}/{id?}");

            app.Run();
        }
    }
}