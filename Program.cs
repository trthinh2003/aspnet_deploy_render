using Microsoft.EntityFrameworkCore;
using razorweb.Models;

namespace razorweb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //DBContext
            builder.Services.AddDbContext<MyBlogContext>(options =>
            {
                string connectionString = builder.Configuration.GetConnectionString("MyBlogDB")!;
                //options.UseSqlServer(connectionString);
                options.UseNpgsql(connectionString);
                Console.WriteLine($"Connection string: '{connectionString}'");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
