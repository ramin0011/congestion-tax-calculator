using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using congestion.calculator.Models.Congestion;

namespace congestion_tax_calculator_net_core_data.Repositories.Interfaces
{
    public interface ICongestionTimeRepository : IRepositoryBase<CongestionTime>
    {
        Task<List<CongestionTime>> GetAllByCity(string city);
    }
}
