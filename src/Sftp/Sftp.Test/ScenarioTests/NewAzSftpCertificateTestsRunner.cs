using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    public class NewAzSftpCertificateTests : SftpTestRunner
    {
        public NewAzSftpCertificateTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateAutoGenerate()
        {
            // Skipped: would run Test-NewAzSftpCertificateAutoGenerate.ps1
        }

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateWithPrivateKey()
        {
            // Skipped: would run Test-NewAzSftpCertificateWithPrivateKey.ps1
        }

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateWithPublicKey()
        {
            // Skipped: would run Test-NewAzSftpCertificateWithPublicKey.ps1
        }

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateForLocalUser()
        {
            // Skipped: would run Test-NewAzSftpCertificateForLocalUser.ps1
        }

        [Fact(Skip = "E2E scenario tests removed for CI; restore recordings to re-enable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateParameterValidation()
        {
            // Skipped: would run Test-NewAzSftpCertificateParameterValidation.ps1
        }
    }
}
