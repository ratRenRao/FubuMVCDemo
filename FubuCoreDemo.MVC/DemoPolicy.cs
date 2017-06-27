using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace FubuCoreDemo.MVC
{
    public class DemoPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            foreach (var chain in graph.Chains)
            {
                chain.WrapWith<FirstLoggingBehavior>();
            }
        }
    }
}
