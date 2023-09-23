using System;
using System.Linq;
using congestion.calculator;
using congestion.calculator.Helpers;
using congestion.calculator.Helpers.DateHelpers;
using congestion.calculator.Models.Vehicles;
using congestion_tax_calculator_net_core_data;

public partial class CongestionTaxCalculator
{
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    private CongestionTimeService _service;
    public CongestionTaxCalculator()
    {
        _service = new CongestionTimeService();
    }
    public int GetTax(Vehicle vehicle, DateTime[] dates,string city)
    {
        int totalFee = 0;
        foreach (var item in dates.GroupByCloseDates(60))
        {
            int currentFee = GetTollFee(item.Key,vehicle,city);
            foreach (var date in item.Value)
            {
               var _fee = GetTollFee(date, vehicle, city);
               if (_fee>currentFee)
                    currentFee= _fee;
            }
            totalFee += currentFee;
            if (totalFee > 60)
            {
                totalFee= 60;
                break;
            }
        }
        return totalFee;
    }
    
    private bool IsTollFreeVehicle(Vehicle vehicle)
    {
        if (vehicle == null) return false;
        return vehicle.GetVehicleType() != VehiclesTypes.Car;
    }

    public int GetTollFee(DateTime date, Vehicle vehicle,string city)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;
        var data = _service.GetAll(city);

        TimeSpan timeSpan = new TimeSpan(date.Hour,date.Minute,date.Second);

        var congestion = data.FirstOrDefault(a => a.StartTime <= timeSpan && timeSpan < a.EndTime);
        return congestion?.Fee ?? 0;
    }

    private bool IsTollFreeDate(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
        //is it July
        if (date.Month== 7) return true;
        //is it Holiday
        if (HolidaysHelper.IsItHoliday(date))return true ;
        //is it a day before Holiday
        if (HolidaysHelper.IsItBeforeHoliday(date))return true ;
        return false;
    }
}