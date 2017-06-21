using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FubuCore.Logging;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace FubuMVCDemo.Behaviors
{
    public class ErrorBehaviorConvention : IConfigurationAction
    {
        public void Configure(BehaviorGraph behaviorGraph)
        {
            behaviorGraph.Actions()
                // Actions are frequently pulled from extendhealth bottles here i.e. .FromExtendHealthBottles().Each()...
                .Each(actionCall =>
                {
                    Console.WriteLine("Error behavior added");
                });
        }

        
    }
}
