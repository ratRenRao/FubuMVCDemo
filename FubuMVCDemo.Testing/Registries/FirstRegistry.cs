using StructureMap;

namespace FubuMVCDemo.Testing.Registries
{
    public class FirstRegistry : Registry
    {
        public FirstRegistry()
        {
            For<ITestClass>().Use<TestClass>();
        }
    }
}