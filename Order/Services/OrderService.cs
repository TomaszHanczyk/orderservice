using Order.Interfaces;

namespace Order.Services
{
	public class OrderService(IOrderRepository orderRepository, ILogger logger) : IOrderService
	{
		public async Task ProcessOrderAsync(int orderId)
		{
			logger.LogInfo($"Start of processing order id: {orderId}.");

			try
			{
				await orderRepository.GetOrderAsync(orderId);
			}
			catch (ArgumentException argException)
			{
				logger.LogError($"Exception during processing order id: {orderId}.", argException);
				throw;
			}
			catch (KeyNotFoundException keyNotFoundException)
			{
				logger.LogError($"Exception during processing order id: {orderId}.", keyNotFoundException);
				throw;
			}
			catch (Exception e)
			{
				logger.LogError(e.Message, e);
				throw;
			}

			logger.LogInfo($"End of processing order id: {orderId}.");
		}
	}
}
