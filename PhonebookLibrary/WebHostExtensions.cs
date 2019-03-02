using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhonebookLibrary.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookLibrary
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<PhonebookContext>();

                // now we have the DbContext. Run migrations
                //context.Database.Migrate();

                // now that the database is up to date. Let's seed
                new SampleDataSeeder(context).SeedData();
            }
            return host;
        }
    }
}
