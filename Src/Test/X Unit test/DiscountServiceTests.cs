using Application.ServicesContracts;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Unit_test
{
    public class DiscountServiceTests
    {
        private readonly IDiscountService _discountService;

        public DiscountServiceTests()
        {
            _discountService = new DiscountService();
        }

        [Fact]
        public void ApplyDiscount_Percentage_ShouldCalculateCorrectly()
        {
            // Arrange
            var price = 100000;
            var discount = 10;

            // Act
            var discountedPrice = _discountService.ApplyDiscount(price, discount, true);

            // Assert
            Assert.Equal(90000, discountedPrice);
        }

        [Fact]
        public void ApplyDiscount_FixedAmount_ShouldCalculateCorrectly()
        {
            // Arrange
            var price = 100000;
            var discount = 15000;

            // Act
            var discountedPrice = _discountService.ApplyDiscount(price, discount, false);

            // Assert
            Assert.Equal(85000, discountedPrice);
        }
    }
}
