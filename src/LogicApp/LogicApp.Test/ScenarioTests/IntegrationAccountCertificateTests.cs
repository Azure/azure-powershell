// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.LogicApp.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using ServiceManagement.Common.Models;
    using Xunit;

    /// <summary>
    /// Scenario tests for integration account certificate commands.
    /// </summary>
    public class IntegrationAccountCertificateTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public IntegrationAccountCertificateTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        /// <summary>
        /// Test New-AzIntegrationAccountCertificate command to create a new integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCertificate()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-CreateIntegrationAccountCertificate");
        }

        /// <summary>
        /// Test New-AzIntegrationAccountCertificatePrivateKey command to create a new integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCertificatePrivateKey()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-CreateIntegrationAccountCertificatePrivateKey");
        }

        /// <summary>
        /// Test Get-AzCertificate command to get the integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCertificate()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetIntegrationAccountCertificate");
        }

        /// <summary>
        /// Test Remove-AzIntegrationAccountCertificate command to remove the integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveCertificate()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-RemoveIntegrationAccountCertificate");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountCertificate command to update the integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateCertificate()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateIntegrationAccountCertificate");
        }

        /// <summary>
        /// Test-CreateIntegrationAccountCertificatePublicKey command to update the integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCertificatePublicKey()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-CreateIntegrationAccountCertificatePublicKey");
        }
    }
}