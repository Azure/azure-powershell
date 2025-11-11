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

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectAzSftpWithCertificateAuth()
        {
            // Skipped: would run Test-ConnectAzSftpWithCertificateAuth.ps1
        }

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectAzSftpWithAzureADAuth()
        {
            // Skipped: would run Test-ConnectAzSftpWithAzureADAuth.ps1
        }

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectAzSftpWithLocalUserAuth()
        {
            // Skipped: would run Test-ConnectAzSftpWithLocalUserAuth.ps1
        }

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConnectAzSftpParameterValidation()
        {
            // Skipped: would run Test-ConnectAzSftpParameterValidation.ps1
        }
    }
}
