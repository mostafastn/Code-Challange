using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServicesContracts
{
    public interface IDiscountService
    {
        decimal ApplyDiscount(decimal price, decimal discountValue, bool isPercentage);
    }

}
