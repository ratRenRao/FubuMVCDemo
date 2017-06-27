﻿using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace FubuCoreDemo.Transport
{
    public class DemoPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Chains.Each(x => x.WrapWith<FirstLoggingBehavior>());
            graph.Actions().Each((x, i) => x.Where(y => y.BehaviorType == typeof(FirstLoggingBehavior)).Each(c => x.WrapWith<SecondLoggingBehavior>()));
        }
    }
}
