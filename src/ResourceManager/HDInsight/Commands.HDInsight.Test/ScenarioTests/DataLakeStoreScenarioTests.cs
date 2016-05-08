using Microsoft.Azure.Commands.HDInsight.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
