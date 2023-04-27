using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventBus
	{
		Task SendCommand<T>(T command) where T : Command;
		void Publish<T>(T @event) where T : Event;
		void Suscribe<T, TH>()
			where T : Event
			where TH : IEventHandler<T>;
	}
}

