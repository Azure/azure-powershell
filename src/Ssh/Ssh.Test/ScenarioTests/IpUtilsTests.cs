using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Ssh.Test.ScenarioTests
{
    public class IpUtilsTests : SshTestRunner
    {
        public IpUtilsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIpUtilsPublicIp()
        {
            TestRunner.RunTestScript("Test-GetPublicIp");
        }


    }
}
