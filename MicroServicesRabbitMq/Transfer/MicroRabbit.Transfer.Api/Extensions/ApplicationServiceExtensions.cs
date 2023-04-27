using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;

namespace MicroRabbit.Transfer.Api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

        //suscriptions
        services.AddTransient<TransferEventHandler>();

        // Application service
        services.AddTransient<ITransferService, TransferService>();

        // Data
        services.AddTransient<ITransferRepository, TransferRepository>();
        services.AddScoped<TransferDbContext>();

        return services;
	}
}

