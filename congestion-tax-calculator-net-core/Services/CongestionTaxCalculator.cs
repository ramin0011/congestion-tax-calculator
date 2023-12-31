using System;
using System.Linq;
using System.Threading.Tasks;
using congestion.calculator.Helpers.DateHelpers;
using congestion.calculator.Models.Vehicles;
using congestion.calculator.Services.Interfaces;
using congestion_tax_calculator_net_shared.Enums;

namespace congestion.calculator.Services
{
    public  class CongestionTaxCalculator : ICongestionTaxCalculator
    {

        private readonly ICongestionTimeService _congestionTimeService;
        public CongestionTaxCalculator(ICongestionTimeService congestionTimeService)
        {
            this._congestionTimeService=congestionTimeService;
        }
        public async Task<int> GetTax(VehiclesTypes vehicle, DateTime[] dates, string city)
        {
            int totalFee = 0;
            foreach (var item in dates.GroupByCloseDates(60))
            {
                int currentFee =await GetTollFee(item.Key,vehicle,city);
                foreach (var date in item.Value)
                {
                    var _fee = await GetTollFee(date, vehicle, city);
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
    
        private bool IsTollFreeVehicle(VehiclesTypes vehicle)
        {
            if (vehicle == null) return false;
            return vehicle != VehiclesTypes.Car;
        }

        public async Task<int> GetTollFee(DateTime date, VehiclesTypes vehicle, string city)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;
            var data =await _congestionTimeService.GetAllByCity(city);

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
}