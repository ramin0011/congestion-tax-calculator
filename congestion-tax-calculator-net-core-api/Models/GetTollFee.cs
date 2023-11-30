using congestion.calculator.Models.Vehicles;

namespace congestion_tax_calculator_net_core_api.Models
{
    public record GetTollFee(DateTime date, VehiclesTypes vehicle, string city);
}
