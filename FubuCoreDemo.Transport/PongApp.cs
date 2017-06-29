using FubuMVC.Core.ServiceBus.Configuration;
using NLog;

namespace FubuCoreDemo.Transport
{
    public class PongApp : FubuTransportRegistry<TransportSettings>
    {
        public PongApp()
        {
            //Policies.Global.Add<DemoPolicy>();
            //Policies.Local.Add<DemoPolicy>();

            //Services.AddService<IFakeService, FakeService>();
            //Services.AddService<ILogger>(LogManager.GetCurrentClassLogger());

            Channel(x => x.Ponger).ReadIncoming();
        }
    }
}
