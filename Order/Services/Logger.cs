using Order.Interfaces;

namespace Order.Services
{
	public class Logger : ILogger
	{
		public void LogInfo(string message)
		{
			Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {message}");
		}

		public void LogError(string message, Exception ex)
		{
			Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {message} {ex}");
		}
	}
}
