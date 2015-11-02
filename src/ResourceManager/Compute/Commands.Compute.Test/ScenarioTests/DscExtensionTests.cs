using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class DscExtensionTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmVMDscExtension()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-GetAzureRmVMDscExtension");
        }
    }
}
