using System;
using FubuCore.Logging;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Http;

namespace FubuCoreDemo.Transport.Behaviors
{
    public class ThirdLoggingBehavior : WrappingBehavior
    {
        private readonly ICurrentChain _chain;
        private readonly ILogger _logger;

        public ThirdLoggingBehavior(ICurrentChain chain, ILogger logger)
        {
            _chain = chain;
            _logger = logger;
        }

        protected override void invoke(Action action)
        {
            _logger.Debug($"Entered ThirdLoggingBehavior");
            action();
        }
    }
}