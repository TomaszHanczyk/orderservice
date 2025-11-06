using Order.Interfaces;
using Order.Services;

Console.WriteLine("Order Processing System");

Task[] tasks = new Task[4];
tasks[0] = Task.Run(async () => { await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(1); });
tasks[1] = Task.Run(async () => { await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(2); });
tasks[2] = Task.Run(async () => { await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(-1); });
tasks[3] = Task.Run(async () => { await ServiceSupplier.GetRequiredService<IOrderService>().ProcessOrderAsync(3); });

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
