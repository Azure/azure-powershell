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

        [Fact(Skip = "TODO: The platform image 'MicrosoftSQLServer:SQL2014SP1-WS2012R2:Enterprise:latest' is not availabl")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlIaaSExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmVMSqlServerExtension");
        }

        [Fact(Skip = "TODO: The platform image 'MicrosoftSQLServer:SQL2014SP1-WS2012R2:Enterprise:latest' is not available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlIaaSAKVExtension()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmVMSqlServerAKVExtension");
        }

        [Fact(Skip = "TODO: Update from Key1 to [0].Value and re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlIaaSExtensionWith2016Image()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmVMSqlServerExtensionWith2016Image");
        }
    }
}
