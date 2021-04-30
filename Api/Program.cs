using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nouran.Domain.Entities;
using Nouran.Infrastructure.Persistence;

namespace Nouran
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();

            using var scope = builder.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<NouranDbContext>();
            context.Add(new Country("USA"));
            context.Add(new Country("France"));
            context.SaveChanges();

            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
            return builder;
        }
    }
}
