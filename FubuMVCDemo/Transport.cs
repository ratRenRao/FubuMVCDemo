using System;
using FubuMVC.Core.ServiceBus.Configuration;

namespace FubuMVCDemo
{
    public class Transport : FubuTransportRegistry<TransportSettings>
    {
        public Transport()
        {
            Policies.Global.Add<Behaviors.ErrorBehaviorConvention>();
        }
    }

    public class TransportSettings
    {
        public Uri Pinger { get; set; } = new Uri("lq.tcp://localhost:2352/pinger");
        public Uri Ponger { get; set; } = new Uri("lq.tcp://localhost:2353/ponger");
    }
}
