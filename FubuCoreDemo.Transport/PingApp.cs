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

            Policies.Global.Reorder(x =>
            {
                x.ThisWrapperBeBefore<FirstLoggingBehavior>();
                x.ThisNodeMustBeAfter<InputNode>();
            });

            Channel(x => x.Ponger).AcceptsMessage<PingMessage>();
            Channel(x => x.Pinger).ReadIncoming();
        }
    }
}
