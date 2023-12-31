using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using congestion.calculator.Models.Congestion;

namespace congestion.calculator.Services.Interfaces
{
    public interface ICongestionTimeService
    {
        Task<List<CongestionTime>> GetAllByCity(string city);
        Task<List<CongestionTime>> GetAll();
        Task Create(string city, TimeSpan startTime, TimeSpan endTime, int fee);
    }
}