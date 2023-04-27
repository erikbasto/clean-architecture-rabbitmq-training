using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;

namespace MicroRabbit.Banking.Api.Extensions;

public static class ApplicationServiceExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		//Command for RabbitMQ
        services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

        // Application service
        services.AddTransient<IAccountService, AccountService>();

        // Data
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddScoped<BankingDbContext>();

        return services;
	}
}

