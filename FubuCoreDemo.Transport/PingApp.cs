using FubuMVC.Core.ServiceBus.Configuration;
using NLog;

namespace FubuCoreDemo.Transport
{
    public class PingApp : FubuTransportRegistry<TransportSettings>
    {
        public PingApp()
        {
            Policies.Global.Add<DemoPolicy>();
            Policies.Local.Add<DemoPolicy>();

            Policies.Global.Add<OtherDemoPolicy>();
            Policies.Local.Add<OtherDemoPolicy>();

            Services.AddService<IFakeService, FakeService>();
            Services.AddService<ILogger>(LogManager.GetCurrentClassLogger());

            Channel(x => x.Ponger).AcceptsMessage<PingMessage>();
            Channel(x => x.Pinger).ReadIncoming();
        }
    }
}
