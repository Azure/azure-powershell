using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    public class ConnectAzSftpTests : SftpTestRunner
    {
        public ConnectAzSftpTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectAzSftpWithCertificateAuth()
        {
            TestRunner.RunTestScript("Test-ConnectAzSftpWithCertificateAuth");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectAzSftpWithAzureADAuth()
        {
            TestRunner.RunTestScript("Test-ConnectAzSftpWithAzureADAuth");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectAzSftpWithLocalUserAuth()
        {
            TestRunner.RunTestScript("Test-ConnectAzSftpWithLocalUserAuth");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectAzSftpParameterValidation()
        {
            TestRunner.RunTestScript("Test-ConnectAzSftpParameterValidation");
        }
    }
}
