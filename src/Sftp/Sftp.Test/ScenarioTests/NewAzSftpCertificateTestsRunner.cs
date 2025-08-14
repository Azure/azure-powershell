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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateAutoGenerate()
        {
            TestRunner.RunTestScript("Test-NewAzSftpCertificateAutoGenerate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateWithPrivateKey()
        {
            TestRunner.RunTestScript("Test-NewAzSftpCertificateWithPrivateKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateWithPublicKey()
        {
            TestRunner.RunTestScript("Test-NewAzSftpCertificateWithPublicKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateForLocalUser()
        {
            TestRunner.RunTestScript("Test-NewAzSftpCertificateForLocalUser");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzSftpCertificateParameterValidation()
        {
            TestRunner.RunTestScript("Test-NewAzSftpCertificateParameterValidation");
        }
    }
}
