using Application.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
