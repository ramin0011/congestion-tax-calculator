using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Models.Congestion
{
    public class CongestionTime
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Fee { get; set; }
        public string City { get; set; }
    }
}
