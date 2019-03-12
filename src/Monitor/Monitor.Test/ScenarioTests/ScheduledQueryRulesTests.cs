using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public class ScheduledQueryRulesTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public ScheduledQueryRulesTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetGetListUpdateRemoveActivityLogAlert()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-NewGetUpdateSetRemoveScheduledQueryRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingRemoveSetUpdateScheduledQueryRule()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-PipingRemoveSetUpdateScheduledQueryRule");
        }
    }
}