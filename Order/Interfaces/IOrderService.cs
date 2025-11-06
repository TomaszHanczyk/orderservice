namespace Order.Interfaces
{
	// Interface for order service
	public interface IOrderService
	{
		Task ProcessOrderAsync(int orderId);
	}
}
