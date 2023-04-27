using System.Reflection;
using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MicroRabbit.Infra.IoC;

public static class RegisterServicesExtensions
{
	public static IServiceCollection RegisterServices(this IServiceCollection services)
    {	
		// MediatR
		services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); 

		// Domain bus
		services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
		{
			var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
			var optionsFactory = sp.GetService<IOptions<RabbitMQParams>>();
			return new RabbitMQBus(sp.GetService<IMediator>(), optionsFactory, scopeFactory);
		});

		return services;
	}
}

