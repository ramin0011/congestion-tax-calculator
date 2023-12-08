
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
using congestion_tax_calculator_net_shared.Enums;
using congestion_tax_calculator_net_test.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace congestion_tax_calculator_net_test
{
    public class CongestionTaxCalculatorTest : TestCore
    {
        private ICongestionTaxCalculator _service;
        private IUnitOfWork _unitOfWork;
        public CongestionTaxCalculatorTest()
        {
            _service = GetService<ICongestionTaxCalculator>();
            _unitOfWork = GetService<IUnitOfWork>();
        }


        [Theory]
        [InlineData("2013-01-14 21:00:00", "2013-01-15 21:00:00",0)]
        [InlineData("2013-02-07 06:23:27", "2013-02-07 15:27:00", 21)]
        [InlineData("2013-03-26 14:25:00", "2013-03-28 14:07:27", 16)]
        [InlineData("2013-02-08 17:49:00", "2013-02-08 18:29:00", 13)]
        public async void Get_Tax(string date1,string date2,int taxFee)
        {
            var tax=await _service.GetTax(VehiclesTypes.Car,new DateTime[]{DateTime.Parse(date1), DateTime.Parse(date2) },SeedDataCity());
            Assert.Equal(tax,taxFee);
        } 
        

    }
}