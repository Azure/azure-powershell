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
    using Xunit;

    /// <summary>
    /// Scenario tests for integration account certificate commands.
    /// </summary>
    public class IntegrationAccountCertificateTests : LogicAppTestRunner
    {
        public IntegrationAccountCertificateTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test New-AzIntegrationAccountCertificate command to create a new integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCertificate()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountCertificate");
        }

        /// <summary>
        /// Test New-AzIntegrationAccountCertificatePrivateKey command to create a new integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCertificatePrivateKey()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountCertificatePrivateKey");
        }

        /// <summary>
        /// Test Get-AzCertificate command to get the integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCertificate()
        {
            TestRunner.RunTestScript("Test-GetIntegrationAccountCertificate");
        }

        /// <summary>
        /// Test Remove-AzIntegrationAccountCertificate command to remove the integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveCertificate()
        {
            TestRunner.RunTestScript("Test-RemoveIntegrationAccountCertificate");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountCertificate command to update the integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateCertificate()
        {
            TestRunner.RunTestScript("Test-UpdateIntegrationAccountCertificate");
        }

        /// <summary>
        /// Test-CreateIntegrationAccountCertificatePublicKey command to update the integration account certificate.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCertificatePublicKey()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountCertificatePublicKey");
        }
    }
}