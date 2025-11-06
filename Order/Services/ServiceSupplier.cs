using Microsoft.Extensions.DependencyInjection;
using Order.Interfaces;
using Order.Repositories;

namespace Order.Services
{
	public static class ServiceSupplier
	{
		private static ServiceProvider _serviceProvider = Build();

		private static ServiceProvider Build()
		{
			var services = new ServiceCollection();
			services.AddTransient<IOrderService, OrderService>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddSingleton<ILogger, Logger>();
			return services.BuildServiceProvider();
		}

		public static T? GetService<T>()
		{
			return (T?)_serviceProvider.GetService(typeof(T));
		}

		public static T GetRequiredService<T>()
		{
			return (T)_serviceProvider.GetRequiredService(typeof(T));
		}
	}
}