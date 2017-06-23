using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core;

namespace FubuCoreDemo.MVC
{
    public class AppRegistry : FubuRegistry
    {
        public AppRegistry()
        {
            //grab all classes that are suffixed with Endpoint and turn the public methods into actions
            //This will occur by default, only placed in here for understanding
            Actions.IncludeClassesSuffixedWithEndpoint();


            //Setup for the IOC (Inverson of Control) container using StructureMap (FubuMVCTODO only supports StructureMap)
            Services.IncludeRegistry<CoreRegistry>();


            //Enables the FubuMVCTODO Diagnostics - Very useful for troubleshooting your application (access via "localhost:port#/_fubu")
            Features.Diagnostics.Enable(TraceLevel.Verbose);
        }
    }
}