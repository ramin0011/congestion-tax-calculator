using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using congestion.calculator.Models.Congestion;
using congestion_tax_calculator_net_core_data.Repositories.Base;
using congestion_tax_calculator_net_core_data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace congestion_tax_calculator_net_core_data.Repositories
{
    public  class CongestionTimeRepository : BaseRepository<CongestionTime>, ICongestionTimeRepository
    {
        public CongestionTimeRepository(CongestionDbContext context) : base(context)
        {
        }

        public Task<List<CongestionTime>> GetAllByCity(string city)
        {
            return GetAllQueryable().Where(a => a.City == city.ToLower())
                .OrderBy(a => a.StartTime).ToListAsync();
        }


    }
}
