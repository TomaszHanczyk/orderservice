// TODO: Initialize DI container, services, and repository
// TODO: Demonstrate multi-threaded order processing

using Order.Repositories;
using Order.Services;

Console.WriteLine("Order Processing System");

OrderService orderService = new OrderService(new OrderRepository(), new Logger());

// Example: Simulate multiple threads processing orders
Task[] tasks = new Task[3];
tasks[0] = Task.Run(async () => { await orderService.ProcessOrderAsync(1); });
tasks[1] = Task.Run(async () => { await orderService.ProcessOrderAsync(2); });
tasks[2] = Task.Run(async () => { await orderService.ProcessOrderAsync(-1); });
tasks[2] = Task.Run(async () => { await orderService.ProcessOrderAsync(3); });

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