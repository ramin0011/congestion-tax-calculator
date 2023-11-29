using System;
using congestion.calculator.Models.Vehicles;

namespace congestion.calculator.Services.Interfaces
{
    public interface ICongestionTaxCalculator
    {
        int GetTax(Vehicle vehicle, DateTime[] dates,string city);
        int GetTollFee(DateTime date, Vehicle vehicle,string city);
    }
}