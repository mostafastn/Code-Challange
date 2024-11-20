using Application.OrderAggregates;
using Application.RepositoryContracts;
using Application.ServicesContracts;
using Domain.OrderAggregates;

namespace Services.Services
{
    public class OrderService : IOrderService
    {
        protected readonly IOrderRepository _orderRepository;

        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;
        private readonly IProfitService _profitService;

        public OrderService(IOrderRepository orderRepository, IProductService productService, IDiscountService discountService, IProfitService profitService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _discountService = discountService;
            _profitService = profitService;
        }

        public async Task<OrderViewModel> CreateOrderAsync(OrderViewModel order)
        {
            if (order.TotalPrice < 50000)
                throw new Exception("Order total must be at least 50,000 Toman.");

            var now = DateTime.Now;
            if (now.Hour < 8 || now.Hour > 19)
                throw new Exception("Orders can only be placed between 8 AM and 7 PM.");

            // افزودن سود افزوده
            foreach (var item in order.OrderItems)
            {
                var product = await _productService.GetProductAsync(item.ProductId);
                item.UnitPrice = _profitService.AddProfit(product.Price, 5000); // مثال: سود ثابت 5000 تومان                
            }

            // اعمال تخفیف
            order.Discount = _discountService.ApplyDiscount(order.TotalPrice, 10, true); // تخفیف 10 درصد

            order.ShippingMethod = order.IsFragile ? "Express Shipping" : "Regular Shipping";
            order.CreatedAt = DateTime.Now;

            var data = (Order)order;

            var result = await _orderRepository.CreateOrderAsync(data);
            if (result is null)
                new Exception("invalid insert opration");

            return order;
        }
    }
}
