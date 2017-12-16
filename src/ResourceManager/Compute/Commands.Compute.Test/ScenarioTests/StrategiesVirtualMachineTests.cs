using Microsoft.Azure.Commands.Compute.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class StrategiesVirtualMachineTests
    {
        public StrategiesVirtualMachineTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.RunType, Category.CheckIn)]
        public void TestSimpleNewVm()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVm");
        }
    }
}
