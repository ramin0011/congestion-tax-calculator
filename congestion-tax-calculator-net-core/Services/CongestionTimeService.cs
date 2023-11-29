using System;
using System.Collections.Generic;
using System.Linq;
using congestion.calculator.Models.Congestion;
using congestion.calculator.Services.Interfaces;
using congestion_tax_calculator_net_core_data;

namespace congestion.calculator.Services
{
    public  class CongestionTimeService : IDisposable, ICongestionTimeService
    {

        private CongestionDbContext _congestionDbContext;
        public CongestionTimeService()
        {
            _congestionDbContext = CongestionDbContext.CreateDbContext();
        }
        public List<CongestionTime> GetAll(string city)
        {
            return _congestionDbContext.CongestionTimes.Where(a => a.City == city.ToLower())
                .OrderBy(a => a.StartTime).ToList();
        }

        public void Create(string city, TimeSpan startTime, TimeSpan endTime, int fee)
        {
            city = city.ToLower();
            _congestionDbContext.CongestionTimes.Add(new CongestionTime()
            {
                EndTime = endTime,
                City = city,
                StartTime = startTime,
                Fee = fee
            });
            _congestionDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _congestionDbContext.SaveChanges();
            _congestionDbContext?.Dispose();
        }
    }
}