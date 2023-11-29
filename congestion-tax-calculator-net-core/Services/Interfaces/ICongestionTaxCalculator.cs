using System;
using System.Threading.Tasks;
using congestion.calculator.Models.Vehicles;

namespace congestion.calculator.Services.Interfaces
{
    public interface ICongestionTaxCalculator
    {
        Task<int> GetTax(Vehicle vehicle, DateTime[] dates, string city);
        Task<int> GetTollFee(DateTime date, Vehicle vehicle, string city);
    }
}