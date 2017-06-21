using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FubuMVC.Core.Behaviors;

namespace FubuMVCDemo
{
    public class BehaviourChainDemo : IActionBehavior
    {
        private readonly Action<double> _record;

        public BehaviourChainDemo(Action<double> record)
        {
            _record = record;
        }

        public IActionBehavior InnerBehavior { get; set; }

        public void Invoke()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                InnerBehavior.Invoke();
            }
            finally
            {
                {
                    stopwatch.Stop();
                    _record(stopwatch.ElapsedMilliseconds);
                }
            }
        }

        public void InvokePartial()
        {
            Invoke();
        }
    }
}
