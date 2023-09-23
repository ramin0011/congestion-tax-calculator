using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nager.Holiday;

namespace congestion.calculator.Helpers.DateHelpers
{
    internal  class HolidaysHelper
    {
        static List<DateTime> holidays= new List<DateTime>();
        public static List<DateTime> GetSwedenHolidays()
        {
            if (HolidaysHelper.holidays.Any()) {return HolidaysHelper.holidays;}
            using var holidayClient = new HolidayClient();
            //as this is going to be run one time we cache the data and make it calling in sync mode
            var holidays = Task.Run(async() => await holidayClient.GetHolidaysAsync(DateTime.Now.Year, "SE")).Result;
            HolidaysHelper.holidays = holidays.Select(a=>a.Date).ToList();
            return HolidaysHelper.holidays;
        }
        public static bool IsItHoliday(DateTime date)
        {
            return GetSwedenHolidays().Contains(date);
        } 
        
        public static bool IsItBeforeHoliday(DateTime date)
        {
            return GetSwedenHolidays().Contains(date.AddDays(1));
        }
    }
}
