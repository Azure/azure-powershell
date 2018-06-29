using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.DevSpaces.Test.ScenarioTests
{
    public class DevSpacesTests : RMTestBase
    {
        public DevSpacesTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDevSpaces()
        {
            TestController.NewInstance.RunPowerShellTest("Test-AzureRmDevSpacesController");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDevSpacesAsJobParameter()
        {
            TestController.NewInstance.RunPowerShellTest("Test-TestAzureDevSpacesAsJobParameter");
        }
    }
}
