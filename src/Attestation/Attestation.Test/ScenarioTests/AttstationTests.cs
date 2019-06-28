using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Commands.Attestation.Test;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Attestation.Test.ScenarioTests
{
    public class AttstationTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public AttstationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        #region New-AzureRmAttestation        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAttestation()
        {
            AttestationController.NewInstance.RunPowerShellTest(_logger, "Test-CreateAttestation");
        }
        #endregion

        #region Get-AzureRmAttestation
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAttestation()
        {
            AttestationController.NewInstance.RunPowerShellTest(_logger, "Test-GetAttestation");
        }
        #endregion

        #region Remove-AzureRmAttestation
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteAttestationByName()
        {
            AttestationController.NewInstance.RunPowerShellTest(_logger, "Test-DeleteAttestationByName");
        }
        #endregion
    }
}
