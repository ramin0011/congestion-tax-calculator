using System;
using System.Threading.Tasks;
using congestion.calculator.Models.Vehicles;
using congestion_tax_calculator_net_shared.Enums;

namespace congestion.calculator.Services.Interfaces
{
    public interface ICongestionTaxCalculator
    {
        Task<int> GetTax(VehiclesTypes vehicle, DateTime[] dates, string city);
        Task<int> GetTollFee(DateTime date, VehiclesTypes vehicle, string city);
    }
}