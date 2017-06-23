using FubuMVC.Core;
using FubuMVC.Core.Registration;

namespace FubuCoreDemo.Transport
{
    public class DemoPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            foreach (var chain in graph.Chains)
            {
                chain.WrapWith<LoggingBehavior>();
            }
        }
    }
}
