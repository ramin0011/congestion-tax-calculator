using System;
using System.Collections.Generic;
using congestion.calculator.Models.Congestion;

namespace congestion.calculator.Services.Interfaces
{
    public interface ICongestionTimeService
    {
        List<CongestionTime> GetAll(string city);
        void Create(string city, TimeSpan startTime, TimeSpan endTime, int fee);
    }
}