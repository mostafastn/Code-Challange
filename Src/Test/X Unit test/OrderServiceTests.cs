using Application.OrderAggregates;
using Application.ServicesContracts;

namespace X_Unit_test
{
    public class OrderServiceTests
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;


        public OrderServiceTests(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        [Fact]
        public async Task CreateOrder_ShouldThrowException_IfTotalPriceLessThan50000()
        {
            // Arrange
            var order = new OrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>
            {
                new OrderItemViewModel { ProductId = 1, Quantity = 1, UnitPrice = 20000 }
            }
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _orderService.CreateOrderAsync(order));
        }

        [Fact]
        public async Task CreateOrder_ShouldSetShippingMethod_BasedOnProductType()
        {
            // Arrange
            var fragileProduct = await _productService.GetFragileProductAsync();
            var product = fragileProduct.FirstOrDefault();

            var order = new OrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>
                {
                    new OrderItemViewModel { ProductId = product.Id, Quantity = 1, UnitPrice = product.Price }
                }
            };

            // Act
            var createdOrder = await _orderService.CreateOrderAsync(order);

            // Assert
            Assert.Equal("Express Shipping", createdOrder.ShippingMethod);
        }
    }
}
