
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using congestion.calculator.Services.Interfaces;
using congestion.calculator.Services;
using congestion_tax_calculator_net_core_data.Repositories.Base;
using congestion_tax_calculator_net_core_data.Repositories.Interfaces;
using congestion_tax_calculator_net_core_data.Repositories;
using congestion_tax_calculator_net_core_data.UnitOfWork;
using congestion_tax_calculator_net_core_data;
using congestion_tax_calculator_net_test.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace congestion_tax_calculator_net_test
{
    public class CongestionTimeServiceTest : TestCore
    {
        private ICongestionTimeService _service;
        private IUnitOfWork _unitOfWork;
        public CongestionTimeServiceTest()
        {
            _service = GetService<ICongestionTimeService>();
            _unitOfWork = GetService<IUnitOfWork>();
        }


        [Fact]
        public async void Get_All()
        {
            var data=await _service.GetAll();
            Assert.True(data.Any());
        } 
        
        [Theory]
        [InlineData("new york","21:00:00","22:00:00",10)]
        [InlineData("lisbon","08:00:00","10:00:00",0)]
        [InlineData("texas","13:00:00","13:15:00",80)]
        public async void Create(string city,string startTime,string endTime,int fee)
        {
            await _service.Create(city,TimeSpan.Parse(startTime),TimeSpan.Parse(endTime),fee );
        }

        [Fact]
        public async void Get_By_City()
        {
            var data=await _service.GetAllByCity(SeedDataCity());
            Assert.True(data.Any());
        }
    }
}