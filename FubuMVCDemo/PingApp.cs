using FubuMVC.Core.ServiceBus.Configuration;

namespace FubuMVCDemo
{
    public class PingApp : FubuTransportRegistry<TransportSettings>
    {
        public PingApp()
        {
            Channel(x => x.Ponger).AcceptsMessage<PingMessage>();
            Channel(x => x.Pinger).ReadIncoming();
        }
    }
}
