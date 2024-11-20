using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductAggregates
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public decimal Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
