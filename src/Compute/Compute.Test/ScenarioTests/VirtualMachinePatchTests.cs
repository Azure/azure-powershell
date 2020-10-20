using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;


namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class VirtualMachinePatchTests : ComputeTestRunner
    {
        public VirtualMachinePatchTests(Xunit.Abstractions.ITestOutputHelper output)
           : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInvokeAzVmPatchAssessment()
        {
            TestRunner.RunTestScript("Test-InvokeAzVmPatchAssessment");
        }
    }
}
