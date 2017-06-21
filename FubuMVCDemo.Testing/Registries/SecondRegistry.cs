using StructureMap;

namespace FubuMVCDemo.Testing.Registries
{
    public class SecondRegistry : Registry
    {
        public SecondRegistry()
        {
            For<ITestClass>().Use<TestClass>();
        }
    }
}