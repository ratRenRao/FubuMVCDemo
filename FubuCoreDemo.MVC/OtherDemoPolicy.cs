using FubuCoreDemo.Transport;
using FubuMVC.Core;
using FubuMVC.Core.Registration;
using SecondLoggingBehavior = FubuCoreDemo.MVC.Behaviors.SecondLoggingBehavior;
using ThirdLoggingBehavior = FubuCoreDemo.MVC.Behaviors.ThirdLoggingBehavior;

namespace FubuCoreDemo.MVC
{
    public class OtherDemoPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            foreach (var chain in graph.Chains)
            {
                chain.WrapWith<SecondLoggingBehavior>();
                chain.WrapWith<ThirdLoggingBehavior>();
            }
        }
    }
}