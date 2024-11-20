using Application.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{    public class DiscountService : IDiscountService
    {
        public decimal ApplyDiscount(decimal price, decimal discountValue, bool isPercentage)
        {
            if (isPercentage)
            {
                return price * (1 - discountValue / 100);
            }
            return price - discountValue;
        }
    }
}
