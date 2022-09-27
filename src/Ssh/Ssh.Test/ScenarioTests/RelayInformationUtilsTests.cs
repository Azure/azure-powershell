using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Ssh.Test.ScenarioTests
{
    public class RelayInformationUtilsTests : SshTestRunner
    {
        public RelayInformationUtilsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRelayInformation()
        {
            TestRunner.RunTestScript("Test-GetRelayInformation");
        }

        /*
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRelayInformationNoPermission()
        {
            TestRunner.RunTestScript("Test-GetRelayInformation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNoEndpointWithPermissionToCreate()
        {
            TestRunner.RunTestScript("Test-NoEndpointWithPermissionToCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNoEndpointNoPermissionToCreate()
        {
            TestRunner.RunTestScript("Test-NoEndpointNoPermissionToCreate");
        }
        */
    }
}
