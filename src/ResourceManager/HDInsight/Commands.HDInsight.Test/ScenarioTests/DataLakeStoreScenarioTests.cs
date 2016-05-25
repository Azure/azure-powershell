using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class DataLakeStoreScenarioTests : HDInsightScenarioTestsBase
    {
        public DataLakeStoreScenarioTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataLakeStoreClusterCreate()
        {
            NewInstance.RunPsTest("Test-DataLakeStoreClusterCreate");
        }
    }
}
