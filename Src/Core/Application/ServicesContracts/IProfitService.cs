using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServicesContracts
{
    public interface IProfitService
    {
        decimal AddProfit(decimal basePrice, decimal profitAmount);
    }

}
