using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Ssh.Test.ScenarioTests
{
    public class GetAzSshConfigTests : SshTestRunner
    {
        public GetAzSshConfigTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetArcConfig()
        {
            TestRunner.RunTestScript("Test-GetArcConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVmConfig()
        {
            TestRunner.RunTestScript("Test-GetVmConfig");
        }
    }
}
