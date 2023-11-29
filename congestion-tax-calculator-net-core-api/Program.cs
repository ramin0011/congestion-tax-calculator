using congestion.calculator.Services;
using congestion.calculator.Services.Interfaces;
using congestion_tax_calculator_net_core_data;
using congestion_tax_calculator_net_core_data.Repositories;
using congestion_tax_calculator_net_core_data.Repositories.Base;
using congestion_tax_calculator_net_core_data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace congestion_tax_calculator_net_core_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CongestionDbContext>(options =>
                options.UseInMemoryDatabase("test"));

            builder.Services.AddControllers();

            builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ICongestionTimeRepository, CongestionTimeRepository>();
            
            builder.Services.AddScoped<ICongestionTaxCalculator, CongestionTaxCalculator>();
            builder.Services.AddScoped<ICongestionTimeService, CongestionTimeService>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                    context.Response.Redirect("/swagger");
                else
                    await next.Invoke();
            });
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}