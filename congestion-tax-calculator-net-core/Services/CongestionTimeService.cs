using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using congestion.calculator.Models.Congestion;
using congestion.calculator.Services.Interfaces;
using congestion_tax_calculator_net_core_data.Repositories.Interfaces;
using congestion_tax_calculator_net_core_data.UnitOfWork;

namespace congestion.calculator.Services
{
    public class CongestionTimeService : ICongestionTimeService
    {
        private ICongestionTimeRepository _congestionTimeRepository;

        public CongestionTimeService(IUnitOfWork unitOfWork)
        {
            this._congestionTimeRepository=unitOfWork.CongestionTimeRepository;
        }

        public Task<List<CongestionTime>> GetAllByCity(string city)
        {
            return _congestionTimeRepository.GetAllByCity(city);
        }
        public Task<List<CongestionTime>> GetAll()
        {
            return _congestionTimeRepository.GetAll();
        }

        public async Task Create(string city, TimeSpan startTime, TimeSpan endTime, int fee)
        {
            city = city.ToLower();
            if (await _congestionTimeRepository.Count(c => c.City == city &&
                                                           c.StartTime == startTime &&
                                                           c.EndTime == endTime) == 0)
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