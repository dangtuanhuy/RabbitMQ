using MicoRabbit.Domain.Core.Commands;
using MicoRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicoRabbit.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;
        void Publish<T>(T @event) where T : Event;

        void Subsribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;

    }
}
