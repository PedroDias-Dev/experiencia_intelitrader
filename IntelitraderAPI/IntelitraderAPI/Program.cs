using IntelitraderAPI.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace IntelitraderAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseUrls("http://*:5000")
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<UsersContext>();
            //    context.Database.Migrate();

            //    var config = host.Services.GetRequiredService<IConfiguration>();

            //    var testUserPw = config["SeedUserPW"];
            //    var logger = services.GetRequiredService<ILogger<Program>>();

            //    try
            //    {
            //        PrepDB.SeedData(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        logger.LogError(ex.Message, "An error occurred seeding the DB.");
            //    }
            //}

            //Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Debug()
                //.WriteTo.File($"Logs/{DateTime.Now}log.txt")
                //.CreateLogger();

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.AddConsole();
                     logging.AddFile("Logs/{Date}_log.txt");
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
