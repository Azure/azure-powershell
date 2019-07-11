namespace Microsoft.Azure.Commands.DataShare.Test.ScenarioTests.ScenarioTest
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class InvitationTests
    {
        private readonly ServiceManagement.Common.Models.XunitTracingInterceptor logger;

        public InvitationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInvitationCrud()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-InvitationCrud");
        }
    }
}
