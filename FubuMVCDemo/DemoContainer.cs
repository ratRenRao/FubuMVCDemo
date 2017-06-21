using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace FubuMVCDemo
{
    public class DemoContainer : Container
    {
        public void Register<T, V>() where V : T
        {
            Configure(_ => _.For<T>().Use<V>());
        }
    }
}
