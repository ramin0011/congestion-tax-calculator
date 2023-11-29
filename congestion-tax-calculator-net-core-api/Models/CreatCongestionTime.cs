namespace congestion_tax_calculator_net_core_api.Models
{
    public record CreateCongestionTimeDto(string City, string StartTime, string EndTime, int Fee);
}
