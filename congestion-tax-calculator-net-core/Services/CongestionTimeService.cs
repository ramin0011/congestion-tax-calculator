using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using congestion.calculator.Models.Congestion;
using congestion.calculator.Services.Interfaces;
using congestion_tax_calculator_net_core_data.Repositories.Interfaces;

namespace congestion.calculator.Services
{
    public  class CongestionTimeService :  ICongestionTimeService
    {
        private ICongestionTimeRepository _congestionTimeRepository;
        public CongestionTimeService(ICongestionTimeRepository congestionTimeRepository)
        {
           this._congestionTimeRepository=congestionTimeRepository;
        }
        public Task<List<CongestionTime>> GetAll(string city)
        {
            return _congestionTimeRepository.GetAllByCity(city);
        }
        public async Task Create(string city, TimeSpan startTime, TimeSpan endTime, int fee)
        {
            city = city.ToLower();
            await _congestionTimeRepository.Add(new CongestionTime()
            {
                EndTime = endTime,
                City = city,
                StartTime = startTime,
                Fee = fee
            });
        }
    }
}