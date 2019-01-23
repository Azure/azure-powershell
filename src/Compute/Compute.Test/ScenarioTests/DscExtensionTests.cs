using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class DscExtensionTests
    {
        XunitTracingInterceptor _logger;

        public DscExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmVMDscExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmVMDscExtension");
        }
    }
}
