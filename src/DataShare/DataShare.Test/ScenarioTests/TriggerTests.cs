
namespace Microsoft.Azure.Commands.DataShare.Test.ScenarioTests.ScenarioTest
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class TriggerTests
    {
        private readonly ServiceManagement.Common.Models.XunitTracingInterceptor logger;
        public TriggerTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTriggerCrud()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-TriggerCrud");
        }

    }
}
