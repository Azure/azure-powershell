using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.DevSpaces.Test.ScenarioTests
{
    public class DevSpacesTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public DevSpacesTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDevSpaces()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmDevSpacesController");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureDevSpacesAsJobParameter()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-TestAzureDevSpacesAsJobParameter");
        }
    }
}
