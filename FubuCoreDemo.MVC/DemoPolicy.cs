using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace FubuCoreDemo.MVC
{
    public class DemoPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            var firstBehavior = graph.ChainFor<FirstLoggingBehavior>();
            foreach (var chain in graph.Chains)
            {
                firstBehavior.FirstCall().AddBefore(ActionFilter.For<SecondLoggingBehavior>(x => true));
            }
        }
    }
}
