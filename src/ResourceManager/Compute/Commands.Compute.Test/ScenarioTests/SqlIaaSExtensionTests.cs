using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class SqlIaaSExtensionTests
    {
        ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;
        public SqlIaaSExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlIaaSExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmVMSqlServerExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlIaaSAKVExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmVMSqlServerAKVExtension");
        }

    }
}
