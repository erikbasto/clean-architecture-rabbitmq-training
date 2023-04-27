using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository repository;
    private readonly IEventBus eventBus;

    public AccountService(IAccountRepository repository, IEventBus eventBus)
    {
        this.repository = repository;
        this.eventBus = eventBus;
    }

    public IEnumerable<Account> GetAccounts()
    {
        return this.repository.GetAccounts();
    }

    public void Transfer(AccountTransfer accountTransfer)
    {
        var createTransferCommand = new CreateTransferCommand(
            accountTransfer.FromAccount,
            accountTransfer.ToAccount,
            accountTransfer.TransferAmount);
        eventBus.SendCommand(createTransferCommand);
    }
}

