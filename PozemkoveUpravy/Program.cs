using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PozemkoveUpravy.Data;
using PozemkoveUpravy.Interfaces;
using PozemkoveUpravy.Repository;

namespace PozemkoveUpravy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<PozemkoveUpravyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PozemkoveUpravyContext") ?? throw 
                new InvalidOperationException("Connection string 'PozemkoveUpravyContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // builder.Services.AddScoped<IPozemkovaUpravaRepository, PozemkovaUpravaRepository>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}