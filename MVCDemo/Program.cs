using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCDemo.Data;
using ContosoUniversity.Data;
using System.Configuration;

using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        //using ContosoPizza.Data;
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<MVCDemoContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MVCDemoContext") ?? throw new InvalidOperationException("Connection string 'MVCDemoContext' not found.")));

        // Add services to the container.
        builder.Services.AddSqlServer<PizzaContext>("Data Source=MVCDemo.Data.db");
        builder.Services.AddControllersWithViews();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDbContext<SchoolContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        var host = CreateHostBuilder(args).Build();

        CreateDbIfNotExists(host);


        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<SchoolContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        host.Run();

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
            pattern: "{controller=Pizza}/{action=Index}/{id?}");

        app.Run();
    }

    private static void CreateDbIfNotExists(IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<SchoolContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }
}