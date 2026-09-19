using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using SuperShop.Data;
using SuperShop.Data.Entities;

namespace SuperShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
            RunSeeding(host);
            host.Run();


        }

        public static void RunSeeding(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using(var scope =scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<SeedDb>();
                seeder.SeedAsync().Wait();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public class Product
        {
            // ...

            [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
            public decimal Price { get; set; }
            public User User { get; internal set; }
        }
    }
}
