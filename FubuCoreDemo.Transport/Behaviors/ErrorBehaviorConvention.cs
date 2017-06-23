using System;
using System.Collections.Generic;
using FubuMVC.Core.Registration;

namespace FubuCoreDemo.Transport.Behaviors
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
