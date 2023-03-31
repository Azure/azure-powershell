using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class AccessPolicyTests : KeyVaultTestRunner
    {
        public AccessPolicyTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAllAccessPolicies()
        {
            TestRunner.RunTestScript("Test-SetAllAccessPolicies");
        }
    }
}
