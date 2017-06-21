using FubuMVC.Core.ServiceBus.Configuration;

namespace FubuMVCDemo
{
    public class PongApp : FubuTransportRegistry<TransportSettings>
    {
        public PongApp()
        {
            Channel(x => x.Ponger).ReadIncoming();
        }
    }
}
