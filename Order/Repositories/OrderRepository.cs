using Order.Interfaces;
using System.Collections.Concurrent;

namespace Order.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ConcurrentDictionary<int, Models.Order> _orders = GetSampleOrder();

		public async Task<string> GetOrderAsync(int orderId)
		{
			if (orderId <= 0)
			{
				throw new ArgumentException("Order id value should be greater than 0.");
			}

			await Task.Delay(100);

			if (_orders.TryGetValue(orderId, out Models.Order? order))
			{
				return order.Description;
			}

			throw new KeyNotFoundException($"Order not found. Id: {orderId}");
		}

		private static ConcurrentDictionary<int, Models.Order> GetSampleOrder()
		{
			var sampleOrders = new ConcurrentDictionary<int, Models.Order>();

			sampleOrders.TryAdd(1, new Models.Order { Id = 1, Description = "Laptop" });
			sampleOrders.TryAdd(2, new Models.Order { Id = 2, Description = "Phone" });

			return sampleOrders;
		}
	}
}
