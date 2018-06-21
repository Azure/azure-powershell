using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class AddTransparentDataEncryptionCertificateTests : SqlTestsBase
    {
        public AddTransparentDataEncryptionCertificateTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerDefaultParameterSetNoPassword()
        {
            RunPowerShellTest("Test-AddTdeCertificateForSqlServerDefaultParameterSetNoPassword");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerDefaultParameterSetWithPassword()
        {
            RunPowerShellTest("Test-AddTdeCertificateForSqlServerDefaultParameterSetWithPassword");
        }

        [Fact(Skip = "Skip due to long setup time for managed instance")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForManagedInstanceDefaultParameterSetNoPassword()
        {
            RunPowerShellTest("Test-AddTdeCertificateForManagedInstanceDefaultParameterSetNoPassword");
        }

        [Fact(Skip = "Skip due to long setup time for managed instance")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForManagedInstanceDefaultParameterSetWithPassword()
        {
            RunPowerShellTest("Test-AddTdeCertificateForManagedInstanceDefaultParameterSetWithPassword");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerInputObjectParameterSetWithPassword()
        {
            RunPowerShellTest("Test-AddTdeCertificateForSqlServerInputObjectParameterSetWithPassword");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerResourceIdParameterSetWithPassword()
        {
            RunPowerShellTest("Test-AddTdeCertificateForSqlServerResourceIdParameterSetWithPassword");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerInputObjectParameterSetNoPassword()
        {
            RunPowerShellTest("Test-AddTdeCertificateForSqlServerInputObjectParameterSetNoPassword");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerResourceIdParameterSetNoPassword()
        {
            RunPowerShellTest("Test-AddTdeCertificateForSqlServerResourceIdParameterSetNoPassword");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTdeCertificateForSqlServerWithPiping()
        {
            RunPowerShellTest("Test-AddTdeCertificateForSqlServerWithPiping");
        }
    }
}
