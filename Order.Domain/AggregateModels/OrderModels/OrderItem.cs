using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class OrderItem: BaseEntity
    {
        public int Quantity { get; private set; }
        public long Price { get; private set; }
        public int ProductId { get; private set; }

        public OrderItem(int quantity, long price, int productId)
        {
            if (quantity < 1)
                throw new Exception("Quantity cannot be less than 1");
            if (price < 1)
                throw new Exception("Price cannot be less than 1");

            Quantity = quantity;
            Price = price;
            ProductId = productId;
        }
    }
}
