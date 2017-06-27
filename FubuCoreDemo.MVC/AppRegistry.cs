using FubuMVC.Core;

namespace FubuCoreDemo.MVC
{
    public class AppRegistry : FubuRegistry
    {
        public AppRegistry()
        {
            // Apply the MyLoggingPolicy to every
            // chain in the system (i.e. Bottles included)
            Policies.Global.Add<DemoPolicy>();
            // Apply the MyLoggingPolicy to only
            // the chains discovered from the main application
            // or a local extension
            Policies.Local.Add<DemoPolicy>();

            Policies.Global.Add<OtherDemoPolicy>();

            Policies.Global.Reorder(x =>
            {
                x.ThisWrapperBeBefore<FirstLoggingBehavior>();
            });

            //Use 'Endpoint' suffix convention, turning the public methods into actions
            Actions.IncludeClassesSuffixedWithEndpoint();


            //Setup for the IOC container using StructureMap
            Services.IncludeRegistry<CoreRegistry>();


            //Enables the FubuMVC.Core Diagnostics (access via "localhost:port#/_fubu")
            Features.Diagnostics.Enable(TraceLevel.Verbose);
        }
    }
}