using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public DateTime OrderDate { get; private set; }
        public string Description { get; private set; }
        public string OrderStatus { get; private set; }
        public int BuyerId { get; private set; }

        public Address Address { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order(DateTime orderDate, string description, string orderStatus, int buyerId, Address address, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
                throw new Exception("Order Date cannot be less than current time.");
            if (description.Length < 5)
                throw new Exception("Description cannot be less than 5 characters.");
            if (string.IsNullOrWhiteSpace(address.City))
                throw new Exception("City cannot be empty");

            OrderDate = orderDate;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            OrderStatus = orderStatus ?? throw new ArgumentNullException(nameof(orderStatus));
            BuyerId = buyerId;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));
        }

        public void AddOrderItem(int quantity, long price, int productId)
        {
            OrderItems.Add(new OrderItem(quantity, price, productId));
        }
    }
}
