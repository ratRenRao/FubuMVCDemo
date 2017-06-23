using FubuMVC.Core;

namespace FubuCoreDemo.Transport
{
    public class DemoRegistry : FubuRegistry
    {
        public DemoRegistry()
        {
            Policies.Global.Add<DemoPolicy>();
            Policies.Local.Add<DemoPolicy>();

            Services.AddService<IFakeService, FakeService>();
        }
    }
}
