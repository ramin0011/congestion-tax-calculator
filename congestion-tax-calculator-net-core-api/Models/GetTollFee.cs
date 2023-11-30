using congestion.calculator.Models.Vehicles;
using congestion_tax_calculator_net_shared.Enums;

namespace congestion_tax_calculator_net_core_api.Models
{
    public record GetTollFee(DateTime date, VehiclesTypes vehicle, string city);
}
