using Order.Interfaces;
using Order.Services;

Console.WriteLine("Order Processing System");

Task[] tasks = new Task[7];
tasks[0] = Task.Run(async () => { await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(1); });
tasks[1] = Task.Run(async () => { await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(2); });
tasks[2] = Task.Run(async () => { await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(-1); });
tasks[3] = Task.Run(async () => { await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(3); });
tasks[4] = Task.Run(() => { ServiceSupplier.GetRequiredService<IOrderService>().TryAddOrder(new Order.Models.Order() { Id = 4, Description = "Keyboard" }); });
tasks[5] = Task.Run(async () =>
{
	await Task.WhenAny(tasks[4]);
	await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(4); 
});
tasks[6] = Task.Run(() => { ServiceSupplier.GetRequiredService<IOrderService>().TryAddOrder(new Order.Models.Order() { Id = 1, Description = "Laptop" }); });


try
{
	Task.WaitAll(tasks);
}
catch (AggregateException aggrEx)
{
	// do sth if necessary
	foreach (var innerEx in aggrEx.InnerExceptions)
	{
		//TODO
	}
}

Console.WriteLine("Processing complete.");
