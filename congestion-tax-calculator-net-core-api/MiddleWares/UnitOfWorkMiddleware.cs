using congestion_tax_calculator_net_core_data.UnitOfWork;

namespace congestion_tax_calculator_net_core_api.MiddleWares
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;

        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
        {
            await _next(context);

            if (unitOfWork.HasChanges())
            {
                await unitOfWork.CompleteAsync();
            }
        }
    }
}
