using FubuCoreDemo.Transport.Behaviors;
using FubuMVC.Core;
using FubuMVC.Core.Resources.Conneg;
using FubuMVC.Core.ServiceBus.Configuration;
using NLog;

namespace FubuCoreDemo.Transport
{
    public class PingApp : FubuTransportRegistry<TransportSettings>
    {
        public PingApp()
        {
            Policies.Global.Add<DemoPolicy>();
            Policies.Global.Add<OtherDemoPolicy>();

            Services.For<IFakeService>().Use<FakeService>();

            Policies.Global.Reorder(x =>
            {
                x.ThisWrapperBeBefore<SecondLoggingBehavior>();
                x.ThisNodeMustBeAfter<InputNode>();
            });

            Channel(x => x.Ponger).AcceptsMessage<PingMessage>();
            Channel(x => x.Pinger).ReadIncoming();
        }
    }
}
