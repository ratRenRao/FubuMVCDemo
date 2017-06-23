using System;
using System.Diagnostics;
using FubuMVC.Core.Behaviors;

namespace FubuCoreDemo.Transport
{
    public class StopwatchBehavior : IActionBehavior
    {
        private readonly Action<double> _record;
        public Stopwatch Stopwatch { get; set; }

        public StopwatchBehavior(Action<double> record)
        {
            _record = record;
        }

        public IActionBehavior InnerBehavior { get; set; }

        public void Invoke()
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
            try
            {
                InnerBehavior.Invoke();
            }
            finally
            {
                {
                    Stopwatch.Stop();
                    _record(Stopwatch.ElapsedMilliseconds);
                }
            }
        }

        public void InvokePartial()
        {
            Invoke();
        }
    }
}
