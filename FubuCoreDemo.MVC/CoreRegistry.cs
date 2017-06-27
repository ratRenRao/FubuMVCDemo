using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.Registration;

namespace FubuCoreDemo.MVC
{
    public class CoreRegistry : ServiceRegistry
    {
        public CoreRegistry()
        {
            //scan for items to add which follow the default conventions
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
        }
    }
}