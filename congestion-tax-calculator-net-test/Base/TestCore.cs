using congestion.calculator.Services.Interfaces;
using congestion.calculator.Services;
using congestion_tax_calculator_net_core_data.Repositories.Base;
using congestion_tax_calculator_net_core_data.Repositories.Interfaces;
using congestion_tax_calculator_net_core_data.Repositories;
using congestion_tax_calculator_net_core_data.UnitOfWork;
using congestion_tax_calculator_net_core_data;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using congestion.calculator.Models.Congestion;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace congestion_tax_calculator_net_test.Base
{
    public  class TestCore
    {
        public WebApplication Application { get; }

        public TestCore()
        {
            if (Application != null) return;
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddDbContext<CongestionDbContext>(options =>
                options.UseInMemoryDatabase("test"));

            builder.Services.AddControllers();

            builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ICongestionTimeRepository, CongestionTimeRepository>();

            builder.Services.AddScoped<ICongestionTaxCalculator, CongestionTaxCalculator>();
            builder.Services.AddScoped<ICongestionTimeService, CongestionTimeService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           Application= builder.Build();

           Initialize();
        }

        private async void Initialize()
        {
            var db=GetService<IUnitOfWork>();
            await db.CongestionTimeRepository.AddRange(SeedData());
            await db.CompleteAsync();
        }
        public T GetService<T>()
        {
            return Application.Services.GetRequiredService<T>();
        }

        protected List<CongestionTime> SeedData()
        {
            return new List<CongestionTime>()
            {
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 8,
                    StartTime = new TimeSpan(6, 0, 0),
                    EndTime = new TimeSpan(6, 29, 0),
                },
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 13,
                    StartTime = new TimeSpan(6, 30, 0),
                    EndTime = new TimeSpan(6, 59, 0),
                },
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 18,
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(7, 59, 0),
                }, 
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 13,
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(8, 29, 0),
                }, 
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 8,
                    StartTime = new TimeSpan(8, 30, 0),
                    EndTime = new TimeSpan(14, 59, 0),
                }, 
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 13,
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(15, 29, 0),
                },
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 18,
                    StartTime = new TimeSpan(15, 30, 0),
                    EndTime = new TimeSpan(16, 59, 0),
                },
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 13,
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(17, 59, 0),
                }, 
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 8,
                    StartTime = new TimeSpan(18, 0, 0),
                    EndTime = new TimeSpan(18, 29, 0),
                },  
                new CongestionTime()
                {
                    City = SeedDataCity(),
                    Fee = 0,
                    StartTime = new TimeSpan(18, 30, 0),
                    EndTime = new TimeSpan(5, 59, 0),
                },
            };
        }

        protected string SeedDataCity() => "gothenburg";
    }
}
