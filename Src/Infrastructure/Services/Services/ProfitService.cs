using Application.ServicesContracts;

namespace Services.Services
{
    public class ProfitService : IProfitService
    {
        public decimal AddProfit(decimal basePrice, decimal profitAmount)
        {
            return basePrice + profitAmount;
        }
    }
}
