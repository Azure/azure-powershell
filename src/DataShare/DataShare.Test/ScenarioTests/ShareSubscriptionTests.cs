namespace Microsoft.Azure.Commands.DataShare.Test.ScenarioTests.ScenarioTest
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class ShareSubscriptionTests
    {
        private readonly ServiceManagement.Common.Models.XunitTracingInterceptor logger;

        public ShareSubscriptionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestShareSubscriptionCrud()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-ShareSubscriptionCrud");
        }
    }
}
