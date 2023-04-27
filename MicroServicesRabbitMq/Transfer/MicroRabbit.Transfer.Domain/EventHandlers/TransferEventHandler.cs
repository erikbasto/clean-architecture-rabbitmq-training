using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Domain.EventHandlers;

public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
{
    private readonly ITransferRepository transferRepository;

    public TransferEventHandler(ITransferRepository transferRepository)
	{
        this.transferRepository = transferRepository;
    }

    public Task Handler(TransferCreatedEvent @event)
    {
        var transaction = new TransferLog
        {
            FromAccount = @event.From,
            ToAccount = @event.To,
            TransferAmount = @event.Amount
        };

        transferRepository.AddTransferLog(transaction);
        return Task.CompletedTask;
    }
}

