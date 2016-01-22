using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class ChefExtensionTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestChefExtensionBasic()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SetChefExtensionBasic");
        }
    }
}
