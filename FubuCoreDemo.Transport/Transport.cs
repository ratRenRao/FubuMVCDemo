using System;
using FubuMVC.Core.ServiceBus.Configuration;

namespace FubuCoreDemo.Transport
{
    public class Transport : FubuTransportRegistry<TransportSettings>
    {
        public Transport()
        {
            Policies.Global.Add<DemoPolicy>();
            Policies.Local.Add<DemoPolicy>();

            Services.AddService<IFakeService, FakeService>();
        }
    }

    public class TransportSettings : DemoRegistry
    {
        public Uri Pinger { get; set; } = new Uri("lq.tcp://localhost:2352/pinger");
        public Uri Ponger { get; set; } = new Uri("lq.tcp://localhost:2353/ponger");
    }
}
