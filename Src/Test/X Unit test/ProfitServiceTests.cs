using Application.ServicesContracts;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Unit_test
{
    public class ProfitServiceTests
    {
        private readonly IProfitService _profitService;

        public ProfitServiceTests()
        {
            _profitService = new ProfitService();
        }

        [Fact]
        public void AddProfit_ShouldCalculateCorrectly()
        {
            // Arrange
            var basePrice = 50000;
            var profit = 10000;

            // Act
            var finalPrice = _profitService.AddProfit(basePrice, profit);

            // Assert
            Assert.Equal(60000, finalPrice);
        }
    }
}
