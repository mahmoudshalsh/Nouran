using System.Globalization;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nouran.Domain.Entities;
using Nouran.Infrastructure.Persistence;

namespace Nouran
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<Countries.Add.Validator>();
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nouran", Version = "v1" });
                c.CustomSchemaIds(t => t.FullName.Replace("Nouran.", ""));
            });
            services.AddMediatR(GetType().Assembly);
            services.AddAutoMapper(GetType().Assembly);
            services.AddDbContext<NouranDbContext>(options => options.UseSqlServer("NouranDB"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nouran v1"));
            app.UseRequestLocalization(options =>
            {
                options.SupportedCultures = new[] { new CultureInfo("en") };
                options.SupportedUICultures = new[] { new CultureInfo("en"), new CultureInfo("ar") };
                options.DefaultRequestCulture = new RequestCulture(new CultureInfo("ar"));
            });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
