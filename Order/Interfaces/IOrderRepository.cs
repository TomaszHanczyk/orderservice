namespace Order.Interfaces
{
	// Interface for order repository
	public interface IOrderRepository
	{
		Task<string> GetOrderAsync(int orderId);
		bool TryAddOrder(Models.Order order);
	}
}
