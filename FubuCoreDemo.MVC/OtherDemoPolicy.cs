using FubuCoreDemo.Transport;
using FubuMVC.Core;
using FubuMVC.Core.Registration;

namespace FubuCoreDemo.MVC
{
    public class OtherDemoPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            foreach (var chain in graph.Chains)
            {
                //chain.WrapWith<StopwatchBehavior>();
            }
        }
    }
}