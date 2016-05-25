using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class SqlIaaSExtensionTests
    {
        public SqlIaaSExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlIaaSExtension()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SetAzureRmVMSqlServerExtension");
        }
    }
}
