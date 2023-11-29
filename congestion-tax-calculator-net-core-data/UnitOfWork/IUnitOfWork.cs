using System.Threading.Tasks;
using congestion_tax_calculator_net_core_data.Repositories.Interfaces;

namespace congestion_tax_calculator_net_core_data.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICongestionTimeRepository CongestionTimeRepository { get; }
        Task CompleteAsync();
        bool HasChanges();
    }
}