using congestion_tax_calculator_net_core_data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core_data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CongestionDbContext _context;
        private readonly ILogger _logger;

        public ICongestionTimeRepository CongestionTimeRepository { get; private set; }

        public UnitOfWork(CongestionDbContext context, ICongestionTimeRepository CongestionTimes,ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("unit_of_work");
            this.CongestionTimeRepository = CongestionTimes;
        }

        public bool HasChanges() => _context.ChangeTracker.HasChanges();
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
